﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Animals_Web.Animals.Dtos
{
    public class AnimalRequest
    {

        public string Name { get; set; }

        public double Weight { get; set; }

       
        public string Country { get; set; }

        public int Age { get; set; }





    }
}
