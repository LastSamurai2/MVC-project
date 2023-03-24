using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library3.Models.ViewModels
{
    public class BooksViewBooks
    {

        public Books Books { get; set; }
        public IEnumerable<Authors> Authors { get; set; }
        public IEnumerable<SelectListItem> CSelectListItem(IEnumerable<Authors> Items)
        {
            List<SelectListItem> AuthorsList = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem()
            {
                Text = "----wybierz----",
                Value = "0"
            };
            AuthorsList.Add(sli);
            foreach (Authors author in Items)
            {
                sli = new SelectListItem
                {
                    Text = author.Name + " " + author.Surname,
                    Value = author.Id.ToString()
                };
                AuthorsList.Add(sli);
            }
            return AuthorsList;
        }
    }
}
