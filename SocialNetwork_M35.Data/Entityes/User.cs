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
    }
}
