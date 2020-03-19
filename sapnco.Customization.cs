using System;
using System.Data;

///須參考sapnco.dll;sapnco_utils.dll for net40 x86
using SAP.Middleware.Connector;

namespace sapnco.Customization
{
    #region 參數資料結構

    /// <summary>
    /// 包含或除外
    /// </summary>
    public enum SIGN
    {
        /// <summary>include 包含 (預設值)</summary>
        I,
        /// <summary>exclude 除外</summary>
        E,
    }
    /// <summary>
    /// 區間選項
    /// </summary>
    public enum OPTION
    {
        /// <summary>Equal 等於 (預設值)</summary>
        EQ,
        /// <summary>Not Equal 不等於</summary>
        NE,
        /// <summary>Greater Than or Equal 大於等於</summary>
        GE,
        /// <summary>Greater Than 大於</summary>
        GT,
        /// <summary>Less Than or Equal 小於等於</summary>
        LE,
        /// <summary>Less Than 小於</summary>
        LT,
        /// <summary>Contains Pattern 包含 ?</summary>
        CP,
        /// <summary>?</summary>
        NP,

        /// <summary>Between 介於</summary>
        BT,
        /// <summary>Not Between 不介於</summary>
        NB,
    }
    public class ParameterRange
    {
        public const string sSIGN = "SIGN";
        public const string sOPTION = "OPTION";
        public const string sLOW = "LOW";
        public const string sHIGH = "HIGH";

        virtual protected int LengthLimit { private set; get; }

        public ParameterRange()
        {
            dataTable.Columns.Add(sSIGN);
            dataTable.Columns.Add(sOPTION);
            dataTable.Columns.Add(sLOW);
            dataTable.Columns.Add(sHIGH);
        }

        public DataTable dataTable = new DataTable();

        public void Add(SIGN sign, OPTION option, string low, string high)
        {
            if (low.Length >= LengthLimit)
            {
                low = low.Substring(0, LengthLimit);
            }
            if (high.Length >= LengthLimit)
            {
                high = high.Substring(0, LengthLimit);
            }

            DataRow row = dataTable.NewRow();
            row[sSIGN] = sign.ToString();
            row[sOPTION] = option.ToString();
            row[sLOW] = low;
            row[sHIGH] = high;
            dataTable.Rows.Add(row);
        }
        public class Param
        {
            public SIGN sign = SIGN.I;
            public OPTION option = OPTION.EQ;
            public string low = string.Empty;
            public string high = string.Empty;
        }
        public void Add(Param para)
        {
            Add(para.sign, para.option, para.low, para.high);
        }

        public void ToRfcTable(ref IRfcTable resultTable)
        {
            resultTable.Clear();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                resultTable.Append();

                string dSIGN = dataTable.Rows[i][sSIGN].ToString();
                if (dSIGN == string.Empty) dSIGN = SIGN.I.ToString();
                resultTable[i].SetValue(sSIGN, dSIGN);

                string dOPTION = dataTable.Rows[i][sOPTION].ToString();
                if (dOPTION == string.Empty) dOPTION = OPTION.EQ.ToString();
                resultTable[i].SetValue(sOPTION, dOPTION);

                string low = RFC_FunctionBase.ValueProcess(dataTable.Rows[i][sLOW].ToString(), LengthLimit);
                resultTable[i].SetValue(sLOW, low);
                string high = RFC_FunctionBase.ValueProcess(dataTable.Rows[i][sHIGH].ToString(), LengthLimit);
                resultTable[i].SetValue(sHIGH, high);
            }
        }
    }

    public class MATERIAL_RA : ParameterRange { protected override int LengthLimit { get { return 18; } } }
    public class PLANT_RA : ParameterRange { protected override int LengthLimit { get { return 4; } } }
    public class STGE_LOC_RA : ParameterRange { protected override int LengthLimit { get { return 4; } } }
    public class BATCH_RA : ParameterRange { protected override int LengthLimit { get { return 10; } } }
    public class MOVE_TYPE_RA : ParameterRange { protected override int LengthLimit { get { return 3; } } }
    public class SPEC_STOCK_RA : ParameterRange { protected override int LengthLimit { get { return 1; } } }
    public class TR_EV_TYPE_RA : ParameterRange { protected override int LengthLimit { get { return 2; } } }
    public class PSTNG_DATE_RA : ParameterRange { protected override int LengthLimit { get { return 10; } } }
    public class VENDOR_RA : ParameterRange { protected override int LengthLimit { get { return 10; } } }
    public class USERNAME_RA : ParameterRange { protected override int LengthLimit { get { return 12; } } }
    public class PURCH_DOC_RA : ParameterRange { protected override int LengthLimit { get { return 10; } } }

    #endregion

    /// <summary> 
    /// 終端設定 
    /// </summary>
    class DestinationConfiguration : IDestinationConfiguration
    {
        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        public bool ChangeEventsSupported() { return false; }
        RfcConfigParameters IDestinationConfiguration.GetParameters(string destinationName)
        {
            RfcConfigParameters parms = new RfcConfigParameters();

            parms.Add(RfcConfigParameters.SystemNumber, SystemNumber);
            parms.Add(RfcConfigParameters.AppServerHost, AppServerHost);
            parms.Add(RfcConfigParameters.Client, Client);
            parms.Add(RfcConfigParameters.User, User);
            parms.Add(RfcConfigParameters.Password, Password);

            return parms;
        }

        string SystemNumber, AppServerHost, Client, User, Password;
        public DestinationConfiguration(string _SystemNumber, string _AppServerHost, string _Client, string _User, string _Password)
        {
            SystemNumber = _SystemNumber;
            AppServerHost = _AppServerHost;
            Client = _Client;
            User = _User;
            Password = _Password;
        }
    }

    interface ISAP_RFC_ConnectBase
    {
        RfcDestination GetDestination();
    }
    abstract public class SAP_RFC_ConnectBase : ISAP_RFC_ConnectBase
    {
        abstract protected string SystemNumber { get; }
        abstract protected string AppServerHost { get; }

        abstract protected string Client { get; }
        abstract protected string User { get; }
        abstract protected string Password { get; }

        public RfcDestination GetDestination()
        {
            if (!RfcDestinationManager.IsDestinationConfigurationRegistered())
            {
                RfcDestinationManager.RegisterDestinationConfiguration(new DestinationConfiguration(SystemNumber, AppServerHost, Client, User, Password));
            }
            ///參數只要不是空字串之任意字串
            return RfcDestinationManager.GetDestination("RFC");
        }
    }

    abstract public class RFC_FunctionBase
    {
        SAP_RFC_ConnectBase connect;
        protected RfcDestination Destination
        {
            get
            {
                return connect.GetDestination();
            }
        }
        public RFC_FunctionBase(SAP_RFC_ConnectBase conn)
        {
            connect = conn;
        }

        abstract protected string FunName { get; }
        protected IRfcFunction RfcFunction
        {
            get
            {
                return Destination.Repository.CreateFunction(FunName);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        protected IRfcFunction GetRfcFunction(string func)
        {
            return Destination.Repository.CreateFunction(func);
        }

        /// <summary>
        /// 處理純數字左側須補滿0
        /// </summary>
        /// <param name="value"></param>
        /// <param name="totalWidth">字元數上限</param>
        /// <returns></returns>
        static public string ValueProcess(string value, int totalWidth)
        {
            if (value.Length > totalWidth)
            {
                value = value.Substring(0, totalWidth);
            }

            /// 不能用int 超過九位數解析成數值就會有部分有問題
            /// 也不能用double 帶E字會被解析成科學符號的數值
            /// 必須使用Int64以上解析,Int64就足夠18碼數字做數值解析了
            /// 保險起見使用UInt64
            UInt64 tmp;
            if (UInt64.TryParse(value, out tmp))
            {
                value = value.PadLeft(totalWidth, '0');
            }

            return value.ToUpper();
        }

        /// <summary>
        /// 處理料號參數
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static public string MaterialProcess(string value)
        {
            return ValueProcess(value, 18);
        }

        #region RfcTable to DataTable

        protected void RfcStructureToDataRow(IRfcStructure rfcStructure, ref DataRow row)
        {
            for (int i = 0; i < rfcStructure.ElementCount; i++)
            {
                RfcElementMetadata Metadata = rfcStructure.GetElementMetadata(i);
                row[Metadata.Name] = rfcStructure.GetString(Metadata.Name).Trim();
            }
        }

        protected DataTable CreateDataTableFromRfcData(IRfcDataContainer rfcData, string tableName = null)
        {
            DataTable dataTable = new DataTable();
            if (tableName != null) dataTable.TableName = tableName;

            for (int i = 0; i < rfcData.ElementCount; i++)
            {
                RfcElementMetadata Metadata = rfcData.GetElementMetadata(i);
                dataTable.Columns.Add(Metadata.Name);
            }
            return dataTable;
        }
        protected DataTable RfcTableToDataTable(IRfcTable rfcTable, string tableName = null)
        {
            DataTable dataTable = CreateDataTableFromRfcData(rfcTable, tableName);

            foreach (IRfcStructure rfcStructure in rfcTable)
            {
                ///取得列中每欄資料
                DataRow row = dataTable.NewRow();
                RfcStructureToDataRow(rfcStructure, ref row);
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
        protected DataTable RfcStructureToDataTable(IRfcStructure rfcStructure, string tableName = null)
        {
            DataTable dataTable = CreateDataTableFromRfcData(rfcStructure, tableName);

            //取得列中每欄資料                
            DataRow row = dataTable.NewRow();
            RfcStructureToDataRow(rfcStructure, ref row);
            dataTable.Rows.Add(row);

            return dataTable;
        }
        protected DataTable GetFunctionStructureToDataTable(ref IRfcFunction iRfcFunction, string tableName)
        {
            IRfcStructure iRfcStructure = iRfcFunction.GetStructure(tableName);
            return RfcStructureToDataTable(iRfcStructure, tableName);
        }
        protected DataTable GetFunctionTableToDataTable(ref IRfcFunction iRfcFunction, string tableName)
        {
            IRfcTable rfcTable = iRfcFunction.GetTable(tableName);
            return RfcTableToDataTable(rfcTable, tableName);
        }

        #endregion
    }
}
