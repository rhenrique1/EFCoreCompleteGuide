using System.Collections.Generic;
using Wizlib_Model.Models;
using System.Web.Mvc;

namespace Wizlib_Model.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> PublisherList { get; set; }
    }
}