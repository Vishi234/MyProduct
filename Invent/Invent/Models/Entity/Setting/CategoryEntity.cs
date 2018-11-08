using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Invent.Models.Entity.Setting
{
    public class CategoryEntity
    {
        public string UserId { get; set; }
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Required")]
        public string PriceRange { get; set; }
        [Required(ErrorMessage = "Required")]
        public string IGST { get; set; }
        [Required(ErrorMessage = "Required")]
        public string CGST { get; set; }
        [Required(ErrorMessage = "Required")]
        public string SGST { get; set; }
        public string UTGST { get; set; }
        public string CESS { get; set; }
        public char Status { get; set; }
        public char Flag { get; set; }

    }
}