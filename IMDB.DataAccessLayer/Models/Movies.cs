using System;
using System.Collections.Generic;

namespace IMDB.DataAccessLayer.Models
{
    public partial class Movies
    {
        public Movies()
        {
            MoviesActors = new HashSet<MoviesActors>();
        }

        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string PosterImageSource { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public string Plot { get; set; }
        public int Producer { get; set; }

        public Producers ProducerNavigation { get; set; }
        public ICollection<MoviesActors> MoviesActors { get; set; }
    }
}
