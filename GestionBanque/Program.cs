using GestionBanque.Models;

//utilité : ne pas laisser la liste en free access, chercher seulement des infos spécifique et qu'on connais
//via le numéro de compte ici
Personne p1 = new Personne();
p1.Nom = "Pendragon";
p1.Prenom = "Arthur";
p1.DateNaiss = DateTime.Now;
Personne p2 = new();
p2.Prenom = "Arthur";
p2.Nom = "Pendragon";
p2.DateNaiss = DateTime.Now;

Courant c1 = new Courant();
c1.Numero = "BE1234";
c1.Titulaire = p1;
c1.Depot(500);

Courant c2 = new Courant();
c2.Numero = "BE56789";
c2.Titulaire = p2;
c2.Depot(500.10);

Banque banque = new();
banque.Nom = "Fortis";

Console.WriteLine($"Le solde du compte {c1.Numero} de {c1.Titulaire.Nom} est de {c1.Solde}");

c1.Retrait(200);
Console.WriteLine($"Le solde du compte {c1.Numero} de {c1.Titulaire.Nom} est de {c1.Solde}");
c1.Retrait(500);
Console.WriteLine($"Le solde du compte {c1.Numero} de {c1.Titulaire.Nom} est de {c1.Solde}");

c1.LigneDeCredit = 500;
c1.Retrait(1000);
Console.WriteLine($"Le solde du compte {c1.Numero} de {c1.Titulaire.Nom} est de {c1.Solde}");

banque.Ajouter(c1);
banque.Ajouter(c2);

double monArgent = c1 + c2;
Console.WriteLine("Total des avoirs : " + monArgent);

try
{
    banque.Ajouter(c1);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine(banque.AvoirDesComptes(p1));
c1.AppliquerInteret();
//b1.Supprimer(c1.Numero);
//try
//{
//    b1.Supprimer(c1.Numero);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//exemple pour récupérer une info voulue
//Console.WriteLine(b1["BE1234"].Solde);