using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models
{
    public class CMSDBInitializer : CreateDatabaseIfNotExists<CMSDBEntities>
    {
        protected override void Seed(CMSDBEntities context)
        {
            IList<User> users = new List<User>();

            users.Add(new User() { userId = 0, userName = "Grade 1", userPasswrd = "a", userEmail = "aaa@aaa" });
            users.Add(new User() { userId = 1, userName = "Grade 1", userPasswrd = "b", userEmail = "bbb@bbb" });


            context.Users.AddRange(users);

            base.Seed(context);
        }
    }
}
