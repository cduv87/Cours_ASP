using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1Heritage.classes
{
    internal class Cercle : Forme
    {
        public int Rayon { get; set; }


        public Cercle(int rayon)
        {
            Rayon = rayon;
        }

        public Cercle()
        {
        }

        public override string? ToString()
        {

            return $"Cercle de rayon {this.Rayon} \nAire = {this.Aire} \nPérimètre = {this.Perimetre} \n";
        }

        public override double Aire => Math.PI * Math.Pow(this.Rayon, 2);

        public override double Perimetre => Math.PI * (this.Rayon * 2);
    }
}
