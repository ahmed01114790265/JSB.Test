using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Contracts.DTO
{
    public class BookDTO
    {
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        [Range(0,double.MaxValue)]
        public double Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }
}
