using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Contracts.DTO
{
    public class CategoryDTO
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [MaxLength(50,ErrorMessage ="Length mustnot be more than50")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Descriotion is required")]
        [MaxLength(400, ErrorMessage = "Length must not be more than 400")]
        public string Description { get; set; }
    }
}
