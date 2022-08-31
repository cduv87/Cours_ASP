namespace Tp2.bo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Facture
    {
        public Facture(decimal montant, Auteur auteur)
        {
            Montant = montant;
            Auteur = auteur;
        }

        public decimal Montant { get; set; }

        public Auteur Auteur { get; set; }
    }
}
