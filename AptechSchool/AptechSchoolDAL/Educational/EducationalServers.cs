using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AptechSchoolModels;
namespace AptechSchoolDAL
{
    public class EducationalServers
    {
        public List<Educational> GetALLEducational()
        {
            List<Educational> edulist = new List<Educational>();
            using (AptechSchoolEntities context = new AptechSchoolEntities())
            {
                //1.using LINQ to Entities query
                var query = from e in context.Educationals
                            select e;
                foreach (var item in query)
                {
                    Educational edu = new Educational();
                    edu.EId = item.EId;
                    edu.EducationalName = item.EducationalName;
                    edulist.Add(edu);
                }
            }
            return edulist;
        }
    }
}
