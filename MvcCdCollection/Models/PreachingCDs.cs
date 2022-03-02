using System.ComponentModel.DataAnnotations;

namespace MvcCdCollection.Models
{
    public class PreachingCDs
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Author { get; set; }

    }
}
