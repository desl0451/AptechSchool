using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using AptechSchoolModels;
namespace AptechSchoolDAL
{
    public class StudentServers
    {
        public List<Student> GetALLUsers()
        {
            List<Student> ulist = new List<Student>();
            try
            {
                using (AptechSchoolEntities context = new AptechSchoolEntities())
                {
                    var query = from e in context.Students
                                select e;
                    foreach (var item in query)
                    {
                        Student stu = new Student();
                        stu.SAddress = item.SAddress;
                        stu.SAge = item.SAge;
                        stu.SClass = item.SClass;
                        stu.SGrade = item.SGrade;
                        stu.SId = item.SId;
                        stu.SName = item.SName;
                        stu.SPicture = item.SPicture;
                        ulist.Add(stu);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ulist;
        }
    }
}
