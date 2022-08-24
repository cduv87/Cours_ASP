using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1Heritage.classes
{
    internal class Rectangle : Forme
    {
        public int Largeur { get; set; }
        public int Longueur { get; set; }


        public Rectangle(int largeur, int longueur)
        {
            Largeur = largeur;
            Longueur = longueur;
        }

        public Rectangle()
        {
        }

        public override string? ToString()
        {

            return $"Rectangle de longueur {this.Longueur} et largeur {this.Largeur} \nAire = {this.Aire} \nPérimètre = {this.Perimetre} \n";
        }

        public override double Aire => Largeur * Longueur;

        public override double Perimetre => 2 * Longueur + 2 * Largeur;
    }

}
