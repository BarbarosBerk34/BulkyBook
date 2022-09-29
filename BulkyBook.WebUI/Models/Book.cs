using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.WebUI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Writer { get; set; }
        public decimal Price { get; set; }
        public virtual SubCategory? SubCategory { get; set; }

        public Book()
        {

        }

        public Book(int id, int subCategoryId, string name, string publisher, string writer, decimal price) : this()
        {
            Id = id;
            SubCategoryId = subCategoryId;
            Name = name;
            Publisher = publisher;
            Writer = writer;
            Price = price;
        }
    }
}
