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
        [Required(ErrorMessage ="Name is required")]
        [MaxLength(50,ErrorMessage ="Length must not be morethan 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [MaxLength(50, ErrorMessage = "Length must not be more than 50")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(300, ErrorMessage = "Length must not be more than 300")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0,double.MaxValue,ErrorMessage = "Price must not be negative")]
        public double Price { get; set; }


        [Range(0, int.MaxValue,ErrorMessage = "Stock must not be negative")]
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }

    }
}
