using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AptechSchoolModels;
using System.Data.SqlClient;
namespace AptechSchoolDAL
{
    public class SchoolclassServers
    {

        /// <summary>
        /// 根据编写返回班级
        /// </summary>
        /// <param name="gradeid"></param>
        /// <returns></returns>
        public string GetClassName(int gradeid)
        {

            List<Student> ulist = new List<Student>();

            string className = "";
            try
            {
                using (var content = new AptechSchoolEntities())
                {
                    var query = from s in content.SchoolClasses
                                where s.GradeId == gradeid
                                select s;
                    foreach (var s in query)
                    {
                        className = s.ClassName;
                    }

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            return className;
        }
    }
}
