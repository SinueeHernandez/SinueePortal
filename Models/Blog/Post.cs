using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Post
    {
        [Key]
        public int Id {get;set;}
        public string Title {get; set;}
        public string Content {get; set;}
        public ApplicationUser Autor {get; set;}
        public List<Comment> Comments {get; set;}
        public string Summary {get;set;}
        public int ImageId {get; set;}
        public virtual Image Image {get; set;}
    }
}