using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;

namespace Dao
{
    /// <summary>
    /// 采用Dapper ORM框架
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DapperService<T> where T : class
    {

        #region 构造函数

        private static DapperService<T> _instance;
        public static DapperService<T> GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DapperService<T>();
            }
            return _instance;
        }

        #endregion

        /// <summary>
        /// 用于新增或修改
        /// </summary>
        /// <param name="commandText">sql</param>
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        public int InsertUpdate(string commandText, T model)
        {
            //由于Dapper ORM的操作实际上是对IDbConnection类的扩展，所有的方法都是该类的扩展方法。所以在使用前先实例化一个IDBConnection对象。
            using (IDbConnection conn = Db.GetInstance().GetMySqlConnection())
            {
                int result = conn.Execute(commandText, model);
                return result;
            }
        }

        /// <summary>
        /// 批量新增或修改
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        public int InsertUpdateBatch(string commandText, List<T> models)
        {
            using (IDbConnection conn = Db.GetInstance().GetMySqlConnection())
            {
                //string sqlCommandText = @"INSERT INTO USERS(Name,Age)VALUES(@Name,@Age)";
                return conn.Execute(commandText, models);
            }
        }

        /// <summary>
        /// 用于执行带一个参数的sql，如删除等
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Scalar(String commandText, string paramName, object paramValue)
        {
            using (IDbConnection conn = Db.GetInstance().GetMySqlConnection())
            {
                var p = new DynamicParameters();
                //p.Add("@ID", 1);
                p.Add(paramName, paramValue);
                return conn.Execute(commandText, p);
            }
        }

        /// <summary>
        /// 用于执行带任意多个参数的sql，用于 新增，修改，删除
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Scalar(string commandText, T model)
        {
            using (IDbConnection conn = Db.GetInstance().GetMySqlConnection())
            {
                return conn.Execute(commandText, model);
            }
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public T Query(string commandText, T model)
        {
            using (IDbConnection conn = Db.GetInstance().GetMySqlConnection())
            {
                T obj = conn.Query<T>(commandText, model).SingleOrDefault();
                return obj;
            }
        }

        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<T> QueryList(string commandText, T model)
        {
            using (IDbConnection conn = Db.GetInstance().GetMySqlConnection())
            {
                return conn.Query<T>(commandText, model).ToList();
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="data"></param>
        /// <param name="model"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<T> GetQueryManyForPage(SelectBuilder data, T model, out int count)
        {

            using (IDbConnection conn = Db.GetInstance().GetMySqlConnection())
            {
                string sqlStr = Db.GetInstance().GetSqlForSelectBuilder(data);
                string sqlStrCount = Db.GetInstance().GetSqlForTotalBuilder(data);
                List<T> list = conn.Query<T>(sqlStr, model).ToList();
                Object rowCounts = conn.ExecuteScalar(sqlStrCount, model);
                count = rowCounts != null ? Convert.ToInt32(rowCounts.ToString()) : 0;
                return list;
            }
        }
    }
}
