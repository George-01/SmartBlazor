using System.ComponentModel.DataAnnotations;

namespace SmartBlazor.Data
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
    }
}
