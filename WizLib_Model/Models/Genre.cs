using System.ComponentModel.DataAnnotations.Schema;

namespace Wizlib_Model.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        // public int DisplayOrder { get; set; }
    }
}