using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presents.Data.Entities
{
    public class Gift
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        public string ImageURL { get; set; }

        [ForeignKey("Gift")]
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
        public bool IsTaken { get; set; }
        public List<Category> ListOfCategories { get; set; } = new List<Category>();
    }
}
