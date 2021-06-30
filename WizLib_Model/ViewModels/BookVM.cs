using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Wizlib_Model.Models;

namespace Wizlib_Model.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> PublisherList { get; set; }
    }
}