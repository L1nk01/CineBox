using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Common
{
    public class GenericSeriesViewModel : GenericViewModel
    {
        [Required(ErrorMessage = "A video link must be specified")]
        public string VideoLink { get; set; }
        [Required(ErrorMessage = "A producer must be selected")]
        public int ProducerId { get; set; }
        [Required(ErrorMessage = "At least 1 genre must be selected")]
        public int PrimaryGenreId { get; set; }
        public int? SecondaryGenreId { get; set; }
    }
}
