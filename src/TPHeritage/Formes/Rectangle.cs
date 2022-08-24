namespace TPHeritage.Formes;

internal class Rectangle : Forme
{
    public int Largeur { get; set; }

    public virtual int Longueur { get; set; }

    public override double Aire 
        => this.Largeur * this.Longueur;

    public override double Perimetre 
        => 2 * this.Largeur + 2 * this.Longueur;

    public override string ToString() 
        => this.ToString(false);

    public string ToString(bool isCarre)
    {
        if (isCarre)
            return base.ToString();

        return $"Rectangle de longueur={this.Longueur} et largeur={this.Largeur}" + Environment.NewLine + base.ToString();
    }
}