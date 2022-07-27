using System;
using System.Collections.Generic;

namespace IMDB.DataAccessLayer.Models
{
    public partial class Producers
    {
        public Producers()
        {
            Movies = new HashSet<Movies>();
        }

        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public string ProducerBio { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Company { get; set; }
        public string Gender { get; set; }

        public ICollection<Movies> Movies { get; set; }
    }
}
