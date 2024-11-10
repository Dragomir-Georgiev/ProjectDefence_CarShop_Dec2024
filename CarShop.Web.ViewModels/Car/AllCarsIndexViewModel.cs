﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarShop.Web.ViewModels.Car
{
    public class AllCarsIndexViewModel
    {
        public string Id { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string? CarImage { get; set; }
        public string PricePerDay { get; set; } = null!;
    }
}