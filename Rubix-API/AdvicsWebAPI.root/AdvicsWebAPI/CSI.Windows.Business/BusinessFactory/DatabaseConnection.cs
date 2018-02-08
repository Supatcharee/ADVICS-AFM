/*
 30 Jan 2013:
 * 1. add method for get first date of current month
 */
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
using Rubix.Framework;

namespace CSI.Business
{
    public class DatabaseConnection 
    {
        #region Member
        private SqlConnection _SqlConn = null;
        private bool mustCloseConnection = true;
        private SqlTransaction Transaction;
        #endregion

        #region Properties
        private String ConnectionString
        {
            get
            {
                string strConnection = @"Data Source={0};Initial Catalog={1};
                                        Integrated Security=False;
                                        User ID={2};
                                        password={3};
                                        MultipleActiveResultSets=True;
                                        Connection Timeout=180;";
                strConnection = string.Format(strConnection, AppConfig.DatabaseServerName, AppConfig.DatabaseName, AppConfig.DatabaseUserName, AppConfig.DatabasePassword);

                return strConnection;
            }
        }
        private SqlConnection sqlConnection
        {
            get
            {
                if (_SqlConn == null)
                {
                    _SqlConn = new SqlConnection(ConnectionString);
                }
                return _SqlConn;
            }
            set
            {
                _SqlConn = value;
            }
        }
        #endregion
        
        public string GetEntityConnectionString(string modelName)
        {
            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = "System.Data.SqlClient";

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = ConnectionString;
            // Set the Metadata location.(
            entityBuilder.Metadata = string.Format(@"res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl", modelName);
            return entityBuilder.ToString();
        }
        public String DatabaseName()
        {
            SqlConnectionStringBuilder s = new SqlConnectionStringBuilder(ConnectionString);
            return s.InitialCatalog;
        }
        public String ServerName()
        {
            SqlConnectionStringBuilder s = new SqlConnectionStringBuilder(ConnectionString);
            return s.DataSource;
        }

        #region Private Function
        private void PrepareCommand(SqlCommand command, SqlConnection m_Connection, CommandType commandType, string commandText, SqlParameter[] commandParameters, ref bool mustCloseConnection)
        {
            if ((command == null))
                throw new ArgumentNullException("command");
            if ((commandText == null || commandText.Length == 0))
                throw new ArgumentNullException("commandText");

            // If the provided connection is not open, we will open it
            if (m_Connection.State != ConnectionState.Open)
            {
                m_Connection.Open();
                mustCloseConnection = true;
            }
            else
            {
                mustCloseConnection = false;
            }

            // Associate the connection with the command
            command.Connection = m_Connection;
            // Set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText;
            //Start Begin transaction---
            Transaction = m_Connection.BeginTransaction();
            // If we were provided a transaction, assign it.
            if ((Transaction != null))
            {
                if (Transaction.Connection == null)
                {
                    throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                }
                command.Transaction = Transaction;
            }

            // Set the command type
            command.CommandType = commandType;

            // Attach the command parameters if they are provided
            if ((commandParameters != null))
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }

        private void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            if ((command == null))
                throw new ArgumentNullException("command");
            if (((commandParameters != null)))
            {
                foreach (SqlParameter p in commandParameters)
                {
                    if (((p != null)))
                    {
                        // Check for derived output value with no value assigned
                        if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input) && p.Value == null)
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }

        private void GetParametersOutput(SqlParameter[] commandParameters, ref Hashtable objHastableOutput)
        {
            if (((commandParameters != null)))
            {
                foreach (SqlParameter p in commandParameters)
                {
                    if (((p != null)))
                    {
                        // Check for derived output value with no value assigned
                        if (p.Direction == ParameterDirection.Output)
                        {
                            objHastableOutput.Remove(p.ParameterName.Replace("@", string.Empty));
                            objHastableOutput.Add(p.ParameterName.Replace("@", string.Empty), p.Value);
                        }
                    }
                }
            }
        }

        private void ConvertHashtableToSqlParameter(Hashtable objHastable, ref SqlParameter[] outParam)
        {
            try
            {
                if (objHastable != null)
                {
                    outParam = new SqlParameter[objHastable.Keys.Count];
                    int intParmNum = 0;
                    object itm = null;

                    foreach (object itm_loopVariable in objHastable.Keys)
                    {
                        itm = itm_loopVariable;
                        outParam[intParmNum] = new SqlParameter("@" + Convert.ToString(itm), objHastable[itm]);
                        intParmNum += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ConvertHashtableToSqlParameterOutput(Hashtable objHastable, ref SqlParameter[] outParam)
        {
            try
            {
                if (objHastable != null)
                {
                    int intParmNum = 0;
                    if (outParam == null)
                    {
                        outParam = new SqlParameter[objHastable.Keys.Count];
                    }
                    else
                    {
                        intParmNum = outParam.Count();
                        Array.Resize(ref outParam, outParam.Count() + objHastable.Keys.Count);                       
                    }

                    object itm = null;

                    foreach (object itm_loopVariable in objHastable.Keys)
                    {
                        itm = itm_loopVariable;
                        outParam[intParmNum] = new SqlParameter("@" + Convert.ToString(itm), SqlDbType.NVarChar, 8000);
                        outParam[intParmNum].Direction = ParameterDirection.Output;
                        intParmNum += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ExecuteNonQuery
        public int ExecuteNonQuery(String StoreProcudureName, Hashtable objHastable, ref Hashtable objHastableOutput, ref Exception eReturn)
        {
            SqlCommand SqlCmd = new SqlCommand();
            SqlParameter[] commandParameters = null;
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                ConvertHashtableToSqlParameter(objHastable, ref commandParameters);
                ConvertHashtableToSqlParameterOutput(objHastableOutput, ref commandParameters);

                int retval = 0;
                SqlCmd.CommandTimeout = 1800;
                PrepareCommand(SqlCmd, sqlConnection, commandType, StoreProcudureName, commandParameters, ref mustCloseConnection);
                // Finally, execute the command
                retval = SqlCmd.ExecuteNonQuery();
                Transaction.Commit();
                //Get output parameter
                if (objHastableOutput != null)
                {
                    GetParametersOutput(commandParameters, ref objHastableOutput);
                }
                return retval;
            }
            catch (Exception ex)
            {
                if (Transaction != null)
                {
                    Transaction.Rollback();
                }
                eReturn = ex;
                throw ex;
            }
            finally
            {
                if ((mustCloseConnection))
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                SqlCmd.Parameters.Clear();
                SqlCmd.Dispose();
                SqlCmd = null;
                sqlConnection = null;
                commandParameters = null;
            }
        }
        #endregion

        #region ExecuteDataSet
        public DataSet ExecuteDataSet(String StoreProcudureName, Hashtable objHastable, ref Hashtable objHastableOutput, ref Exception eReturn)
        {
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.CommandTimeout = 1800;
            DataSet ds = new DataSet();
            SqlParameter[] commandParameters = null;
            SqlDataAdapter dataAdatpter = null;
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                ConvertHashtableToSqlParameter(objHastable, ref commandParameters);
                ConvertHashtableToSqlParameterOutput(objHastableOutput, ref commandParameters);

                PrepareCommand(SqlCmd, sqlConnection, commandType, StoreProcudureName, commandParameters, ref mustCloseConnection);

                dataAdatpter = new SqlDataAdapter(SqlCmd);
                dataAdatpter.Fill(ds);
                Transaction.Commit();
                //Get output parameter
                if (objHastableOutput != null)
                {
                    GetParametersOutput(commandParameters, ref objHastableOutput);
                }

                return ds;
            }
            catch (Exception ex)
            {
                if (Transaction != null)
                {
                    Transaction.Rollback();
                }
                eReturn = ex;
                throw ex;
            }
            finally
            {
                if ((mustCloseConnection))
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                SqlCmd.Parameters.Clear();
                SqlCmd.Dispose();
                SqlCmd = null;
                sqlConnection = null;
                dataAdatpter.Dispose();
                dataAdatpter = null;
                ds = null;
                commandParameters = null;
            }
        }
        #endregion

        #region ExecuteReader
        public SqlDataReader ExecuteReader(String StoreProcudureName, Hashtable objHastable, ref Exception eReturn)
        {
            SqlParameter[] commandParameters = null;
            SqlDataReader dataReader = null;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.CommandTimeout = 1800;

            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                ConvertHashtableToSqlParameter(objHastable, ref commandParameters);
                PrepareCommand(SqlCmd, sqlConnection, commandType, StoreProcudureName, commandParameters, ref mustCloseConnection);

                dataReader = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                Transaction.Commit();
                return dataReader;
            }
            catch (Exception ex)
            {
                if (Transaction != null)
                {
                    Transaction.Rollback();
                }
                eReturn = ex;
                throw ex;
            }
            finally
            {
                if ((mustCloseConnection))
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                SqlCmd.Parameters.Clear();
                SqlCmd.Dispose();
                SqlCmd = null;
                sqlConnection = null;
                commandParameters = null;
                dataReader = null;
            }
        }
        #endregion

        #region ExecuteScalar
        public object ExecuteScalar(String StoreProcudureName, Hashtable objHastable, ref Exception eReturn)
        {
            SqlParameter[] commandParameters = null;
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.CommandTimeout = 1800;
            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                ConvertHashtableToSqlParameter(objHastable, ref commandParameters);

                object retval = null;

                PrepareCommand(SqlCmd, sqlConnection, commandType, StoreProcudureName, commandParameters, ref mustCloseConnection);
                retval = SqlCmd.ExecuteScalar();
                Transaction.Commit();
                return (retval == null || retval.ToString().Trim() == string.Empty ? null : retval);
            }
            catch (Exception ex)
            {
                if (Transaction != null)
                {
                    Transaction.Rollback();
                }
                eReturn = ex;
                throw ex;
            }
            finally
            {
                if ((mustCloseConnection))
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                SqlCmd.Parameters.Clear();
                SqlCmd.Dispose();
                SqlCmd = null;
                sqlConnection = null;
                commandParameters = null;
            }
        }
        #endregion
                

    }
}
