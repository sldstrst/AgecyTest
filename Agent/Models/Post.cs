using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Agent.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public int ColKomnat { get; set; }

        public int Price { get; set; }

        public float Ploshad { get; set; }

        public string Opisanie { get; set; }
    }
}