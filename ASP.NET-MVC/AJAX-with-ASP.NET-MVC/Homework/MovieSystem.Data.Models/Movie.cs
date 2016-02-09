

namespace MovieSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }
        public string Director { get; set; }
        public long Year { get; set; }
        public string LeadingMaleRole { get; set; }
        public string LeadingFemaleRole { get; set; }
        public int Age { get; set; }
        public string Studio { get; set; }
        public string StudioAddress { get; set; }
    }
}
