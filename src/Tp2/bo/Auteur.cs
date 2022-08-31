﻿namespace Tp2.bo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Auteur
    {
        private List<Facture> factures;

        public Auteur(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
            factures = new List<Facture>();
        }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public List<Facture> Factures { get { return factures; } }

        public void AddFacture(Facture f)
        {
            Factures.Add(f);
        }
    }
}
