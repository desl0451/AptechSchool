using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AptechSchoolCommon
{
    public class Utils
    {
        #region 替换指定的字符串
        /// <summary>
        /// 替换指定的字符串
        /// </summary>
        /// <param name="originalStr">原字符串</param>
        /// <param name="oldStr">旧字符串</param>
        /// <param name="newStr">新字符串</param>
        /// <returns></returns>
        public static string ReplaceStr(string originalStr, string oldStr, string newStr)
        {
            if (string.IsNullOrEmpty(oldStr))
            {
                return "";
            }
            return originalStr.Replace(oldStr, newStr);
        }
        #endregion

        #region 删除最后结尾的一个逗号
        /// <summary>
        /// 删除最后结尾的一个逗号
        /// </summary>
        public static string DelLastComma(string str)
        {
            return str.Substring(0, str.LastIndexOf(","));
        }
        #endregion

        #region 删除最后结尾的指定字符后的字符
        /// <summary>
        /// 删除最后结尾的指定字符后的字符
        /// </summary>
        public static string DelLastChar(string str, string strchar)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            if (str.LastIndexOf(strchar) >= 0 && str.LastIndexOf(strchar) == str.Length - 1)
            {
                return str.Substring(0, str.LastIndexOf(strchar));
            }
            return str;
        }
        #endregion

        #region 生成指定长度的字符串
        /// <summary>
        /// 生成指定长度的字符串,即生成strLong个str字符串
        /// </summary>
        /// <param name="strLong">生成的长度</param>
        /// <param name="str">以str生成字符串</param>
        /// <returns></returns>
        public static string StringOfChar(int strLong, string str)
        {
            string ReturnStr = "";
            for (int i = 0; i < strLong; i++)
            {
                ReturnStr += str;
            }

            return ReturnStr;
        }
        #endregion

        #region 获取以" - "分离的字符串的第一个" - " 之前的内容
        /// <summary>
        /// 获取以" - "分离的字符串的
        /// </summary>
        /// <param name="strvalue">字符串</param>
        /// <returns>第一个" - " 之前的内容</returns>
        public static string GetSeparatedID(string strvalue)
        {
            string[] strArray = strvalue.Split('-');
            return strArray[0].ToString().Trim();
        }
        /// <summary>
        /// 获取以" - "分离的字符串的
        /// </summary>
        /// <param name="strvalue">字符串</param>
        /// <param name="index">索引位置</param>
        /// <returns>第n个" - " 之前的内容</returns>        
        public static string GetSeparatedID(string strvalue, int index)
        {
            string[] strArray = strvalue.Split('-');
            return strArray[index].ToString().Trim();
        }
        #endregion

        #region 获取本地IP
        /// <summary>
        /// 获取本地IP
        /// </summary>
        /// <returns>IP地址</returns>
        public static string GetIP()
        {
            IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            return ipAddr.ToString();
        }
        #endregion

        #region 返回星期几
        public static string GetWeekDay()
        {
            string[] arrCnNames = new string[] { "日", "一", "二", "三", "四", "五", "六" };
            return "星期" + arrCnNames[(int)DateTime.Now.DayOfWeek];
        }
        #endregion

        #region 返回单据编号
        /// <summary>
        /// 返回单据编号
        /// </summary>
        /// <param name="OrderType">单据类型：CGDD=采购订单，HYYDD=货运预订单，PCD=派车单</param>
        /// <param name="LsLength">尾部流水号的长度</param>
        /// <param name="TabName">要查询的表名</param>
        /// <param name="ColName">要查询的列名</param>
        /// <returns></returns>
        public static string GetOrderCode(string OrderType, int LsLength, string TabName, string ColName)
        {
            #region----返回订单流水编号

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("server=");
            sbSql.Append(ConfigurationManager.AppSettings["Server"].ToString() + ";");
            sbSql.Append("database=");
            sbSql.Append(ConfigurationManager.AppSettings["DataBase"].ToString() + ";");
            sbSql.Append("uid=");
            sbSql.Append(ConfigurationManager.AppSettings["uid"].ToString() + ";");
            sbSql.Append("pwd=");
            sbSql.Append(ConfigurationManager.AppSettings["pwd"].ToString() + ";");
            string constr = sbSql.ToString();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                string CurrentDt = OrderType + DateTime.Now.ToString("yyyyMMdd").Substring(2).ToString();
                string sql = "select MAX(" + ColName + ") as MaxId from  " + TabName + " where " + ColName + " like '" + CurrentDt + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                int NewId = 0;
                string NewIdPad = "", MaxId = "0";
                if (dr.Read())
                {
                    MaxId = dr["MaxId"].ToString();
                    if (!string.IsNullOrEmpty(MaxId))
                    {
                        NewId = Convert.ToInt32(MaxId.Substring(OrderType.Length + 6)) + 1;
                        NewIdPad = NewId.ToString();
                        NewIdPad = NewIdPad.PadLeft(LsLength, Convert.ToChar("0"));
                    }
                    else
                    {
                        NewId = NewId + 1;
                        NewIdPad = NewId.ToString();
                        NewIdPad = NewIdPad.PadLeft(LsLength, Convert.ToChar("0"));
                    }
                }
                dr.Close();
                dr.Dispose();
                string returnLSH = OrderType + DateTime.Now.ToString("yyyyMMdd").Substring(2).ToString() + NewIdPad;
                return returnLSH;
            }
            #endregion
        }
        #endregion

        #region 验证字段值是否存在
        /// <summary>
        /// 验证字段值是否存在
        /// </summary>
        /// <param name="TabName">表名</param>
        /// <param name="ColName">要验证的列</param>
        /// <param name="ColValue">要验证列的值</param>
        /// <returns></returns>
        public static bool IsExists(string TabName, string ColName, string ColValue)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("server=");
            sbSql.Append(ConfigurationManager.AppSettings["Server"].ToString() + ";");
            sbSql.Append("database=");
            sbSql.Append(ConfigurationManager.AppSettings["DataBase"].ToString() + ";");
            sbSql.Append("uid=");
            sbSql.Append(ConfigurationManager.AppSettings["uid"].ToString() + ";");
            sbSql.Append("pwd=");
            sbSql.Append(ConfigurationManager.AppSettings["pwd"].ToString() + ";");
            string constr = sbSql.ToString();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                string sql = "select " + ColName + " from " + TabName + " where " + ColName + " ='" + ColValue + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
                dr.Close();
                dr.Dispose();
            }
        }
        #endregion

    }
}
