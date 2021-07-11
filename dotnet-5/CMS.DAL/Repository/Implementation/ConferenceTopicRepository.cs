using CMS.DAL.Models;
using CMS.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.DAL.Repository.Implementation
{
    public class ConferenceTopicRepository : IConferenceTopicRepository
    {
        private readonly CMSContext _context;

        public ConferenceTopicRepository(CMSContext context)
        {
            _context = context;
        }

        public async Task<ConferenceTopic> AddAsync(ConferenceTopic conferenceTopic)
        {
            await _context.ConferenceTopics.AddAsync(conferenceTopic);
            return conferenceTopic;
        }

    }
}
