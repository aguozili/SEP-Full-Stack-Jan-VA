using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class FavoriteListModel
    {
        public int UserId { get; set; }
        public List<FavoriteModel> favorites { get; set; }
    }
}
