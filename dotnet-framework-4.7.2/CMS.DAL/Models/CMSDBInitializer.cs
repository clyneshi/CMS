using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace CMS.DAL.Models
{
    public class CMSDBInitializer : CreateDatabaseIfNotExists<CMSContext>
    {
        protected override void Seed(CMSContext context)
        {
            var keywords = new List<Keyword>
            {
                new Keyword() {keywrdId = 1, keywrdName = "Geophysics and Geology", keywrdGenre = "Earth Sciences"},
                new Keyword() {keywrdId = 2, keywrdName = "Mineralogy", keywrdGenre = "Earth Sciences"},
                new Keyword() {keywrdId = 3, keywrdName = "Hydrology", keywrdGenre = "Earth Sciences"},
                new Keyword() {keywrdId = 4, keywrdName = "Meteorology and Climate Change", keywrdGenre = "Earth Sciences"},
                new Keyword() {keywrdId = 5, keywrdName = "Oceanography", keywrdGenre = "Earth Sciences"},
                new Keyword() {keywrdId = 6, keywrdName = "Earth Observation", keywrdGenre = "Earth Sciences"},
                new Keyword() {keywrdId = 7, keywrdName = "Biology", keywrdGenre = "Life Sciences"},
                new Keyword() {keywrdId = 8, keywrdName = "Botany", keywrdGenre = "Life Sciences"},
                new Keyword() {keywrdId = 9, keywrdName = "Zoology", keywrdGenre = "Life Sciences"},
                new Keyword() {keywrdId = 10, keywrdName = "Molecular Biology", keywrdGenre = "Life Sciences"},
                new Keyword() {keywrdId = 11, keywrdName = "Agronomy", keywrdGenre = "Life Sciences"},
                new Keyword() {keywrdId = 12, keywrdName = "Food Chemisitry", keywrdGenre = "Life Sciences"}
            };
            context.Keywords.AddRange(keywords);

            var roles = new List<Role>
            {
                new Role() {roleId = 1, roleType = "Admin"},
                new Role() {roleId = 2, roleType = "Chair"},
                new Role() {roleId = 3, roleType = "Reviewer"},
                new Role() {roleId = 4, roleType = "Author"},
            };
            context.Roles.AddRange(roles);

            var users = new List<User>
            {
                new User() { userId = 1, userName = "admin", userPasswrd = "ad", userEmail = "admin@cms.com", roleId = 1 },
                new User() { userId = 2, userName = "chair1", userPasswrd = "ch", userEmail = "chair1@cms.com", roleId = 2 },
                new User() { userId = 3, userName = "chair2", userPasswrd = "ch", userEmail = "chair2@cms.com", roleId = 2 },
                new User() { userId = 4, userName = "reviewer1", userPasswrd = "re", userEmail = "reviewer1@cms.com", roleId = 3 },
                new User() { userId = 5, userName = "reviewer2", userPasswrd = "e", userEmail = "reviewer2@cms.com", roleId = 3 },
                new User() { userId = 6, userName = "author1", userPasswrd = "au", userEmail = "author1@cms.com", roleId = 4 },
                new User() { userId = 7, userName = "author2", userPasswrd = "au", userEmail = "author2@cms.com", roleId = 4 },
            };
            context.Users.AddRange(users);

            var expertises = new List<Expertise>
            {
                new Expertise() { Id = 1, userId = 4, keywrdId = 5},
                new Expertise() { Id = 2, userId = 4, keywrdId = 6},
                new Expertise() { Id = 3, userId = 4, keywrdId = 7},
                new Expertise() { Id = 4, userId = 5, keywrdId = 10},
                new Expertise() { Id = 5, userId = 5, keywrdId = 12}
            };
            context.Expertises.AddRange(expertises);

            var conferences = new List<Conference>
            {
                new Conference() { confId = 1, chairId = 2, confTitle = "Innovate Bopitech 2017", confLocation = "Melbourn CBD 343", confBeginDate = new DateTime(2017, 12, 23), confEndDate = new DateTime(2017, 12, 30), paperDeadline = new DateTime(2017, 11, 30)},
                new Conference() { confId = 2, chairId = 2, confTitle = "IICC", confLocation = "Downtown, Washington, DC 20005", confBeginDate = new DateTime(2018, 1, 11), confEndDate = new DateTime(2018, 1, 20), paperDeadline = new DateTime(2018, 1, 3)},
                new Conference() { confId = 3, chairId = 5, confTitle = "ASDE", confLocation = "Place de la Monnaie, 1000 Bruxelles", confBeginDate = new DateTime(2018, 3, 25), confEndDate = new DateTime(2017, 4, 1), paperDeadline = new DateTime(2018, 3, 15)},
            };
            context.Conferences.AddRange(conferences);

            var conferenceMembers = new List<ConferenceMember>
            {
                new ConferenceMember() { Id = 1, confId = 1, userId = 4},
                new ConferenceMember() { Id = 2, confId = 1, userId = 5},
                new ConferenceMember() { Id = 3, confId = 1, userId = 6},
                new ConferenceMember() { Id = 4, confId = 1, userId = 7},
            };
            context.ConferenceMembers.AddRange(conferenceMembers);

            var conferenceTopics = new List<ConferenceTopic>
            {
                new ConferenceTopic() {Id = 1, confId = 1, keywrdId = 2},
                new ConferenceTopic() {Id = 2, confId = 2, keywrdId = 4},
                new ConferenceTopic() {Id = 3, confId = 3, keywrdId = 6},
            };
            context.ConferenceTopics.AddRange(conferenceTopics);

            var fileContent = "sdfsadfasdfasdfasdfasdf";
            var bytesContent = Encoding.ASCII.GetBytes(fileContent);
            var papers = new List<Paper>
            {
                new Paper() {paperId = 1, paperTitle = "Thesis on Sdfjuiowek", paperAuthor = "Jason Kwasiky", paperSubDate = new DateTime(2017, 9, 27), paperLength = "Short", paperContent = bytesContent, confId = 1, auId = 4, paperFormat = ".txt", paperStatus = "Submitted", paperFileName = "New Text Document"},
            };
            context.Papers.AddRange(papers);

            var paperTopics = new List<PaperTopic>
            {
                new PaperTopic() { Id = 1, paperId = 1, keywrdId = 1},
                new PaperTopic() { Id = 2, paperId = 1, keywrdId = 2},
                new PaperTopic() { Id = 3, paperId = 1, keywrdId = 3},
            };
            context.PaperTopics.AddRange(paperTopics);

            var paperReviews = new List<PaperReview>
            {
                new PaperReview() { Id = 1, paperId = 1, userId = 4}
            };
            context.PaperReviews.AddRange(paperReviews);

            base.Seed(context);
        }
    }
}
