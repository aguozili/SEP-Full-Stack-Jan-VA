﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class PurchaseDetailsModel
    {
        public int UserId { get; set; }
        
        public List<PurchaseModel> Purchases { get; set; }
        //public List<MovieModel> Movies  { get; set; }

        public List<MovieModel> Movies { get; set; }


    }
}
