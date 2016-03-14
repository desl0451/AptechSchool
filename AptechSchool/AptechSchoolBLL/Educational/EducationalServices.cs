using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AptechSchoolModels;
using AptechSchoolDAL;
using System.Windows.Forms;
namespace AptechSchoolBLL
{
    public  class EducationalServices
    {
        private EducationalServers eduServices = new EducationalServers();
        public List<Educational> GetAllEducationals()
        {
            try
            {
                return eduServices.GetALLEducational();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
    }
}
