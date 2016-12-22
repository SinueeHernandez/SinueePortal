using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class Comment
    {
        public string Message {get; set;}
        public ApplicationUser Autor {get; set;}
    }
}