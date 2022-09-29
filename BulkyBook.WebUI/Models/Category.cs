using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.WebUI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100 only!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public virtual ICollection<SubCategory>? SubCategories { get; set; }

        public Category()
        {

        }

        public Category(int id, string name, int displayOrder) : this()
        {
            Id = id;
            Name = name;
            DisplayOrder = displayOrder;
        }
    }
}
