using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using SAP.Middleware.Connector;

namespace sapnco.Customization.BAPI_MATERIAL_STOCK_REQ_LIST
{
    /// <summary>
    /// 查需求
    /// </summary>
    public class BAPI_MATERIAL_STOCK_REQ_LIST : RFC_FunctionBase
    {
        protected override string FunName { get { return "BAPI_MATERIAL_STOCK_REQ_LIST"; } }
        public BAPI_MATERIAL_STOCK_REQ_LIST(SAP_RFC_ConnectBase conn) : base(conn) { }

        #region const string

        public const string AVAIL_DATE = "AVAIL_DATE";
        public const string REC_REQD_QTY = "REC_REQD_QTY";
        public const string MRP_ELEMNT = "MRP_ELEMNT";
        public const string MRP_ELEMENT_IND = "MRP_ELEMENT_IND";
        public const string ELEMNT_DATA = "ELEMNT_DATA";
        public const string PLAN_PLANT2 = "PLAN_PLANT2";
        public const string MRP_NO12 = "MRP_NO12";

        //輸出表格名稱
        public const string MRP_IND_LINES = "MRP_IND_LINES";
        public const string MRP_ITEMS = "MRP_ITEMS";

        #endregion

        /// <summary>
        /// Func原始格式，包含所有參數
        /// </summary>
        /// <param name="MATERIAL"></param>
        /// <param name="PLANT"></param>
        /// <param name="MPR_AREA"></param>
        /// <param name="PLAN_SCENARIO"></param>
        /// <param name="SELECTION_RULE"></param>
        /// <param name="DISPLAY_FILTER"></param>
        /// <param name="MATERIAL_EVG_MATERIAL_EXT"></param>
        /// <param name="MATERIAL_EVG_MATERIAL_VERS"></param>
        /// <param name="MATERIAL_EVG_MATERIAL_GUID"></param>
        /// <param name="PERIOD_INDICATOR"></param>
        /// <param name="IGNORE_BUFFER"></param>
        /// <param name="GET_ITEM_DETAILS"></param>
        /// <param name="GET_TOTAL_LINES"></param>
        /// <param name="GET_IND_LINES"></param>
        /// <returns>DataSet</returns>
        public DataSet Send(
            string MATERIAL, string PLANT,
            string MRP_AREA, string PLAN_SCENARIO, string SELECTION_RULE, string DISPLAY_FILTER,
            string MATERIAL_EVG_MATERIAL_EXT, string MATERIAL_EVG_MATERIAL_VERS, string MATERIAL_EVG_MATERIAL_GUID,
            bool PERIOD_INDICATOR, bool GET_ITEM_DETAILS, bool GET_IND_LINES, bool GET_TOTAL_LINES, bool IGNORE_BUFFER)
        {
            DataSet ds = new DataSet();
            IRfcFunction rfcFunction = GetRfcFunction(FunName);

            #region Import parameters

            const string flagX = "X";

            rfcFunction.SetValue("MATERIAL", MaterialProcess(MATERIAL));
            rfcFunction.SetValue("PLANT", PLANT);
            rfcFunction.SetValue("MRP_AREA", MRP_AREA);
            rfcFunction.SetValue("PLAN_SCENARIO", PLAN_SCENARIO);
            rfcFunction.SetValue("SELECTION_RULE", SELECTION_RULE);
            rfcFunction.SetValue("DISPLAY_FILTER", DISPLAY_FILTER);
            rfcFunction.SetValue("PERIOD_INDICATOR", PERIOD_INDICATOR ? flagX : string.Empty);
            rfcFunction.SetValue("GET_ITEM_DETAILS", GET_ITEM_DETAILS ? flagX : string.Empty);
            rfcFunction.SetValue("GET_IND_LINES", GET_IND_LINES ? flagX : string.Empty);
            rfcFunction.SetValue("GET_TOTAL_LINES", GET_TOTAL_LINES ? flagX : string.Empty);
            rfcFunction.SetValue("IGNORE_BUFFER", IGNORE_BUFFER ? flagX : string.Empty);

            IRfcStructure MATERIAL_EVG = rfcFunction.GetStructure("MATERIAL_EVG");
            MATERIAL_EVG.SetValue("MATERIAL_EXT", MATERIAL_EVG_MATERIAL_EXT);
            MATERIAL_EVG.SetValue("MATERIAL_VERS", MATERIAL_EVG_MATERIAL_VERS);
            MATERIAL_EVG.SetValue("MATERIAL_GUID", MATERIAL_EVG_MATERIAL_GUID);

            #endregion

            rfcFunction.Invoke(Destination);

            #region Export parpmeters

            #region MRP_LIST
            {
                string tableName = "MRP_LIST";
                IRfcFunction iRfcFunction = rfcFunction;
                DataSet dataSet = ds;

                DataTable dataTable = GetFunctionStructureToDataTable(ref iRfcFunction, tableName);
                dataSet.Tables.Add(dataTable);
            }
            #endregion
            #region MRP_CONTROL_PARAM
            {
                string tableName = "MRP_CONTROL_PARAM";
                IRfcFunction iRfcFunction = rfcFunction;
                DataSet dataSet = ds;

                DataTable dataTable = GetFunctionStructureToDataTable(ref iRfcFunction, tableName);
                dataSet.Tables.Add(dataTable);
            }
            #endregion
            #region MRP_STOCK_DETAIL
            {
                string tableName = "MRP_STOCK_DETAIL";
                IRfcFunction iRfcFunction = rfcFunction;
                DataSet dataSet = ds;

                DataTable dataTable = GetFunctionStructureToDataTable(ref iRfcFunction, tableName);
                dataSet.Tables.Add(dataTable);
            }
            #endregion
            #region RETURN
            {
                string tableName = "RETURN";
                IRfcFunction iRfcFunction = rfcFunction;
                DataSet dataSet = ds;

                DataTable dataTable = GetFunctionStructureToDataTable(ref iRfcFunction, tableName);
                dataSet.Tables.Add(dataTable);
            }
            #endregion

            #endregion

            #region Tables

            #region MRP_ITEMS
            {
                string tableName = "MRP_ITEMS";
                IRfcFunction iRfcFunction = rfcFunction;
                DataSet dataSet = ds;

                DataTable dataTable = GetFunctionTableToDataTable(ref iRfcFunction, tableName);
                dataSet.Tables.Add(dataTable);
            }
            #endregion
            #region MRP_IND_LINES
            {
                string tableName = "MRP_IND_LINES";
                IRfcFunction iRfcFunction = rfcFunction;
                DataSet dataSet = ds;

                DataTable dataTable = GetFunctionTableToDataTable(ref iRfcFunction, tableName);
                dataSet.Tables.Add(dataTable);
            }
            #endregion
            #region MRP_TOTAL_LINES
            {
                string tableName = "MRP_TOTAL_LINES";
                IRfcFunction iRfcFunction = rfcFunction;
                DataSet dataSet = ds;

                DataTable dataTable = GetFunctionTableToDataTable(ref iRfcFunction, tableName);
                dataSet.Tables.Add(dataTable);
            }
            #endregion
            #region EXTENSIONOUT
            {
                string tableName = "EXTENSIONOUT";
                IRfcFunction iRfcFunction = rfcFunction;
                DataSet dataSet = ds;

                DataTable dataTable = GetFunctionTableToDataTable(ref iRfcFunction, tableName);
                dataSet.Tables.Add(dataTable);
            }
            #endregion

            #endregion

            return ds;
        }


        /// <summary>
        /// 需求查詢-仿照MD04方式
        /// </summary>
        /// <param name="material_no"></param>
        /// <param name="plant"></param>
        /// <param name="mrp_area"></param>
        /// <returns></returns>
        public DataTable Query_Like_MD04(string material_no, string plant,string mrp_area = "")
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Material NO");
            dataTable.Columns.Add("Date");
            dataTable.Columns.Add("MRP element");
            dataTable.Columns.Add("MRP element data");
            dataTable.Columns.Add("Exception");
            dataTable.Columns.Add("Receipt/Reqmt");
            dataTable.Columns.Add("Available Qty");
            dataTable.Columns.Add("Storage Location");

            dataTable.Columns.Add("ProdOrder");

            string MATERIAL = material_no;
            string PLANT = plant;
            string MRP_AREA = mrp_area;
            string PLAN_SCENARIO = string.Empty;
            string SELECTION_RULE = string.Empty;
            string DISPLAY_FILTER = string.Empty;
            string MATERIAL_EVG_MATERIAL_EXT = string.Empty;
            string MATERIAL_EVG_MATERIAL_VERS = string.Empty;
            string MATERIAL_EVG_MATERIAL_GUID = string.Empty;

            bool PERIOD_INDICATOR = false;
            bool GET_ITEM_DETAILS = true;
            bool GET_IND_LINES = true;
            bool GET_TOTAL_LINES = false;
            bool IGNORE_BUFFER = false;

            DataSet dataSet = Send(
                MATERIAL, PLANT, MRP_AREA, PLAN_SCENARIO, SELECTION_RULE, DISPLAY_FILTER, MATERIAL_EVG_MATERIAL_EXT, MATERIAL_EVG_MATERIAL_VERS,
                MATERIAL_EVG_MATERIAL_GUID, PERIOD_INDICATOR, GET_ITEM_DETAILS, GET_IND_LINES, GET_TOTAL_LINES, IGNORE_BUFFER);

            //const string MRP_IND_LINES = "MRP_IND_LINES";
            //const string MRP_ITEMS = "MRP_ITEMS";

            DataTable dataTable_MRP_IND_LINES = dataSet.Tables[MRP_IND_LINES];
            DataTable dataTable_MRP_ITEMS = dataSet.Tables[MRP_ITEMS];

            for (int i = 0; i < dataTable_MRP_IND_LINES.Rows.Count; i++)
            {
                DataRow row_MRP_IND_LINES = dataTable_MRP_IND_LINES.Rows[i];
                string Date = row_MRP_IND_LINES["AVAIL_DATE"].ToString();
                string MRP_element = row_MRP_IND_LINES["MRP_ELEMNT"].ToString();
                string MRP_element_data = row_MRP_IND_LINES["ELEMNT_DATA"].ToString();
                string Exception = row_MRP_IND_LINES["EXCMESSAGE"].ToString();
                string Receipt_Reqmt = row_MRP_IND_LINES["REC_REQD_QTY"].ToString();
                string Available_Qty = row_MRP_IND_LINES["AVAIL_QTY1"].ToString();
                string Storage_Location = row_MRP_IND_LINES["STORAGE_LOC"].ToString();

                //對應dataTable_MRP_ITEMS的index
                int Int_Table_Ind1 = int.Parse(row_MRP_IND_LINES["INT_TABLE_IND1"].ToString());

                DataRow row_MRP_ITEMS = dataTable_MRP_ITEMS.Rows[Int_Table_Ind1 - 1];
                string ProdOrder = row_MRP_ITEMS["MRP_NO12"].ToString();

                dataTable.Rows.Add(
                    material_no,
                    Date,
                    MRP_element,
                    MRP_element_data,
                    Exception,
                    Receipt_Reqmt,
                    Available_Qty,
                    Storage_Location,

                    ProdOrder
                    );
            }

            return dataTable;
        }


        /// <summary>
        /// 縮減參數
        /// </summary>
        /// <param name="MATERIAL"></param>
        /// <param name="PLANT"></param>
        /// <param name="PERIOD_INDICATOR"></param>
        /// <param name="GET_ITEM_DETAILS"></param>
        /// <param name="GET_IND_LINES"></param>
        /// <param name="GET_TOTAL_LINES"></param>
        /// <param name="IGNORE_BUFFER"></param>
        /// <returns></returns>
        public DataSet Send(string MATERIAL, string PLANT,
            bool PERIOD_INDICATOR, bool GET_ITEM_DETAILS, bool GET_IND_LINES, bool GET_TOTAL_LINES, bool IGNORE_BUFFER)
        {
            return Send(MATERIAL, PLANT,
                string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                PERIOD_INDICATOR,
                GET_ITEM_DETAILS,
                GET_IND_LINES,
                GET_TOTAL_LINES,
                IGNORE_BUFFER
                );
        }

        /// <summary>
        /// 查詢STO需求
        /// </summary>
        /// <param name="MATERIAL"></param>
        /// <param name="PLANT"></param>
        /// <returns>DataTable</returns>
        public DataTable QuerySTO(string MATERIAL, string PLANT)
        {
            string tableName = MRP_IND_LINES;
            string[] columns = new string[] { AVAIL_DATE, MRP_ELEMNT, ELEMNT_DATA, REC_REQD_QTY, PLAN_PLANT2 };
            string selectCol = MRP_ELEMNT;
            string checkMRP_ELEMNT = "Ord.DS";

            DataTable dt = new DataTable();
            DataTable resDT = dt.Clone();
            try
            {
                DataSet ds = Send(MATERIAL, PLANT, false, false, true, false, false);
                dt = ds.Tables[tableName];
                dt = dt.DefaultView.ToTable(false, columns);
                DataRow[] rows = dt.Select(selectCol + " = '" + checkMRP_ELEMNT + "'");
                if (rows.Length > 0)
                {
                    dt = rows.CopyToDataTable();
                }
                else
                {
                    dt.Clear();
                }
                resDT = dt.Clone();
                resDT.Columns[AVAIL_DATE].DataType = typeof(DateTime);
                foreach (DataRow row in rows)
                {
                    DateTime dAVAIL_DATE = DateTime.Parse(row[AVAIL_DATE].ToString());

                    string sMRP_ELEMNT = row[MRP_ELEMNT].ToString();
                    string sELEMNT_DATA = row[ELEMNT_DATA].ToString();

                    int iREC_REQD_QTY = (int)Math.Abs(float.Parse(row[REC_REQD_QTY].ToString()));
                    string sPLAN_PLANT2 = row[PLAN_PLANT2].ToString();

                    resDT.Rows.Add(dAVAIL_DATE, sMRP_ELEMNT, sELEMNT_DATA, iREC_REQD_QTY, sPLAN_PLANT2);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return resDT;
        }

        /// <summary>
        /// 查詢工單需求
        /// </summary>
        /// <param name="MATERIAL"></param>
        /// <param name="PLANT"></param>
        /// <returns>DataTable</returns>
        public DataTable QueryWIP(string MATERIAL, string PLANT)
        {
            string tableName = MRP_ITEMS;
            string[] columns = { AVAIL_DATE, REC_REQD_QTY, MRP_NO12 };
            string selectCol = MRP_ELEMENT_IND;
            string checkMRP_ELEMNT = "AR";

            DataTable dt = new DataTable();
            DataTable resDT = dt.Clone();
            try
            {
                DataSet ds = Send(MATERIAL, PLANT, false, true, false, false, false);
                dt = ds.Tables[tableName];
                DataRow[] rows = dt.Select(selectCol + " = '" + checkMRP_ELEMNT + "'");
                if (rows.Length > 0)
                {
                    dt = rows.CopyToDataTable();
                }
                else
                {
                    dt.Clear();
                }
                dt = dt.DefaultView.ToTable(false, columns);
                resDT = dt.Clone();
                resDT.Columns[AVAIL_DATE].DataType = typeof(DateTime);
                foreach (DataRow row in dt.Rows)
                {
                    DateTime dAVAIL_DATE = DateTime.Parse(row[AVAIL_DATE].ToString());

                    int iREC_REQD_QTY = (int)Math.Abs(float.Parse(row[REC_REQD_QTY].ToString()));
                    string WipNO = row[MRP_NO12].ToString();

                    resDT.Rows.Add(dAVAIL_DATE, iREC_REQD_QTY, WipNO);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return resDT;
        }

    }
}
