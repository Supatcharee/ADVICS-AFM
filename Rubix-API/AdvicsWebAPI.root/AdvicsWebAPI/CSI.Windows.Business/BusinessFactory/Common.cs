using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using CSI.Business;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;

namespace CSI.Business
{
    public class BusinessCommon
    {
        #region Member
        private CommonModelContainer commonconnection = null;
        private AdminModelContainer adminConnection = null;
        private MasterConnection masterConnection = null;

        //private ReceivingModelContainer receivingConnection = null;
        //private ShippingModelContainer shippingConnection = null;
        //private StockModelContainer stockConnection = null;
        //private PickingModelContainer pickingConnection = null;

        private ReportModelContainer reportConnection = null;
        

        private O_BC_ReceivingModelContainer _ReceivingConnection = null;
        private O_D_TransitModelContainer _TransitConnection = null;
        private O_E_StockModelContainer _StockConnection = null;
        private O_FGIJ_ShippingModelContainer _ShippingConnection = null;
        private O_H_PickingModelContainer _PickingConnection = null;
        private O_ML_HistoryViewModelContainer _HistoryViewConnection = null;
        private O_R_OrderModelContainer _OrderConnection = null;

        private readonly static BusinessCommon _bc = new BusinessCommon();
        #endregion

        #region Properties
        public CommonModelContainer CommonEntity
        {
            get
            {
                if (commonconnection == null)
                    commonconnection = Database.CommonContext;
                return commonconnection;
            }
        }

        public AdminModelContainer AdminEntity
        {
            get
            {
                if (adminConnection == null)
                    adminConnection = Database.AdminContext;
                return adminConnection;
            }
        }

        public MasterConnection MasterEntity
        {
            get
            {
                if (masterConnection == null)
                    masterConnection = Database.MasterContext;
                return masterConnection;
            }
        }

        public O_BC_ReceivingModelContainer ReceivingEntity
        {
            get
            {
                if (_ReceivingConnection == null)
                    _ReceivingConnection = Database.ReceivingContext;
                return _ReceivingConnection;
            }
        }
        public O_D_TransitModelContainer TransitEntity
        {
            get
            {
                if (_TransitConnection == null)
                    _TransitConnection = Database.TransitContext;
                return _TransitConnection;
            }
        }
        public O_E_StockModelContainer StockEntity
        {
            get
            {
                if (_StockConnection == null)
                    _StockConnection = Database.StockContext;
                return _StockConnection;
            }
        }
        public O_FGIJ_ShippingModelContainer ShippingEntity
        {
            get
            {
                if (_ShippingConnection == null)
                    _ShippingConnection = Database.ShippingContext;
                return _ShippingConnection;
            }
        }
        public O_H_PickingModelContainer PickingEntity
        {
            get
            {
                if (_PickingConnection == null)
                    _PickingConnection = Database.PickingContext;
                return _PickingConnection;
            }
        }
        public O_ML_HistoryViewModelContainer HistoryViewEntity
        {
            get
            {
                if (_HistoryViewConnection == null)
                    _HistoryViewConnection = Database.HistoryViewContext;
                return _HistoryViewConnection;
            }
        }
        public O_R_OrderModelContainer OrderEntity
        {
            get
            {
                if (_OrderConnection == null)
                    _OrderConnection = Database.OrderContext;
                return _OrderConnection;
            }
        }

        public ReportModelContainer ReportEntity
        {
            get
            {
                if (reportConnection == null)
                    reportConnection = Database.ReportContext;
                return reportConnection;
            }
        }
        
        #endregion
        
        #region ExecuteNonQuery
        public int ExecuteNonQuery(String StoreProcudureName)
        {
            return Database.ExecuteNonQuery(StoreProcudureName);
        }

        public int ExecuteNonQuery(String StoreProcudureName, ref Hashtable objHastableOutput)
        {
            return Database.ExecuteNonQuery(StoreProcudureName, ref objHastableOutput);
        }

        public int ExecuteNonQuery(String StoreProcudureName, Hashtable objHastable, ref Hashtable objHastableOutput)
        {
            return Database.ExecuteNonQuery(StoreProcudureName, objHastable, ref objHastableOutput);
        }

        public int ExecuteNonQuery(String StoreProcudureName, Hashtable objHastable)
        {
            return Database.ExecuteNonQuery(StoreProcudureName, objHastable);
        }

        #endregion

        #region ExecuteDataSet
        public DataSet ExecuteDataSet(String ProcedureName)
        {
            return Database.ExecuteDataSet(ProcedureName);
        }

        public DataSet ExecuteDataSet(String StoreProcudureName, ref Hashtable objHastableOutput)
        {
            return Database.ExecuteDataSet(StoreProcudureName, ref objHastableOutput);
        }

        public DataSet ExecuteDataSet(String StoreProcudureName, Hashtable objHastable, ref Hashtable objHastableOutput)
        {
            return Database.ExecuteDataSet(StoreProcudureName, objHastable, ref objHastableOutput);
        }

        public DataSet ExecuteDataSet(String StoreProcudureName, Hashtable objHastable)
        {
            return Database.ExecuteDataSet(StoreProcudureName, objHastable);
        }
        #endregion

        #region ExecuteReader
        public SqlDataReader ExecuteReader(String ProcedureName)
        {
            return Database.ExecuteReader(ProcedureName);
        }

        public SqlDataReader ExecuteReader(String ProcedureName, Hashtable objHastable)
        {
            return Database.ExecuteReader(ProcedureName, objHastable);
        }
        #endregion

        #region ExecuteScalar
        public object ExecuteScalar(String ProcedureName)
        {
            return Database.ExecuteScalar(ProcedureName);
        }

        public object ExecuteScalar(String ProcedureName, Hashtable objHastable)
        {
            return Database.ExecuteScalar(ProcedureName, objHastable);
        }
        #endregion
        
        public DataTable LastestDailyPost()
        {
            return ExecuteDataSet("sp_MAIN000_LASTEST_DAILY_POST").Tables[0];
        }
    }
}

