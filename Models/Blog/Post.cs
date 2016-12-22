using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class Post
    {
        public string Content {get; set;}
        public ApplicationUser Autor {get; set;}
        public List<Comment> Comments {get; set;}
    }
}