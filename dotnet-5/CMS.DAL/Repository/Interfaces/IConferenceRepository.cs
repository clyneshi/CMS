﻿using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IConferenceRepository
    {
        Task<Conference> AddAsync(Conference Conference);
        Task<List<Conference>> FilterAsync(Expression<Func<Conference, bool>> predicate);
        Task<List<Conference>> GetAllAsync();
        Task<List<Conference>> GetConferencesWithChairAsync(Expression<Func<Conference, bool>> predicate = null);

    }
}