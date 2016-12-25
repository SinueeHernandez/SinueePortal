using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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