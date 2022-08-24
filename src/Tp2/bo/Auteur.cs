namespace ProjetLinq.BO
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
            this.Nom = nom;
            this.Prenom = prenom;
            this.factures = new List<Facture>();
        }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public List<Facture> Factures { get { return this.factures; } }

        public void AddFacture(Facture f)
        {
            this.Factures.Add(f);
        }
    }
}
