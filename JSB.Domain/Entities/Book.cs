using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Domain.Entities
{
public class Book
    {
        public Guid Id { get; set; }    

        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public  double Price { get; set; }
        public int Stock { get; set; }  

        public Guid CategoryId { get; set; }
        public virtual Category category  { get; set; }
    }
}
