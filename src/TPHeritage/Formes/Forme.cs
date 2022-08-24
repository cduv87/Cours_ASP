namespace TPHeritage.Formes;

internal abstract class Forme : IEquatable<Forme>
{
    public abstract double Aire { get; }

    public abstract double Perimetre { get; }

    public override bool Equals(object? obj) 
        => this.Equals(obj as Forme);

    public bool Equals(Forme? other) 
        => other != null && this.Perimetre == other.Perimetre;

    public override string ToString() 
        => $"Aire = {this.Aire}" + Environment.NewLine + $"Périmètre = {this.Perimetre}" + Environment.NewLine;

    public static bool operator ==(Forme? left, Forme? right) 
        => EqualityComparer<Forme>.Default.Equals(left, right);

    public static bool operator !=(Forme? left, Forme? right) 
        => !(left == right);

    public override int GetHashCode() 
        => (this.Aire * this.Perimetre).GetHashCode();
}