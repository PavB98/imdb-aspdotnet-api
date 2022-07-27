using System;
using System.Collections.Generic;

namespace IMDB.DataAccessLayer.Models
{
    public partial class MoviesActors
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        public Actors Actor { get; set; }
        public Movies Movie { get; set; }
    }
}
