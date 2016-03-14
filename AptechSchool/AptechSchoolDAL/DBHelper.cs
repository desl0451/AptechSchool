using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace AptechSchoolDAL
{
    class DBHelper
    {
        //public string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

        /// <summary>
        /// 返回数据库连接
        /// </summary>
        /// <returns></returns>
        public SqlConnection getConn()
        {
            try
            {
               // SqlConnection connection = new SqlConnection(connString);
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
