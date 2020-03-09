using CMS.DAL.Core;
using CMS.DAL.Models;
using CMS.Library.Global;
using CMS.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Library.Service
{
    public class UserRequestService : IUserRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UserRequestModel> GetUserRequestForChair(int chairId)
        {
            return _unitOfWork.RegisterRequestRepository
                .Filter(x => x.Conference.chairId == chairId
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

        public IEnumerable<UserRequestModel> GetUserRequestForAdmin(int adminId)
        {
            return _unitOfWork.RegisterRequestRepository
                .Filter(x => x.roleId == (int)RoleTypes.Chair
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
                .ToList();
        }

        public async Task ChangeRequestStatus(int requestId, UserRequestStatus status)
        {
            var request = _unitOfWork.RegisterRequestRepository
                .Filter(r => r.Id == requestId)
                .SingleOrDefault();

            request.status = status.ToString();

            _unitOfWork.RegisterRequestRepository.Update(request);

            await _unitOfWork.Save();
        }

        public async Task AddRegisterRequest(RegisterRequest request)
        {
            if (request == null)
            {
                throw new Exception();
            }

            _unitOfWork.RegisterRequestRepository.Add(request);

            await _unitOfWork.Save();
        }
    }
}
