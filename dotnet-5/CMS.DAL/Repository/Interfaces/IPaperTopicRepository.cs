using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IPaperTopicRepository
    {
        Task<PaperTopic> AddAsync(PaperTopic paperTopic);
    }
}