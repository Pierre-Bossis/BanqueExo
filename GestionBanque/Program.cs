using GestionBanque.Models;

Personne p1 = new Personne();
p1.Nom = "Pendragon";
p1.Prenom = "Arthur";
p1.DateNaiss = DateTime.Now;

Courant c1 = new Courant();
c1.Numero = "BE1234";
c1.Titulaire = p1;
c1.Depot(500);

Banque b1 = new();
b1.Nom = "Fortis";

Console.WriteLine($"Le solde du compte {c1.Numero} de {c1.Titulaire.Nom} est de {c1.Solde}");

c1.Retrait(200);
Console.WriteLine($"Le solde du compte {c1.Numero} de {c1.Titulaire.Nom} est de {c1.Solde}");
c1.Retrait(500);
Console.WriteLine($"Le solde du compte {c1.Numero} de {c1.Titulaire.Nom} est de {c1.Solde}");

c1.LigneDeCredit = 500;
c1.Retrait(1000);
Console.WriteLine($"Le solde du compte {c1.Numero} de {c1.Titulaire.Nom} est de {c1.Solde}");

b1.Ajouter(c1);
try
{
	b1.Ajouter(c1);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Courant? recup = b1["BE1234"];