using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AptechSchoolDAL;
namespace AptechSchoolBLL
{
    public class SchoolclassServices
    {
        SchoolclassServers server = new SchoolclassServers();
        public string GetClassName(int gradeId)
        {
            try
            {
                return server.GetClassName(gradeId);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
