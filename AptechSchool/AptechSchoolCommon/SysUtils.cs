using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;

namespace AptechSchoolCommon
{
    public class SysUtils
    {
       

        #region 备份数据库
        public static string BakBackUp()
        {
            using (SqlConnection sqlconn = new SqlConnection(SqlConnString()))
            {
                sqlconn.Open();
                string path = AppDomain.CurrentDomain.BaseDirectory + "bakup\\";
                string name = DateTime.Now.ToString("【" + SqlConnDataBase() + "】" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".bak");
                PathIsExists(path);//判断路径是否存在，不存在则创建
                string sqlstr = "BACKUP DATABASE "
                    + SqlConnDataBase() + " TO DISK = '"
                    + path + name + "'";
                using (SqlCommand sqlcom = new SqlCommand(sqlstr, sqlconn))
                {
                    sqlcom.CommandType = CommandType.Text;
                    sqlcom.ExecuteNonQuery();
                }
                return path + name;
            }
        }
        #endregion

        #region 返回连接字符串
        private static string SqlConnString()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("server=");
            sbSql.Append(SqlConnServer() + ";");
            sbSql.Append("database=");
            sbSql.Append(SqlConnDataBase() + ";");
            sbSql.Append("uid=");
            sbSql.Append(SqlConnUid() + ";");
            sbSql.Append("pwd=");
            sbSql.Append(SqlConnPwd() + ";");
            return sbSql.ToString();
        }
        public static string SqlConnServer()
        {
            return ConfigurationManager.AppSettings["Server"].ToString();
        }
        public static string SqlConnDataBase()
        {
            return ConfigurationManager.AppSettings["DataBase"].ToString();
        }
        public static string SqlConnUid()
        {
            return ConfigurationManager.AppSettings["uid"].ToString();
        }
        public static string SqlConnPwd()
        {
            return ConfigurationManager.AppSettings["pwd"].ToString();
        }
        #endregion

        #region 返回版本号
        /// <summary>
        /// 版本号
        /// </summary>
        /// <returns>string</returns>
        public static string Version()
        {
            return ConfigurationManager.AppSettings["Version"].ToString();
        }
        #endregion

        #region 判断路径是否存在，不存在则创建
        /// <summary>
        /// 判断路径是否存在，不存在则创建
        /// </summary>
        /// <param name="path">路径</param>
        public static void PathIsExists(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);//创建新路径
            }
        }
        #endregion

        #region 绑定系统参数
        /// <summary>
        /// parameter绑定
        /// </summary>
        /// <param name="cmbname">Dev下拉列表控件名称</param>
        /// <param name="b">是否默认请选择 true=是，false=否</param>
        /// <param name="mark">参数标识</param>
        //public static void Cmb_Bind(DevComponents.DotNetBar.Controls.ComboBoxEx cmbname, bool b, string mark)//绑定参数cmb
        //{
        //    BLL.sys.parameter bll = new BLL.sys.parameter();
        //    using (DataTable dt = bll.GetList("Id_Parent=(select Par_Id from dt_sys_parameter where Par_Mark='" + mark + "') and IsUse=0 order by ListOrder").Tables[0])
        //    {
        //        cmbname.Items.Clear();

        //        ArrayList arList = new ArrayList();

        //        if (b)//默认请选择
        //        {
        //            arList.Add(new DictionaryEntry(0, "请选择"));
        //        }
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            string Id = dr["Par_Id"].ToString();
        //            int ClassLayer = int.Parse(dr["Class_Layer"].ToString());
        //            string Title = dr["Par_Name"].ToString().Trim();

        //            arList.Add(new DictionaryEntry(Id, Title));
        //        }
        //        cmbname.DisplayMember = "Value";
        //        cmbname.ValueMember = "Key";

        //        cmbname.DataSource = arList;
        //    }
        //}
        #endregion
    }
}
