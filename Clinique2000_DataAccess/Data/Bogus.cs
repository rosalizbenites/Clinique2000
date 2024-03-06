using Bogus;
using Clinique2000_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_DataAccess.Data
{
    public class Bogus
    {
        public List<User> Users { get; set; }

        ~Bogus() {
            Randomizer.Seed = new Random();
        }

        public Bogus(int count=20)
        {
            Randomizer.Seed = new Random(count);

            var usersId = 0;
            var testUsers = new Faker<User>()

                .RuleFor(u => u.Id, f => Guid.NewGuid().ToString())
                .RuleFor(u => u.Prenom, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.Nom, (f, u) => f.Name.LastName())
                .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email())
                .RuleFor(u => u.Email, (f, u) => f.Phone.PhoneNumber("(###) ###-####"));

            var user = testUsers.Generate();
        }
    }
}
