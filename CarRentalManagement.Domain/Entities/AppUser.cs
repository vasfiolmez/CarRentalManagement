using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Domain.Entities
{
	public class AppUser:IdentityUser<int>
	{
        //public int AppUserId { get; set; }
        //public string Username { get; set; }
        //public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? City { get; set; }
        //public string Email { get; set; }
        //public int AppRoleId { get; set; }
        //public AppRole AppRole { get; set; }

    }
}
