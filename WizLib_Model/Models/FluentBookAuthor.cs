using System.ComponentModel.DataAnnotations.Schema;

namespace Wizlib_Model.Models
{
    public class FluentBookAuthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
    }
}