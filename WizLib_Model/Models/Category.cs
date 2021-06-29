using System.ComponentModel.DataAnnotations;

namespace Wizlib_Model.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}