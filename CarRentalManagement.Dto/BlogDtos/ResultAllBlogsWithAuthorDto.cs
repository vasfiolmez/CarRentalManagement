using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Dto.BlogDtos
{
    public class ResultAllBlogsWithAuthorDto
    {
        public int blogId { get; set; }
        public string title { get; set; }
        public string authorName { get; set; }
        public object categoryName { get; set; }
        public int authorId { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImageUrl { get; set; }
        public string coverImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime createdDate { get; set; }
        public int blogCategoryID { get; set; }
    }
}
