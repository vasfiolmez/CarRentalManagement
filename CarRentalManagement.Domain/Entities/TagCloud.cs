using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Domain.Entities
{
    public class TagCloud
    {
        public int TagCloudID { get; set; }
        public string Name { get; set;}
        public int BlogID { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
