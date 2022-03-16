﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class PurchaseRequestModel
    {
        public int UserId { get; set; }
        public int MovieID { get; set; }
        public string Title { get; set; }
        public int PosterUrl { get; set; }
        public DateTime PurchasedDate { get; set; }
        public decimal Price { get; set; }
        public int PurchaseNumber { get; set; }

    }
}
