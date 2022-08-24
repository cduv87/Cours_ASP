namespace TPHeritage.Formes;

internal class Carre : Rectangle
{
    public override int Longueur 
        => this.Largeur;

    public override string ToString() 
        => $"Carré de coté={this.Longueur}" + Environment.NewLine + this.ToString(true);

    public static Carre operator +(Carre left, Carre right) 
        => new() { Largeur = left.Largeur + right.Largeur };
}