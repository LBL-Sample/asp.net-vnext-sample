using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.TagHelper.Web.Models
{
    public class SelectViewModel
    {
        public string CountryCode { get; set; }

        public IEnumerable<string> CountryCodes { get; set; }
    }
}
