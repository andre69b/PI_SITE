using System.ComponentModel.DataAnnotations;

namespace LogicModelLibrary
{
    public class Contact
    {
        public Contact()
        {
        }

        [Required]
        public string Email { get; set; }
        [DataType(DataType.MultilineText), Required]
        public string Suggestions { get; set; }

    }
}