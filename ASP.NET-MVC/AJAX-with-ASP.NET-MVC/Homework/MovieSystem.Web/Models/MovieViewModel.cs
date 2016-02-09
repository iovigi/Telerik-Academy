using MovieSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MovieSystem.Web.Models
{
    public class MovieViewModel
    {
        public int ID { get; set; }

        public string Title { get; set; }
        public string Director { get; set; }
        public long Year { get; set; }
        public string LeadingMaleRole { get; set; }
        public string LeadingFemaleRole { get; set; }
        public int Age { get; set; }
        public string Studio { get; set; }
        public string StudioAddress { get; set; }

        public static Expression<Func<Movie, MovieViewModel>> From
        {
            get
            {
                return movie => new MovieViewModel()
                {
                    ID = movie.ID,
                    Title = movie.Title,
                    Director = movie.Director,
                    Year = movie.Year,
                    LeadingMaleRole = movie.LeadingMaleRole,
                    LeadingFemaleRole = movie.LeadingFemaleRole,
                    Age = movie.Age,
                    Studio = movie.Studio,
                    StudioAddress = movie.StudioAddress
                };
            }
        }

        public Movie To
        {
            get
            {
                return new Movie()
                {
                    ID = this.ID,
                    Title = this.Title,
                    Director = this.Director,
                    Year = this.Year,
                    LeadingMaleRole = this.LeadingMaleRole,
                    LeadingFemaleRole = this.LeadingFemaleRole,
                    Age = this.Age,
                    Studio = this.Studio,
                    StudioAddress = this.StudioAddress
                };
            }
        }
    }
}