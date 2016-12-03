using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseQuerierFrontend.Models
{
    public class AdvancedSearchResults
    {
        public string HeaderText { get; set; }
        public IEnumerable<Person> People { get; set; }
    }
}