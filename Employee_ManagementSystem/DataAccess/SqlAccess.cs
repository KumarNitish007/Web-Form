using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using Employee_ManagementSystem.Helper;

namespace Employee_ManagementSystem.DataAccess
{
    
    public class SqlAccess
    {
        string _connectionstring;
        //SqlConnection _webSqlcon = new SqlConnection(ConfigurationManager.AppSettings["SQLDBConnection"].ToString(CultureInfo.InvariantCulture));

        //public DataSet GenericProcedureExecutionWithParameters(string spName, SqlParameter[] _params)
        //{
        //    _webSqlcon = new SqlConnection(ConfigurationManager.AppSettings["SQLDBConnection"].ToString(CultureInfo.InvariantCulture));
        //    try
        //    {
        //        _webSqlcon.Open();
        //        return SqlHelper.ExecuteDataset(_webSqlcon, spName, _params);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message.ToString());
        //    }
        //    finally
        //    {
        //        _webSqlcon.Close();
        //    }
        //}

        SqlConnection _webSqlcon = new SqlConnection(ConfigurationManager.AppSettings["SQLDBConnection"].ToString(CultureInfo.InvariantCulture));

        public DataSet ExecuteQuery(string query)
        {
            try
            {
                _webSqlcon.Open();
                return SqlHelper.ExecuteDataset(_webSqlcon, CommandType.Text, query);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                _webSqlcon.Close();
            }
        }

        public SqlAccess()
        {
            _connectionstring = ConfigurationManager.AppSettings["SQLDBConnection"].ToString(CultureInfo.InvariantCulture);
        }

        public DataSet GenericProcedureParameterLessExecution(string spName)
        {
            _webSqlcon = new SqlConnection(ConfigurationManager.AppSettings["SQLDBConnection"].ToString(CultureInfo.InvariantCulture));
            try
            {
                _webSqlcon.Open();
                return SqlHelper.ExecuteDataset(_webSqlcon, spName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                _webSqlcon.Close();
            }
        }

        public DataSet GenericProcedureExecutionWithParameters(string spName, SqlParameter[] _params)
        {
            _webSqlcon = new SqlConnection(ConfigurationManager.AppSettings["SQLDBConnection"].ToString(CultureInfo.InvariantCulture));
            try
            {
                _webSqlcon.Open();
                return SqlHelper.ExecuteDataset(_webSqlcon, spName, _params);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                _webSqlcon.Close();
            }
        }
    }
}