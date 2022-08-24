using System.Drawing;
using Tp1Heritage.classes;
using Rectangle = Tp1Heritage.classes.Rectangle;

namespace Tp1Heritage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var formes = new List<Forme>();
            formes.Add(new Cercle { Rayon = 3 });
            formes.Add(new Rectangle { Largeur = 3, Longueur = 4 });
            formes.Add(new Carre { Longueur = 3 });
            formes.Add(new Triangle { A = 4, B = 5, C = 6 });

            foreach (var forme in formes)
            {
                Console.WriteLine(forme);
            }
            Console.ReadKey();
        }

    }
}