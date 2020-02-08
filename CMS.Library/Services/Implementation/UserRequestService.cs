using CMS.Library.Global;
using CMS.Library.Model;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Library.Service
{
    public class UserRequestService : IUserRequestService
    {
        public List<UserRequestModel> GetUserRequest()
        {
            using (var dbModel = new CMSDBEntities())
            {
                var userRequest = from c in dbModel.Conferences
                                  join r in dbModel.RegisterRequests on c.confId equals r.confId
                                  join ro in dbModel.Roles on r.roleId equals ro.roleId
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
        }

        public List<UserRequestModel> GetUserRequest_Admin()
        {
            using (var dbModel = new CMSDBEntities())
            {
                var userRequest = from r in dbModel.RegisterRequests
                                  join ro in dbModel.Roles on r.roleId equals ro.roleId
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
        }

        public void ChangeRequestStatus(int id, int type)
        {
            using (var dbModel = new CMSDBEntities())
            {
                RegisterRequest rr = dbModel.RegisterRequests.FirstOrDefault(r => r.Id == id);
                if (type == 1)
                    rr.status = "Approved";
                else if (type == 2)
                    rr.status = "Declined";

                dbModel.SaveChanges();
            }
        }

        public bool AddRegisterRequest(RegisterRequest request)
        {
            using (var dbModel = new CMSDBEntities())
            {
                try
                {
                    dbModel.RegisterRequests.Add(request);
                    dbModel.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
