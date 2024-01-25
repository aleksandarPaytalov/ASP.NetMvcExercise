using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BooksListEditor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; } = null!;

        [DisplayName("Order Display")]
        [Range(1, 50, ErrorMessage = "Order Display must be between 1 and 50")]
        public int Order { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
