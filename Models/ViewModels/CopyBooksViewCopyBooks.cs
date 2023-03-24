using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library3.Models.ViewModels
{
    public class CopyBooksViewCopyBooks
    {

        public CopyOfTheBook CpBook { get; set; }
        public IEnumerable<Books> Book { get; set; }
        public IEnumerable<SelectListItem> CSelectListItem(IEnumerable<Books> Items)
        {
            List<SelectListItem> BooksList = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem()
            {
                Text = "----wybierz----",
                Value = "0"
            };
            BooksList.Add(sli);
            foreach (Books book in Items)
            {
                sli = new SelectListItem
                {
                    Text = book.Title,
                    Value = book.Id.ToString()
                };
                BooksList.Add(sli);
            }
            return BooksList;
        }
    }
}
