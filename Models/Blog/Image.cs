using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Image
    {
        [KeyAttribute]
        public int Id {get;set;}
        public string Name {get; set;}
        public string Type {get; set;}
        public byte[] Data {get; set;}
    }
}