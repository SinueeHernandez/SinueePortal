using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Comment
    {
        [Key]
        public int Id {get; set;}
        public string Message {get; set;}
        public ApplicationUser Autor {get; set;}
    }
}