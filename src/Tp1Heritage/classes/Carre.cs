using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp1Heritage.classes;

namespace Tp1Heritage.classes
{
    internal class Carre : Forme
{
        public int Longueur { get; set; }

        public Carre(int longueur)
        {
            Longueur = longueur;
        }

        public Carre()
        {
        }
        public override string? ToString()
        {

            return $"Carré de côté {this.Longueur} \nAire = {this.Aire} \nPérimètre = {this.Perimetre} \n";
        }

        public override double Aire => Longueur * Longueur;

        public override double Perimetre => 4 * Longueur;
    }
}
