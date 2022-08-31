using ProjetLinq.BO;
using Tp2.bo;

List<Auteur> ListeAuteurs = new List<Auteur>();
List<Livre> ListeLivres = new List<Livre>();

void InitialiserDatas()
{
    ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
    ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
    ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
    ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
    ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
    ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
    ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
    ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
    ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
    ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
    ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
    ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
    ListeAuteurs.ElementAt(0).AddFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
    ListeAuteurs.ElementAt(0).AddFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
    ListeAuteurs.ElementAt(1).AddFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
    ListeAuteurs.ElementAt(2).AddFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
    ListeAuteurs.ElementAt(3).AddFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));

}

InitialiserDatas();

foreach (Auteur a in ListeAuteurs)
    Console.WriteLine($"Nom : {a.Nom}\n Prenom : {a.Prenom}\n Facture : {a.Factures}\n");

/*1*/
var PrenomNomG = ListeAuteurs.Where(a => a.Nom.StartsWith("g", StringComparison.CurrentCultureIgnoreCase)).Select(a => a.Prenom);

Console.WriteLine($"_1 SELECT Prenom FROM Auteurs WHERE Nom START WITH g :\n");
foreach (String a in PrenomNomG)
    Console.WriteLine(a);

/*2*/

var l1 = ListeLivres.Select(a => a.Auteur).GroupBy(i => i);
Console.WriteLine($"\n _2 *1* Auteurs WITH MAXIMUM Livres :\n");
foreach (var a in l1)
    Console.WriteLine("{0} {1}", a.Key.Nom, a.Count());

/*2 ALT1*/
var l2 = ListeLivres.GroupBy(i => i.Auteur);
Console.WriteLine($"\n _2 *2* Auteurs WITH MAXIMUM Livres :\n");
foreach (var a in l2)
    Console.WriteLine("{0} {1}", a.Key.Nom, a.Count());

/*2 ALT2*/
var l3 = ListeLivres.GroupBy(j => j.Auteur, (key, group) => new
{
    Key = key,
    Count = group.Count()
}).OrderByDescending(a => a.Count).FirstOrDefault();

Console.WriteLine($"\n _2 *3* Auteurs WITH MAXIMUM Livres :\n");
Console.WriteLine("{0} {1}", l3.Key.Nom, l3.Count);

/*4*/

var titreMaxPage = ListeLivres.OrderByDescending(a => a.NbPages).FirstOrDefault().Titre;
Console.WriteLine($"\n _4 *1* Titre WITH MAXIMUM pages :\n");

Console.WriteLine($"{titreMaxPage}");

/*4* ALT2*/

var titreMaxPage2 = ListeLivres.MaxBy(l => l.NbPages).Titre;
Console.WriteLine($"\n _4 *2* Titre WITH MAXIMUM pages :\n");
Console.WriteLine($"{titreMaxPage2}");

/*3*/

var MoyenParAuteur = ListeLivres.GroupBy(a => a.Auteur, (key, livres) => new { key = key, moy = livres.Average(a => a.NbPages) });

Console.WriteLine($"\n _3 moy pages par livres par auteurs :\n");
foreach(var k in MoyenParAuteur)
    Console.WriteLine("{0} {1}", k.key.Nom , k.moy);

/*7*/

var alpha = ListeLivres.Select(a => a.Titre).OrderBy(a => a);
Console.WriteLine($"\n _7 titre by alphabet :\n");
foreach (var k in alpha)
    Console.WriteLine(k);

/*5*/
Console.WriteLine($"\n _5 cb gagne auteurs en moy :\n");

var MoyGagneAuteur = ListeAuteurs.SelectMany(a => a.Factures).Average(b => b.Montant);
Console.WriteLine($"{MoyGagneAuteur}");

/*5*ALT1*/

var MoyGagneAuteur2 = ListeAuteurs.GroupBy(a => a, (a, f) => new
{
    key = a,
    moyfacture = f.SelectMany(a => a.Factures).Average(a=>a.Montant)
});
foreach(var i in MoyGagneAuteur2)
    Console.WriteLine("Auteur : {0} MoyFacture : {1}", i.key.Nom, i.moyfacture);

