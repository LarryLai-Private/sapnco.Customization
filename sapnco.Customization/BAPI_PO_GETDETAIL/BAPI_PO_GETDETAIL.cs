using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using SAP.Middleware.Connector;

namespace sapnco.Customization.BAPI_PO_GETDETAIL
{
    /// <summary>
    /// 查PO
    /// </summary>
    public class BAPI_PO_GETDETAIL : RFC_FunctionBase
    {
        protected override string FunName { get { return "BAPI_PO_GETDETAIL"; } }
        public BAPI_PO_GETDETAIL(SAP_RFC_ConnectBase conn) : base(conn) { }

        /// <summary>
        /// BAPI_PO_GETDETAIL-取得PO資料
        /// </summary>
        /// <param name="PURCHASEORDER"></param>
        /// <param name="ITEMS"></param>
        /// <param name="ACCOUNT_ASSIGNMENT"></param>
        /// <param name="SCHEDULES"></param>
        /// <param name="HISTORY"></param>
        /// <param name="ITEM_TEXTS"></param>
        /// <param name="HEADER_TEXTS"></param>
        /// <param name="SERVICES"></param>
        /// <param name="CONFIRMATIONS"></param>
        /// <param name="SERVICES_TEXTS"></param>
        /// <param name="EXTENSIONS"></param>
        /// <returns></returns>
        public DataSet Send(string PURCHASEORDER, bool ITEMS = true
            , bool ACCOUNT_ASSIGNMENT = false, bool SCHEDULES = false, bool HISTORY = false
            , bool ITEM_TEXTS = false, bool HEADER_TEXTS = false, bool SERVICES = false
            , bool CONFIRMATIONS = false, bool SERVICE_TEXTS = false, bool EXTENSIONS = false
            )
        {
            const string X = "X";

            DataSet ds = new DataSet();

            //PO處理
            PURCHASEORDER = ValueProcess(PURCHASEORDER, 10);

            IRfcFunction rfcFunction = GetRfcFunction(FunName);
            rfcFunction.SetValue("PURCHASEORDER", PURCHASEORDER);

            rfcFunction.SetValue("ITEMS", ITEMS ? X : string.Empty);

            rfcFunction.SetValue("ACCOUNT_ASSIGNMENT", ACCOUNT_ASSIGNMENT ? X : string.Empty);
            rfcFunction.SetValue("SCHEDULES", SCHEDULES ? X : string.Empty);
            rfcFunction.SetValue("HISTORY", HISTORY ? X : string.Empty);
            rfcFunction.SetValue("ITEM_TEXTS", ITEM_TEXTS ? X : string.Empty);
            rfcFunction.SetValue("HEADER_TEXTS", HEADER_TEXTS ? X : string.Empty);
            rfcFunction.SetValue("SERVICES", SERVICES ? X : string.Empty);
            rfcFunction.SetValue("CONFIRMATIONS", CONFIRMATIONS ? X : string.Empty);
            rfcFunction.SetValue("SERVICE_TEXTS", SERVICE_TEXTS ? X : string.Empty);
            rfcFunction.SetValue("EXTENSIONS", EXTENSIONS ? X : string.Empty);

            rfcFunction.Invoke(Destination);

            IRfcStructure PO_HEADER = rfcFunction.GetStructure("PO_HEADER");
            DataTable dtPO_HEADER = RfcStructureToDataTable(PO_HEADER);
            dtPO_HEADER.TableName = "PO_HEADER";
            ds.Tables.Add(dtPO_HEADER);

            IRfcStructure PO_ADDRESS = rfcFunction.GetStructure("PO_ADDRESS");
            DataTable dtPO_ADDRESS = RfcStructureToDataTable(PO_ADDRESS);
            dtPO_ADDRESS.TableName = "PO_ADDRESS";
            ds.Tables.Add(dtPO_ADDRESS);


            IRfcTable PO_ITEMS = rfcFunction.GetTable("PO_ITEMS");
            DataTable dtPO_ITEMS = RfcTableToDataTable(PO_ITEMS);
            dtPO_ITEMS.TableName = "PO_ITEMS";
            ds.Tables.Add(dtPO_ITEMS);


            IRfcTable RETURN = rfcFunction.GetTable("RETURN");
            DataTable dtRETURN = RfcTableToDataTable(RETURN);
            dtRETURN.TableName = "RETURN";
            ds.Tables.Add(dtRETURN);

            return ds;
        }
    }
}
