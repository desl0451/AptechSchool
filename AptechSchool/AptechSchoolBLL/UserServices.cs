using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AptechSchoolModels;
using AptechSchoolDAL;
namespace AptechSchoolBLL
{
    /// <summary>
    /// 用户信息类
    /// </summary>
    public class UserServices
    {
        private UserServers userServices = new UserServers();
        public List<Student> GetALLUsers()
        {
            try
            {
               return userServices.GetALLUsers();
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }   
    }
}
