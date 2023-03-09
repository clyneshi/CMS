using CMS.DAL.Core;
using CMS.DAL.Models;
using CMS.BL.Models;
using CMS.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Common.Enums;

namespace CMS.BL.Services.Implementation;

public class UserRequestService : IUserRequestService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserRequestService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IList<UserRequestModel>> GetRegisterRequestsForChairAsync(int chairId)
    {
        return (await _unitOfWork.RegisterRequestRepository
            .FilterAsync(x => x.Conference.ChairId == chairId
                && x.RoleId != (int)RoleTypesEnum.Chair
                && x.Status == UserRequestStatusEnum.Waiting.ToString()))
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

    public async Task<IList<UserRequestModel>> GetRegisterRequestsForAdminAsync(int adminId)
    {
        return (await _unitOfWork.RegisterRequestRepository
            .FilterAsync(x => x.RoleId == (int)RoleTypesEnum.Chair
                && x.Status == UserRequestStatusEnum.Waiting.ToString()))
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

    public async Task ChangeRequestStatusAsync(int requestId, UserRequestStatusEnum Status)
    {
        var request = (await _unitOfWork.RegisterRequestRepository
            .FilterAsync(r => r.Id == requestId))
            .SingleOrDefault();

        if (request == null)
            throw new Exception("Register request does not exist");

        await _unitOfWork.RegisterRequestRepository.ChangeRegisterRequestStatusAsync(requestId, Status.ToString());

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AddRegisterRequestAsync(RegisterRequest request)
    {
        if (request == null)
        {
            throw new Exception();
        }

        await _unitOfWork.RegisterRequestRepository.AddAsync(request);

        await _unitOfWork.SaveChangesAsync();
    }
}
