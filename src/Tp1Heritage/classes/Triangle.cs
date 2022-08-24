using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1Heritage.classes
{
    internal class Triangle : Forme
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }


        public Triangle(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override string? ToString()
        {

            return $"Triangle de côtés A={this.A}, B={this.B} et C={this.C} \nAire = {this.Aire} \nPérimètre = {this.Perimetre} \n";
        }


        public override double Aire
        {
            get
            {
                double p = this.Perimetre/2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
        }

        public override double Perimetre => A + B + C;

        public Triangle()
        {
        }
    }
}
