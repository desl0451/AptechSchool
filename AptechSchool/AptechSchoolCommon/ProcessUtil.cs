using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace AptechSchoolCommon
{
    public class ProcessUtil
    {

        /// <summary>
        /// 跳转到某网页
        /// </summary>
        /// <param name="url"></param>
        public static void GoHref(string url)
        {
            Process.Start(url);
        }
    }
}
