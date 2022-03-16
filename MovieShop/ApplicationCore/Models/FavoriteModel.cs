using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class FavoriteModel
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }

        public string MovieTitle { get; set; }
        public string PosterUrl { get; set; }
    }
}
