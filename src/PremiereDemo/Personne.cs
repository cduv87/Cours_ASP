﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPremiere
{
    internal class Personne
    {
        private string prenom;
        private int age;

        public Personne()
        {
        }

        public Personne(string prenom)
        {
            this.prenom = prenom;
        }

        public string? Nom { get; set; }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
    }
}
