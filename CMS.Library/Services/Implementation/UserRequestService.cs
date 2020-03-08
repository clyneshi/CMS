using CMS.DAL.Models;
using CMS.Library.Global;
using CMS.Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Library.Service
{
    public class UserRequestService : IUserRequestService
    {
        public IEnumerable<UserRequestModel> GetUserRequest()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.RegisterRequests
                    .Where(x => x.Conference.chairId == GlobalVariable.CurrentUser.userId
                        && x.roleId != (int)RoleTypes.Chair
                        && x.status == UserRequestStatus.Waiting.ToString())
                    .Select(x => new UserRequestModel
                    {
                        Id = x.Id,
                        ConfId = x.Conference.confId,
                        ConfTitle = x.Conference.confTitle,
                        RoleId = x.roleId,
                        RoleType = x.Role.roleType,
                        Name = x.name,
                        Contact = x.contact,
                        Password = x.password,
                        Email = x.email
                    })
                    .ToList();
            }
        }

        public IEnumerable<UserRequestModel> GetUserRequest_Admin()
        {
            using (var dbModel = new CMSDBEntities())
            {
                return dbModel.RegisterRequests
                    .Where(x => x.Conference.chairId == GlobalVariable.CurrentUser.userId
                        && x.roleId == (int)RoleTypes.Chair
                        && x.status == UserRequestStatus.Waiting.ToString())
                    .Select(x => new UserRequestModel
                    {
                        Id = x.Id,
                        RoleId = x.roleId,
                        RoleType = x.Role.roleType,
                        Name = x.name,
                        Contact = x.contact,
                        Password = x.password,
                        Email = x.email
                    })
                    .ToList(); ;
            }
        }

        public void ChangeRequestStatus(int id, UserRequestStatus status)
        {
            using (var dbModel = new CMSDBEntities())
            {
                RegisterRequest rr = dbModel.RegisterRequests.FirstOrDefault(r => r.Id == id);

                rr.status = status.ToString();

                dbModel.SaveChanges();
            }
        }

        public void AddRegisterRequest(RegisterRequest request)
        {
            using (var dbModel = new CMSDBEntities())
            {
                dbModel.RegisterRequests.Add(request);
                dbModel.SaveChanges();
            }
        }
    }
}
