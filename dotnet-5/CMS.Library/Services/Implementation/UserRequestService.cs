using CMS.DAL.Core;
using CMS.DAL.Models;
using CMS.BL.Enums;
using CMS.BL.Models;
using CMS.BL.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Services.Implementation
{
    public class UserRequestService : IUserRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UserRequestModel> GetUserRequestForChair(int ChairId)
        {
            return _unitOfWork.RegisterRequestRepository
                .Filter(x => x.Conference.ChairId == ChairId
                    && x.RoleId != (int)RoleTypesEnum.Chair
                    && x.Status == UserRequestStatusEnum.Waiting.ToString())
                .Select(x => new UserRequestModel
                {
                    Id = x.Id,
                    ConferenceId = x.Conference.Id,
                    Title = x.Conference.Title,
                    RoleId = x.RoleId,
                    Type = x.Role.Type,
                    Name = x.Name,
                    Contact = x.Contact,
                    Password = x.Password,
                    Email = x.Email
                })
                .ToList();
        }

        public IEnumerable<UserRequestModel> GetUserRequestForAdmin(int adminId)
        {
            return _unitOfWork.RegisterRequestRepository
                .Filter(x => x.RoleId == (int)RoleTypesEnum.Chair
                    && x.Status == UserRequestStatusEnum.Waiting.ToString())
                .Select(x => new UserRequestModel
                {
                    Id = x.Id,
                    RoleId = x.RoleId,
                    Type = x.Role.Type,
                    Name = x.Name,
                    Contact = x.Contact,
                    Password = x.Password,
                    Email = x.Email
                })
                .ToList();
        }

        public async Task ChangeRequestStatus(int requestId, UserRequestStatusEnum Status)
        {
            var request = _unitOfWork.RegisterRequestRepository
                .Filter(r => r.Id == requestId)
                .SingleOrDefault();

            request.Status = Status.ToString();

            _unitOfWork.RegisterRequestRepository.Update(request);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddRegisterRequest(RegisterRequest request)
        {
            if (request == null)
            {
                throw new Exception();
            }

            _unitOfWork.RegisterRequestRepository.Add(request);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
