using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Dao
{
    public class Db
    {

        #region 构造函数

        private static Db _instance;
        public static Db GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Db();
            }
            return _instance;
        }

        #endregion

        #region Context
        /*public SQLiteConnection Context()
        {
            SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder();
            sb.DataSource =
                @"//10.0.0.105/db/DB.s3db";
            // Application.StartupPath + @"\Data.dll";//DB.db3
            SQLiteConnection con = new SQLiteConnection(sb.ToString());
            return con;
        }*/

        public SqlConnection GetSqlConnection()
        {
            string sqlconnectionString = ConfigurationManager.ConnectionStrings["sqlconnectionString"].ToString();
            var connection = new SqlConnection(sqlconnectionString);
            connection.Open();
            return connection;
        }
        public MySqlConnection GetMySqlConnection()
        {
            //string mysqlconnectionString = ConfigurationManager.ConnectionStrings["mysqlconnectionString"].ToString();
            string mysqlconnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["mysqlconnectionString"].ToString();
            var connection = new MySqlConnection(mysqlconnectionString);
            connection.Open();
            return connection;
        }
        #endregion

        #region 分页语句拼接
        public string GetSqlForSelectBuilder(SelectBuilder data)
        {
            var sql = "";
            sql = "select " + data.Select;
            sql += " from " + data.From;
            if (data.WhereSql.Length > 0)
                sql += " where " + data.WhereSql;
            if (data.GroupBy.Length > 0)
                sql += " group by " + data.GroupBy;
            if (data.Having.Length > 0)
                sql += " having " + data.Having;
            if (data.OrderBy.Length > 0)
                sql += " order by " + data.OrderBy;
            if (data.PagingItemsPerPage > 0
                && data.PagingCurrentPage > 0
                )
            {
                sql += string.Format(" limit {0} offset {1}", data.PagingItemsPerPage, ((data.PagingCurrentPage * data.PagingItemsPerPage) - data.PagingItemsPerPage + 1) - 1);
            }
            return sql;
        }
        public string GetSqlForTotalBuilder(SelectBuilder data)
        {
            var sql = "";
            sql = "select count(*)";
            sql += " from " + data.From;
            if (data.WhereSql.Length > 0)
                sql += " where " + data.WhereSql;
            return sql;
        }
        #endregion

    }

    #region SelectBuilder
    public class SelectBuilder
    {
        public int PagingCurrentPage { get; set; }
        public int PagingItemsPerPage { get; set; }


        private string _Having = "";
        public string Having
        {
            set { _Having = value; }
            get { return _Having; }
        }



        private string _GroupBy = "";
        public string GroupBy
        {
            set { _GroupBy = value; }
            get { return _GroupBy; }
        }



        private string _OrderBy = "";
        public string OrderBy
        {
            set { _OrderBy = value; }
            get { return _OrderBy; }
        }




        private string _From = "";
        public string From
        {
            set { _From = value; }
            get { return _From; }
        }



        private string _Select = "";
        public string Select
        {
            set { _Select = value; }
            get { return _Select; }
        }

        private string _WhereSql = "";
        public string WhereSql
        {
            set { _WhereSql = value; }
            get { return _WhereSql; }
        }



    }
    #endregion

}
