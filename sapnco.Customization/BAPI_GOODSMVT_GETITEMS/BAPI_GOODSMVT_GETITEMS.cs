using System.Data;

using SAP.Middleware.Connector;

using static sapnco.Customization.BAPI_GOODSMVT_GETITEMS.BAPI_GOODSMVT_GETITEMS.ReturnTables;

namespace sapnco.Customization.BAPI_GOODSMVT_GETITEMS
{
    public class BAPI_GOODSMVT_GETITEMS : RFC_FunctionBase
    {
        //函式名稱
        public const string sFuncName = "BAPI_GOODSMVT_GETITEMS";

        //回傳表格名稱
        public class ReturnTables
        {
            public const string sGOODSMVT_HEADER = "GOODSMVT_HEADER";
            public const string sGOODSMVT_ITEMS = "GOODSMVT_ITEMS";
            public const string sRETURN = "RETURN";

            /// <summary>
            /// 共用欄位,聯繫資料
            /// </summary>
            public class SharedFields
            {
                /// <summary>
                /// MAT_DOC EX:4900281662
                /// </summary>
                public const string sMAT_DOC = "MAT_DOC";
                /// <summary>
                /// DOC_YEAR EX:2019
                /// </summary>
                public const string sDOC_YEAR = "DOC_YEAR";
            }

            public class GOODSMVT_HEADER
            {

            }
        }

        #region GOODSMVT_HEADER欄位
        /// <summary>
        /// TR_EV_TYPE EX:WQ
        /// </summary>
        public const string sTR_EV_TYPE = "TR_EV_TYPE";
        /// <summary>
        /// DOC_DATE EX:2019/02/21
        /// </summary>
        public const string sDOC_DATE = "DOC_DATE";
        /// <summary>
        /// PSTNG_DATE EX:2019/02/21
        /// </summary>
        public const string sPSTNG_DATE = "PSTNG_DATE";
        /// <summary>
        /// ENTRY_DATE EX:2019/02/21
        /// </summary>
        public const string sENTRY_DATE = "ENTRY_DATE";
        /// <summary>
        /// ENTRY_TIME EX:08:49:50
        /// </summary>
        public const string sENTRY_TIME = "ENTRY_TIME";
        /// <summary>
        /// USERNAME EX:B2BAKMC
        /// </summary>
        public const string sUSERNAME = "USERNAME";
        /// <summary>
        /// VER_GR_GI_SLIP EX:1
        /// </summary>
        public const string sVER_GR_GI_SLIP = "VER_GR_GI_SLIP";
        public const string sEXPIMP_NO = "EXPIMP_NO";
        public const string sREF_DOC_NO = "REF_DOC_NO";
        public const string sHEADER_TXT = "HEADER_TXT";
        public const string sREF_DOC_NO_LONG = "REF_DOC_NO_LONG";
        #endregion

        #region GOODSMVT_ITEMS欄位
        /// <summary>
        /// MAT_DOC_ITM EX:0001
        /// </summary>
        public const string sMATDOC_ITM = "MATDOC_ITM";
        /// <summary>
        /// MATERIAL EX:1654013582-01
        /// </summary>
        public const string sMATERIAL = "MATERIAL";
        /// <summary>
        /// PLANT EX:TWM8
        /// </summary>
        public const string sPLANT = "PLANT";
        /// <summary>
        /// STEG_LOC EX:0015
        /// </summary>
        public const string sSTGE_LOC = "STGE_LOC";
        public const string sBATCH = "BATCH";
        /// <summary>
        /// MOVE_TYPE EX:321
        /// </summary>
        public const string sMOVE_TYPE = "MOVE_TYPE";
        public const string sSTCK_TYPE = "STCK_TYPE";
        public const string sSPEC_STOCK = "SPEC_STOCK";
        /// <summary>
        /// VENDOR EX:T86731791
        /// </summary>
        public const string sVENDOR = "VENDOR";
        public const string sCUSTOMER = "CUSTOMER";
        public const string sSALES_ORD = "SALES_ORD";
        /// <summary>
        /// S_ORD_ITEM EX:000000
        /// </summary>
        public const string sS_ORD_ITEM = "S_ORD_ITEM";
        /// <summary>
        /// SCHED_LINE EX:0000
        /// </summary>
        public const string sSCHED_LINE = "SCHED_LINE";
        public const string sVAL_TYPE = "VAL_TYPE";
        /// <summary>
        /// ENTRY_QNT EX:700.000
        /// </summary>
        public const string sENTRY_QNT = "ENTRY_QNT";
        /// <summary>
        /// ENTRY_UOM EX:PC
        /// </summary>
        public const string sENTRY_UOM = "ENTRY_UOM";
        /// <summary>
        /// ENTRY_UOM_ISO EX:C62
        /// </summary>
        public const string sENTRY_UOM_ISO = "ENTRY_UOM_ISO";
        /// <summary>
        /// PO_PR_QNT EX:0.000
        /// </summary>
        public const string sPO_PR_QNT = "PO_PR_QNT";
        public const string sORDERPR_UN = "ORDERPR_UN";
        public const string sORDERPR_UN_ISO = "ORDERPR_UN_ISO";
        /// <summary>
        /// PO_NUMBER EX:11083334
        /// </summary>
        public const string sPO_NUMBER = "PO_NUMBER";
        /// <summary>
        /// PO_ITEM EX:00001
        /// </summary>
        public const string sPO_ITEM = "PO_ITEM";
        public const string sSHIPPING = "SHIPPING";
        public const string sCOMP_SHIP = "COMP_SHIP";
        public const string sNO_MOVE_GR = "NO_MOVE_GR";
        public const string sITEM_TEXT = "ITEM_TEXT";
        public const string sGR_RCPT = "GR_RCPT";
        public const string sUNLOAD_PT = "UNLOAD_PT";
        public const string sCOSTCENTER = "COSTCENTER";
        /// <summary>
        /// ORDERID EX:LDJD609KA
        /// </summary>
        public const string sORDERID = "ORDERID";
        /// <summary>
        /// ORDER_ITNO EX:0000
        /// </summary>
        public const string sORDER_ITNO = "ORDER_ITNO";
        public const string sCALC_MOTIVE = "CALC_MOTIVE";
        public const string sASSET_NO = "ASSET_NO";
        public const string sSUB_NUMBER = "SUB_NUMBER";
        /// <summary>
        /// RESERV_NO EX:0000000000
        /// </summary>
        public const string sRESERV_NO = "RESERV_NO";
        /// <summary>
        /// RES_ITEM EX:0000
        /// </summary>
        public const string sRES_ITEM = "RES_ITEM";
        public const string sRES_TYPE = "RES_TYPE";
        public const string sWITHDRAWN = "WITHDRAWN";
        /// <summary>
        /// MOVE_MAT EX:1654013582-01
        /// </summary>
        public const string sMOVE_MAT = "MOVE_MAT";
        /// <summary>
        /// MOVE_PLANT EX:TWM8
        /// </summary>
        public const string sMOVE_PLANT = "MOVE_PLANT";
        /// <summary>
        /// MOVE_STLOC EX:0015
        /// </summary>
        public const string sMOVE_STLOC = "MOVE_STLOC";
        public const string sMOVE_BATCH = "MOVE_BATCH";
        public const string sMOVE_VAL_TYPE = "MOVE_VAL_TYPE";
        public const string sMVT_IND = "MVT_IND";
        /// <summary>
        /// MOVE_REAS EX:0000
        /// </summary>
        public const string sMOVE_REAS = "MOVE_REAS";
        public const string sRL_EST_KEY = "RL_EST_KEY";
        public const string sREF_DATE = "REF_DATE";
        public const string sCOST_OBJ = "COST_OBJ";
        /// <summary>
        /// PROFIT_SEGM_NO EX:0000000000
        /// </summary>
        public const string sPROFIT_SEGM_NO = "PROFIT_SEGM_NO";
        /// <summary>
        /// PROFIT_CTR EX:CAPS
        /// </summary>
        public const string sPROFIT_CTR = "PROFIT_CTR";
        public const string sWBS_ELEM = "WBS_ELEM";
        public const string sNETWORK = "NETWORK";
        public const string sACTIVITY = "ACTIVITY";
        public const string sPART_ACCT = "PART_ACCT";
        /// <summary>
        /// AMOUNT_LC EX:0.0000
        /// </summary>
        public const string sAMOUNT_LC = "AMOUNT_LC";
        /// <summary>
        /// AMOUNT_SV EX:0.0000
        /// </summary>
        public const string sAMOUNT_SV = "AMOUNT_SV";
        /// <summary>
        /// CURRENCY EX:TWD
        /// </summary>
        public const string sCURRENCY = "CURRENCY";
        /// <summary>
        /// CURRENCY_ISO EX:TWD
        /// </summary>
        public const string sCURRENCY_ISO = "CURRENCY_ISO";
        public const string sREF_DOC_YR = "REF_DOC_YR";
        public const string sREF_DOC = "REF_DOC";
        /// <summary>
        /// REF_DOC_IT EX:0000
        /// </summary>
        public const string sREF_DOC_IT = "REF_DOC_IT";
        public const string sEXPIRYDATE = "EXPIRYDATE";
        public const string sPROD_DATE = "PROD_DATE";
        public const string sFUND = "FUND";
        public const string sFUNDS_CTR = "FUNDS_CTR";
        public const string sCMMT_ITEM = "CMMT_ITEM";
        public const string sVAL_SALES_ORD = "VAL_SALES_ORD";
        /// <summary>
        /// VAL_S_ORD_ITEM EX:000000
        /// </summary>
        public const string sVAL_S_ORD_ITEM = "VAL_S_ORD_ITEM";
        public const string sVAL_WBS_ELEM = "VAL_WBS_ELEM";
        public const string sCO_BUSPROC = "CO_BUSPROC";
        public const string sACTTYPE = "ACTTYPE";
        public const string sSUPPL_VEND = "SUPPL_VEND";
        /// <summary>
        /// X_AUTO_CRE EX:X
        /// </summary>
        public const string sX_AUTO_CRE = "X_AUTO_CRE";
        public const string sMATERIAL_EXTERNAL = "MATERIAL_EXTERNAL";
        public const string sMATERIAL_GUID = "MATERIAL_GUID";
        public const string sMATERIAL_VERSION = "MATERIAL_VERSION";
        public const string sMOVE_EXTERNAL = "MOVE_EXTERNAL";
        public const string sMOVE_GUID = "MOVE_GUID";
        public const string sMOVE_VERSION = "MOVE_VERSION";
        public const string sGRANT_NBR = "GRANT_NBR";
        public const string sCMMT_ITEM_LONG = "CMMT_ITEM_LONG";
        public const string sFUNC_AREA_LONG = "FUNC_AREA_LONG";
        /// <summary>
        /// LINE_ID EX:000001
        /// </summary>
        public const string sLINE_ID = "LINE_ID";
        /// <summary>
        /// PARENT_ID EX:000000
        /// </summary>
        public const string sPARENT_ID = "PARENT_ID";
        /// <summary>
        /// LINE_DEPTH EX:00
        /// </summary>
        public const string sLINE_DEPTH = "LINE_DEPTH";
        public const string sBUDGET_PERIOD = "BUDGET_PERIOD";
        public const string sEARMARKED_NUMBER = "EARMARKED_NUMBER";
        /// <summary>
        /// EARMARKED_ITEM EX:000
        /// </summary>
        public const string sEARMARKED_ITEM = "EARMARKED_ITEM";
        #endregion


        protected override string FunName => sFuncName;
        public BAPI_GOODSMVT_GETITEMS(SAP_RFC_ConnectBase conn) : base(conn) { }

        public DataSet Send(
            ParameterRange mATERIAL_RA,
            ParameterRange pLANT_RA,
            ParameterRange sTGE_LOC_RA,
            ParameterRange bATCH_RA,
            ParameterRange mOVE_TYPE_RA,
            ParameterRange sPEC_STOCK_RA,
            ParameterRange tR_EV_TYPE_RA,
            ParameterRange pSTNG_DATE_RA,
            ParameterRange vENDOR_RA,
            ParameterRange uSERNAME_RA,
            ParameterRange pURCH_DOC_RA
            )
        {
            const string FunName = sFuncName;

            const string sMATERIAL_RA = "MATERIAL_RA";
            const string sPLANT_RA = "PLANT_RA";
            const string sSTGE_LOC_RA = "STGE_LOC_RA";
            const string sBATCH_RA = "BATCH_RA";
            const string sMOVE_TYPE_RA = "MOVE_TYPE_RA";
            const string sSPEC_STOCK_RA = "SPEC_STOCK_RA";
            const string sTR_EV_TYPE_RA = "TR_EV_TYPE_RA";
            const string sPSTNG_DATE_RA = "PSTNG_DATE_RA";
            const string sVENDOR_RA = "VENDOR_RA";
            const string sUSERNAME_RA = "USERNAME_RA";
            const string sPURCH_DOC_RA = "PURCH_DOC_RA";

            DataSet dataSet = new DataSet();

            IRfcFunction fun = GetRfcFunction(FunName);

            MATERIAL_RA MATERIAL_RA_ = new MATERIAL_RA();
            MATERIAL_RA_.dataTable = mATERIAL_RA.dataTable;
            IRfcTable material_ra = fun.GetTable(sMATERIAL_RA);
            MATERIAL_RA_.ToRfcTable(ref material_ra);

            PLANT_RA PLANT_RA_ = new PLANT_RA();
            PLANT_RA_.dataTable = pLANT_RA.dataTable;
            IRfcTable plant_ra = fun.GetTable(sPLANT_RA);
            PLANT_RA_.ToRfcTable(ref plant_ra);

            STGE_LOC_RA STGE_LOC_RA_ = new STGE_LOC_RA();
            STGE_LOC_RA_.dataTable = sTGE_LOC_RA.dataTable;
            IRfcTable stge_loc_ra = fun.GetTable(sSTGE_LOC_RA);
            STGE_LOC_RA_.ToRfcTable(ref stge_loc_ra);

            BATCH_RA BATCH_RA_ = new BATCH_RA();
            BATCH_RA_.dataTable = bATCH_RA.dataTable;
            IRfcTable batch_ra = fun.GetTable(sBATCH_RA);
            BATCH_RA_.ToRfcTable(ref batch_ra);

            MOVE_TYPE_RA MOVE_TYPE_RA_ = new MOVE_TYPE_RA();
            MOVE_TYPE_RA_.dataTable = mOVE_TYPE_RA.dataTable;
            IRfcTable move_type_ra = fun.GetTable(sMOVE_TYPE_RA);
            MOVE_TYPE_RA_.ToRfcTable(ref move_type_ra);

            SPEC_STOCK_RA SPEC_STOCK_RA_ = new SPEC_STOCK_RA();
            SPEC_STOCK_RA_.dataTable = sPEC_STOCK_RA.dataTable;
            IRfcTable spec_stock_ra = fun.GetTable(sSPEC_STOCK_RA);
            SPEC_STOCK_RA_.ToRfcTable(ref spec_stock_ra);

            TR_EV_TYPE_RA TR_EV_TYPE_RA_ = new TR_EV_TYPE_RA();
            TR_EV_TYPE_RA_.dataTable = tR_EV_TYPE_RA.dataTable;
            IRfcTable tr_ev_type_ra = fun.GetTable(sTR_EV_TYPE_RA);
            TR_EV_TYPE_RA_.ToRfcTable(ref tr_ev_type_ra);

            PSTNG_DATE_RA PSTNG_DATE_RA_ = new PSTNG_DATE_RA();
            PSTNG_DATE_RA_.dataTable = pSTNG_DATE_RA.dataTable;
            IRfcTable psting_date_ra = fun.GetTable(sPSTNG_DATE_RA);
            PSTNG_DATE_RA_.ToRfcTable(ref psting_date_ra);

            VENDOR_RA VENDOR_RA_ = new VENDOR_RA();
            VENDOR_RA_.dataTable = vENDOR_RA.dataTable;
            IRfcTable vendor_ra = fun.GetTable(sVENDOR_RA);
            VENDOR_RA_.ToRfcTable(ref vendor_ra);

            USERNAME_RA USERNAME_RA_ = new USERNAME_RA();
            USERNAME_RA_.dataTable = uSERNAME_RA.dataTable;
            IRfcTable username_ra = fun.GetTable(sUSERNAME_RA);
            USERNAME_RA_.ToRfcTable(ref username_ra);

            PURCH_DOC_RA PURCH_DOC_RA_ = new PURCH_DOC_RA();
            PURCH_DOC_RA_.dataTable = pURCH_DOC_RA.dataTable;
            IRfcTable purch_doc_ra = fun.GetTable(sPURCH_DOC_RA);
            PURCH_DOC_RA_.ToRfcTable(ref purch_doc_ra);

            fun.Invoke(Destination);

            IRfcTable GOODSMVT_HEADER = fun.GetTable(sGOODSMVT_HEADER);
            DataTable dataTable_GOODSMVT_HEADER = RfcTableToDataTable(GOODSMVT_HEADER);
            dataTable_GOODSMVT_HEADER.TableName = sGOODSMVT_HEADER;
            dataSet.Tables.Add(dataTable_GOODSMVT_HEADER);

            IRfcTable GOODSMVT_ITEMS = fun.GetTable(sGOODSMVT_ITEMS);
            DataTable dataTable_GOODSMVT_ITEMS = RfcTableToDataTable(GOODSMVT_ITEMS);
            dataTable_GOODSMVT_ITEMS.TableName = sGOODSMVT_ITEMS;
            dataSet.Tables.Add(dataTable_GOODSMVT_ITEMS);

            IRfcTable RETURN = fun.GetTable(sRETURN);
            DataTable dataTable_RETURN = RfcTableToDataTable(RETURN);
            dataTable_RETURN.TableName = sRETURN;
            dataSet.Tables.Add(dataTable_RETURN);

            return dataSet;
        }
    }
}
