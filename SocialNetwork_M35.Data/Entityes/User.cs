using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SocialNetwork_M35.Data.Entityes
{
    public class User : IdentityUser
    {
        public string ?FirstName { get; set; }

        public string ?LastName { get; set; }

        public string ?MiddleName { get; set; }

        public DateTime BirthDate { get; set; }
        
        public string MainImage { get; set; }

        public List<string> Images { get; set; } = new List<string>();

        public string Status { get; set; }

        public string About { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + MiddleName + " " + LastName;
        }

        public User()
        {
            MainImage = "https://thispersondoesnotexist.com";
            Status = "Ура! Я в соцсети!";
            About = "Информация обо мне.";
        }
    }
}
