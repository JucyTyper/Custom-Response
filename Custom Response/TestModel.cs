

using System.ComponentModel.DataAnnotations;

namespace Custom_Response
{
    public class TestModel
    {
        [Required]
        public int Id { get; set; }
        [RegularExpression(@"^\+?[0-9\s.-]+$", ErrorMessage = "Invalid phone number format.")]
        public string? Name { get; set; }
    }
}
