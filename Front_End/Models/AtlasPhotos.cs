using System.ComponentModel.DataAnnotations;

namespace Front_End.Models
{
    public class AtlasPhoto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Photographer { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
