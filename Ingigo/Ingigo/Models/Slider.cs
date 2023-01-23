using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ingigo.Models
{
    public class Slider
    {
        public int Id{ get; set; }
        [StringLength(maximumLength:44)]
        public string Title1 { get; set; }
        [StringLength(maximumLength: 300)]
        public string Desc { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
