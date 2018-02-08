using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace CSI.Business
{
    public class Database : IDisposable
    {
        #region Member
        private static DatabaseConnection _DatabaseConnection = null;
        private static ReportModelContainer _reportEntity = null; //= new ReportModelContainer(DatabaseConfig.GetEntityConnectionString("DataObjects.ReportModel"));
        private static MasterConnection _masterEntity;
        private static AdminModelContainer _adminEntiy;
        private static CommonModelContainer _commonEntity;
        private static O_BC_ReceivingModelContainer _receivingEntity;
        private static O_D_TransitModelContainer _transitEntity;
        private static O_E_StockModelContainer _stockEntity;
        private static O_FGIJ_ShippingModelContainer _shippingEntity;
        private static O_H_PickingModelContainer _pickingEntity;
        private static O_ML_HistoryViewModelContainer _historyEntity;
        private static O_R_OrderModelContainer _orderEntity;

        private const int TIME_OUT = 300;
        #endregion
        
        #region Properties
        public static MasterConnection MasterContext
        {
            get
            {
                _masterEntity = null;
                _masterEntity = new MasterConnection(DatabaseConfig.GetEntityConnectionString("DataObjects.MasterModel"));
                _masterEntity.CommandTimeout = TIME_OUT;
                return _masterEntity;
            }
        }
        public static AdminModelContainer AdminContext
        {
            get
            {
                _adminEntiy = null;
                _adminEntiy = new AdminModelContainer(DatabaseConfig.GetEntityConnectionString("DataObjects.AdminModel"));
                _adminEntiy.CommandTimeout = TIME_OUT;
                return _adminEntiy;
            }
        }
        public static CommonModelContainer CommonContext
        {
            get
            {
                _commonEntity = null;
                _commonEntity = new CommonModelContainer(DatabaseConfig.GetEntityConnectionString("DataObjects.CommonModel"));
                _commonEntity.CommandTimeout = TIME_OUT;
                return _commonEntity;
            }
        }
        public static ReportModelContainer ReportContext
        {
            get
            {
                _reportEntity = null;
                _reportEntity = new ReportModelContainer(DatabaseConfig.GetEntityConnectionString("DataObjects.ReportModel"));
                _reportEntity.CommandTimeout = TIME_OUT;
                return _reportEntity;
            }
        }
        public static O_BC_ReceivingModelContainer ReceivingContext
        {
            get
            {
                _receivingEntity = null;
                _receivingEntity = new O_BC_ReceivingModelContainer(DatabaseConfig.GetEntityConnectionString("DataObjects.O_BC_ReceivingModel"));
                _receivingEntity.CommandTimeout = TIME_OUT;
                return _receivingEntity;
            }
        }
        public static O_D_TransitModelContainer TransitContext
        {
            get
            {
                _transitEntity = null;
                _transitEntity = new O_D_TransitModelContainer(DatabaseConfig.GetEntityConnectionString("DataObjects.O_D_TransitModel"));
                _transitEntity.CommandTimeout = TIME_OUT;
                return _transitEntity;
            }
        }
        public static O_E_StockModelContainer StockContext
        {
            get
            {
                _stockEntity = null;
                _stockEntity = new O_E_StockModelContainer(DatabaseConfig.GetEntityConnectionString("DataObjects.O_E_StockModel"));
                _stockEntity.CommandTimeout = TIME_OUT;
                return _stockEntity;
            }
        }
        public static O_FGIJ_ShippingModelContainer ShippingContext
        {
            get
            {
                _shippingEntity = null;
                _shippingEntity = new O_FGIJ_ShippingModelContainer(DatabaseConfig.GetEntityConnectionString("DataObjects.O_FGIJ_ShippingModel"));
                _shippingEntity.CommandTimeout = TIME_OUT;
                return _shippingEntity;
            }
        }
        public static O_H_PickingModelContainer PickingContext
        {
            get
            {
                _pickingEntity = null;
                _pickingEntity = new O_H_PickingModelContainer(DatabaseConfig.GetEntityConnectionString("DataObjects.O_H_PickingModel"));
                _pickingEntity.CommandTimeout = TIME_OUT;
                return _pickingEntity;
            }
        }
        public static O_ML_HistoryViewModelContainer HistoryViewContext
        {
            get
            {
                _historyEntity = null;
                _historyEntity = new O_ML_HistoryViewModelContainer(DatabaseConfig.GetEntityConnectionString("DataObjects.O_ML_HistoryViewModel"));
                _historyEntity.CommandTimeout = TIME_OUT;
                return _historyEntity;
            }
        }
        public static O_R_OrderModelContainer OrderContext
        {
            get
            {
                _orderEntity = null;
                _orderEntity = new O_R_OrderModelContainer(DatabaseConfig.GetEntityConnectionString("DataObjects.O_R_OrderModel"));
                _orderEntity.CommandTimeout = TIME_OUT;
                return _orderEntity;
            }
        }

        private static DatabaseConnection DatabaseConfig
        {
            get
            {
                _DatabaseConnection = null;
                _DatabaseConnection = new DatabaseConnection();
                return _DatabaseConnection;
            }
            set
            {
                _DatabaseConnection = value;
            }
        }
        #endregion
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _reportEntity.Dispose();
                _reportEntity = null;
               
                _masterEntity.Dispose();
                _masterEntity = null;

                _adminEntiy.Dispose();
                _adminEntiy = null;

                _commonEntity.Dispose();
                _commonEntity = null;

                _receivingEntity.Dispose();
                _receivingEntity = null;

                _transitEntity.Dispose();
                _transitEntity = null;

                _stockEntity.Dispose();
                _stockEntity = null;

                _shippingEntity.Dispose();
                _shippingEntity = null;

                _pickingEntity.Dispose();
                _pickingEntity = null;

                _historyEntity.Dispose();
                _historyEntity = null;

                _orderEntity.Dispose();
                _orderEntity = null;

            }
        }
        ~Database()
        {
            Dispose(false);
        }

        #region ExecuteNonQuery
        public static int ExecuteNonQuery(String StoreProcudureName)
        {
            Exception eReturn = null;
            Hashtable objHastableOutput = null;
            try
            {
                return DatabaseConfig.ExecuteNonQuery(StoreProcudureName, null, ref objHastableOutput, ref eReturn);
            }
            catch (Exception ex)
            {
                throw eReturn;
            }
        }

        public static int ExecuteNonQuery(String StoreProcudureName, ref Hashtable objHastableOutput)
        {
            Exception eReturn = null;
            try
            {
                return DatabaseConfig.ExecuteNonQuery(StoreProcudureName, null, ref objHastableOutput, ref eReturn);
            }
            catch (Exception ex)
            {
                throw eReturn;
            }
        }

        public static int ExecuteNonQuery(String StoreProcudureName, Hashtable objHastable, ref Hashtable objHastableOutput)
        {
            Exception eReturn = null;
            try
            {
                return DatabaseConfig.ExecuteNonQuery(StoreProcudureName, objHastable, ref objHastableOutput, ref eReturn);
            }
            catch (Exception ex)
            {
                throw eReturn;
            }
        }

        public static int ExecuteNonQuery(String StoreProcudureName, Hashtable objHastable)
        {
            Exception eReturn = null;
            Hashtable objHastableOutput = null;
            try
            {
                return DatabaseConfig.ExecuteNonQuery(StoreProcudureName, objHastable, ref objHastableOutput, ref eReturn);
            }
            catch (Exception ex)
            {
                throw eReturn;
            }
        }
        #endregion

        #region ExecuteDataSet
        public static DataSet ExecuteDataSet(String ProcedureName)
        {
            Exception eReturn = null;
            Hashtable objHastableOutput = null;
            try
            {
                return DatabaseConfig.ExecuteDataSet(ProcedureName, null, ref objHastableOutput, ref eReturn);
            }
            catch (Exception ex)
            {
                throw eReturn;
            }
        }

        public static DataSet ExecuteDataSet(String StoreProcudureName, ref Hashtable objHastableOutput)
        {
            Exception eReturn = null;
            try
            {
                return DatabaseConfig.ExecuteDataSet(StoreProcudureName, null, ref objHastableOutput, ref eReturn);
            }
            catch (Exception ex)
            {
                throw eReturn;
            }
        }

        public static DataSet ExecuteDataSet(String StoreProcudureName, Hashtable objHastable, ref Hashtable objHastableOutput)
        {
            Exception eReturn = null;
            try
            {
                return DatabaseConfig.ExecuteDataSet(StoreProcudureName, objHastable, ref objHastableOutput, ref eReturn);
            }
            catch (Exception ex)
            {
                throw eReturn;
            }
        }

        public static DataSet ExecuteDataSet(String ProcedureName, Hashtable objHastable)
        {
            Exception eReturn = null;
            Hashtable objHastableOutput = null;
            try
            {
                return DatabaseConfig.ExecuteDataSet(ProcedureName, objHastable, ref objHastableOutput, ref eReturn);
            }
            catch (Exception ex)
            {
                throw eReturn;
            }
        }
        #endregion

        #region ExecuteReader
        public static SqlDataReader ExecuteReader(String ProcedureName)
        {
            Exception eReturn = null;
            try
            {
                return DatabaseConfig.ExecuteReader(ProcedureName, null, ref eReturn);
            }
            catch (Exception ex)
            {
                throw eReturn;
            }
        }

        public static SqlDataReader ExecuteReader(String ProcedureName, Hashtable objHastable)
        {
            Exception eReturn = null;
            try
            {
                return DatabaseConfig.ExecuteReader(ProcedureName, objHastable, ref eReturn);
            }
            catch (Exception ex)
            {
                throw eReturn;
            }
        }
        #endregion

        #region ExecuteScalar
        public static object ExecuteScalar(String ProcedureName)
        {
            Exception eReturn = null;
            try
            {
                return DatabaseConfig.ExecuteScalar(ProcedureName, null, ref eReturn);
            }
            catch (Exception ex)
            {
                throw eReturn;
            }
        }

        public static object ExecuteScalar(String ProcedureName, Hashtable objHastable)
        {
            Exception eReturn = null;
            try
            {
                return DatabaseConfig.ExecuteScalar(ProcedureName, objHastable, ref eReturn);
            }
            catch (Exception ex)
            {
                throw eReturn;
            }
        }
        #endregion
                
        public static DateTime GetSystemDate()
        {
            return Database.MasterContext.ExecuteStoreQuery<DateTime>("Select GetDate()").First();
        }

        public static DateTime GetEndDateOfCurrentMonth()
        {
            return Database.MasterContext.ExecuteStoreQuery<DateTime>("Select  Cast(dateadd(day, -DAY(getdate()),dateadd(month, 1, GETDATE())) as date)").First();
        }

        public static DateTime GetFirstDateOfCurrentMonth()
        {
            return Database.MasterContext.ExecuteStoreQuery<DateTime>("select cast(dateadd(day, -DAY(getdate()) +1, GETDATE()) as DATE)").First();
        }
    }
}
