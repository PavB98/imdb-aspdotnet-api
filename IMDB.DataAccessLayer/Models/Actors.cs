using System;
using System.Collections.Generic;

namespace IMDB.DataAccessLayer.Models
{
    public partial class Actors
    {
        public Actors()
        {
            MoviesActors = new HashSet<MoviesActors>();
        }

        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string ActorBio { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        public ICollection<MoviesActors> MoviesActors { get; set; }
    }
}
