using System.ComponentModel.DataAnnotations;

namespace E_Mart.Models
{
    public class Groccery
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
