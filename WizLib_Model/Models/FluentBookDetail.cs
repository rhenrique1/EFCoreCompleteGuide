using System.ComponentModel.DataAnnotations;

namespace Wizlib_Model.Models
{
    public class FluentBookDetail
    {
        public int Id { get; set; }
        public int NumberOfChapters { get; set; }
        public int NumberOfPages { get; set; }
        public double Weight { get; set; }
    }
}