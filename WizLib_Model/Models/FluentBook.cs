using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wizlib_Model.Models
{
    public class FluentBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
        public int BookDetailId { get; set; }
        public FluentBookDetail BookDetail { get; set; }
        public int PublisherId { get; set; }
        public FluentPublisher Publisher { get; set; }
        public ICollection<FluentBookAuthor> BookAuthors { get; set; }    
    }
}