using CMS.Library.Model;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Library.Global
{
    public static partial class DataProcessor
    {
        public static List<UserRequestModel> GetUserRequest()
        {
            var userRequest = from c in GlobalVariable.DbModel.Conferences
                              join r in GlobalVariable.DbModel.RegisterRequests on c.confId equals r.confId
                              join ro in GlobalVariable.DbModel.Roles on r.roleId equals ro.roleId
                              where c.chairId == GlobalVariable.CurrentUser.userId && r.roleId != 2 && r.status == "Waiting for approval"
                              select new UserRequestModel
                              {
                                  Id = r.Id,
                                  ConfId = c.confId,
                                  ConfTitle = c.confTitle,
                                  RoleId = r.roleId,
                                  RoleType = ro.roleType,
                                  Name = r.name,
                                  Contact = r.contact,
                                  Password = r.password,
                                  Email = r.email
                              };

            return userRequest.ToList();
        }

        public static List<UserRequestModel> GetUserRequest_Admin()
        {
            var userRequest = from r in GlobalVariable.DbModel.RegisterRequests
                              join ro in GlobalVariable.DbModel.Roles on r.roleId equals ro.roleId
                              where r.roleId == 2 && r.status == "Waiting for approval"
                              select new UserRequestModel
                              {
                                  Id = r.Id,
                                  RoleId = r.roleId,
                                  RoleType = ro.roleType,
                                  Name = r.name,
                                  Contact = r.contact,
                                  Password = r.password,
                                  Email = r.email
                              };

            return userRequest.ToList();
        }

        public static void ChangeRequestStatus(int id, int type)
        {
            RegisterRequest rr = GlobalVariable.DbModel.RegisterRequests.FirstOrDefault(r => r.Id == id);
            if (type == 1)
                rr.status = "Approved";
            else if (type == 2)
                rr.status = "Declined";

            GlobalVariable.DbModel.SaveChanges();
        }

        public static bool AddRegisterRequest(RegisterRequest request)
        {
            try
            {
                GlobalVariable.DbModel.RegisterRequests.Add(request);
                GlobalVariable.DbModel.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
