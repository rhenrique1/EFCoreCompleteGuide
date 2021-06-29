using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wizlib_Model.Models
{
    public class FluentPublisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<FluentBook> Books { get; set; }
    }
}