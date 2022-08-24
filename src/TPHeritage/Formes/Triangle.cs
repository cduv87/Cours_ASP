namespace TPHeritage.Formes;

internal class Triangle : Forme
{
    public int A { get; set; }

    public int B { get; set; }

    public int C { get; set; }

    private double P => (this.A + this.B + this.C) / 2d;

    public override double Aire 
        => Math.Sqrt(this.P * (this.P - this.A) * (this.P - this.B) * (this.P - this.C));

    public override double Perimetre 
        => this.A + this.B + this.C;

    public override string ToString() 
        => $"Triangle de coté A={this.A}, B={this.B}, C={this.C}" + Environment.NewLine + base.ToString();
}