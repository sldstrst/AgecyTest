using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Agent.Models
{
    public class VyviskaObModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int ColKomnat { get; set; }

        [Required]
        public float Ploshad { get; set; }

        [Required]
        public string Opisanie { get; set; }
    }
}