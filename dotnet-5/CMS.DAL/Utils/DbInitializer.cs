using CMS.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.DAL.Utils;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var serviceScope = serviceProvider.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<CmsDbContext>());
        }
    }

    private static void SeedData(CmsDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Users.Any())
            return;

        var keywords = new[]
        {
            new Keyword() {Id = 1, Name = "Geophysics and Geology", Genre = "Earth Sciences"},
            new Keyword() {Id = 2, Name = "Mineralogy", Genre = "Earth Sciences"},
            new Keyword() {Id = 3, Name = "Hydrology", Genre = "Earth Sciences"},
            new Keyword() {Id = 4, Name = "Meteorology and Climate Change", Genre = "Earth Sciences"},
            new Keyword() {Id = 5, Name = "Oceanography", Genre = "Earth Sciences"},
            new Keyword() {Id = 6, Name = "Earth Observation", Genre = "Earth Sciences"},
            new Keyword() {Id = 7, Name = "Biology", Genre = "Life Sciences"},
            new Keyword() {Id = 8, Name = "Botany", Genre = "Life Sciences"},
            new Keyword() {Id = 9, Name = "Zoology", Genre = "Life Sciences"},
            new Keyword() {Id = 10, Name = "Molecular Biology", Genre = "Life Sciences"},
            new Keyword() {Id = 11, Name = "Agronomy", Genre = "Life Sciences"},
            new Keyword() {Id = 12, Name = "Food Chemisitry", Genre = "Life Sciences"}
        };
        context.Keywords.AddRange(keywords);

        var roles = new[]
        {
            new Role() {Id = 1, Type = "Admin"},
            new Role() {Id = 2, Type = "Chair"},
            new Role() {Id = 3, Type = "Reviewer"},
            new Role() {Id = 4, Type = "Author"},
        };
        context.Roles.AddRange(roles);

        var users = new[]
        {
            new User() { Id = 1, Name = "admin", Password = "ad", Email = "admin@cms.com", RoleId = 1 },
            new User() { Id = 2, Name = "chair1", Password = "ch", Email = "chair1@cms.com", RoleId = 2 },
            new User() { Id = 3, Name = "chair2", Password = "ch", Email = "chair2@cms.com", RoleId = 2 },
            new User() { Id = 4, Name = "reviewer1", Password = "re", Email = "reviewer1@cms.com", RoleId = 3 },
            new User() { Id = 5, Name = "reviewer2", Password = "e", Email = "reviewer2@cms.com", RoleId = 3 },
            new User() { Id = 6, Name = "author1", Password = "au", Email = "author1@cms.com", RoleId = 4 },
            new User() { Id = 7, Name = "author2", Password = "au", Email = "author2@cms.com", RoleId = 4 },
        };
        context.Users.AddRange(users);

        var expertises = new[]
        {
            new Expertise() { Id = 1, UserId = 4, KeywordId = 5},
            new Expertise() { Id = 2, UserId = 4, KeywordId = 6},
            new Expertise() { Id = 3, UserId = 4, KeywordId = 7},
            new Expertise() { Id = 4, UserId = 5, KeywordId = 10},
            new Expertise() { Id = 5, UserId = 5, KeywordId = 12}
        };
        context.Expertises.AddRange(expertises);

        var conferences = new[]
        {
            new Conference() { Id = 1, ChairId = 2, Title = "Innovate Bopitech 2017", Location = "Melbourn CBD 343", BeginDate = new DateTime(2017, 12, 23), EndDate = new DateTime(2017, 12, 30), PaperDeadline = new DateTime(2017, 11, 30)},
            new Conference() { Id = 2, ChairId = 2, Title = "IICC", Location = "Downtown, Washington, DC 20005", BeginDate = new DateTime(2018, 1, 11), EndDate = new DateTime(2018, 1, 20), PaperDeadline = new DateTime(2018, 1, 3)},
            new Conference() { Id = 3, ChairId = 5, Title = "ASDE", Location = "Place de la Monnaie, 1000 Bruxelles", BeginDate = new DateTime(2018, 3, 25), EndDate = new DateTime(2017, 4, 1), PaperDeadline = new DateTime(2018, 3, 15)},
        };
        context.Conferences.AddRange(conferences);

        var conferenceMembers = new[]
        {
            new ConferenceMember() { ConferenceId = 1, UserId = 4},
            new ConferenceMember() { ConferenceId = 1, UserId = 5},
            new ConferenceMember() { ConferenceId = 1, UserId = 6},
            new ConferenceMember() { ConferenceId = 1, UserId = 7},
        };
        context.ConferenceMembers.AddRange(conferenceMembers);

        var conferenceTopics = new[]
        {
            new ConferenceTopic() {ConferenceId = 1, KeywordId = 2},
            new ConferenceTopic() {ConferenceId = 2, KeywordId = 4},
            new ConferenceTopic() {ConferenceId = 3, KeywordId = 6},
        };
        context.ConferenceTopics.AddRange(conferenceTopics);

        var fileContent = "sdfsadfasdfasdfasdfasdf";
        var bytesContent = Encoding.ASCII.GetBytes(fileContent);
        var papers = new List<Paper>
        {
            new Paper() {Id = 1, Title = "Thesis on Sdfjuiowek", Author = "Jason Kwasiky", SubmissionDate = new DateTime(2017, 9, 27), Length = "Short", Content = bytesContent, ConferenceId = 1, AuthorId = 6, Format = ".txt", Status = "Submitted", FileName = "New Text Document"},
        };
        context.Papers.AddRange(papers);

        var paperTopics = new[]
        {
            new PaperTopic() { PaperId = 1, KeywordId = 1},
            new PaperTopic() { PaperId = 1, KeywordId = 2},
            new PaperTopic() { PaperId = 1, KeywordId = 3},
        };
        context.PaperTopics.AddRange(paperTopics);

        var paperReviews = new[]
        {
            new PaperReview() { PaperId = 1, UserId = 4}
        };
        context.PaperReviews.AddRange(paperReviews);

        context.SaveChanges();
    }
}
