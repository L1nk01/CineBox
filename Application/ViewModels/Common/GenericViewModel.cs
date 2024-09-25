using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Common
{
    public class GenericViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A name must be specified")]
        public string Name { get; set; }
        [Required(ErrorMessage = "An image link must be specified")]
        public string ImageLink { get; set; }
        [Required(ErrorMessage = "A description must be specified")]
        public string Description { get; set; }
    }
}
