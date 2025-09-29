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

        public List<string> Images { get; set; }

        public string Status { get; set; }

        public string About { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + MiddleName + " " + LastName;
        }

        public User()
        {
            MainImage = "https://via.placeholder.com/500";
            Images = new List<string>();
            Status = "Ура! Я в соцсети!";
            About = "Информация обо мне.";
        }
    }
}
