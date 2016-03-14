using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace AptechSchoolCommon
{
    public class IniHelper
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal,
            int size, string filePath);
        /// <summary>
        /// 读取ini文件
        /// </summary>
        /// <param name="Section">段落</param>
        /// <param name="Key">关键字</param>
        /// <param name="NoText">关键字对应的值</param>
        /// <param name="iniFilePath">文件路径</param>
        /// <returns></returns>
        public static string ReadIniData(string Section, string Key, string NoText, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);
                return temp.ToString();
            }
            else
            {
                return String.Empty;
            }
        }
        /// <summary>
        /// 写ini
        /// </summary>
        /// <param name="Section">段落</param>
        /// <param name="Key">关键字</param>
        /// <param name="NoText">关键字对应的值</param>
        /// <param name="iniFilePath">文件路径</param>
        /// <returns></returns>
        public static bool WriteIniData(string Section, string Key, string Value, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                long OpStation = WritePrivateProfileString(Section, Key, Value, iniFilePath);
                if (OpStation == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
