using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Domain.Entities
{
	public class AppRole:IdentityRole<int>
	{
        //public int AppRoleId { get; set; }
        //public string AppRoleName { get; set; }
        //public List<AppUser> AppUsers { get; set; }
    }
}
