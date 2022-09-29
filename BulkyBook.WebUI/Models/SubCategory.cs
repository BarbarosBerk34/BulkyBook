using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.WebUI.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Book>? Books { get; set; }


        public SubCategory()
        {

        }

        public SubCategory(int id, int categoryId, string name) : this()
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
        }
    }
}
