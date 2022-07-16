using System;
using System.IO;
using System.Collections.Generic;

namespace CSharquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Création de l'aquarium
            Aquarium cshark = new Aquarium("CSharquarium");

            // Création et ajout des 2 premières algues

            cshark.AjouterAlgue(2);

            // Création des 12 premiers poissons

            Bar barMale = new Bar("Jean", 0, 7, Sexe.Mâle);
            Bar barFemelle = new Bar("Janine", 0, 7, Sexe.Femelle);

            cshark.AjouterPoisson(barMale);
            cshark.AjouterPoisson(barFemelle);

            Carpe carpeMale = new Carpe("Luc", 0, 8, Sexe.Mâle);
            Carpe carpeFemelle = new Carpe("Lucie", 0, 8, Sexe.Femelle);

            cshark.AjouterPoisson(carpeMale);
            cshark.AjouterPoisson(carpeFemelle);

            Merou merouMale = new Merou("Marc", 0, Sexe.Mâle);
            Merou merouFemelle = new Merou("Marie", 0, Sexe.Femelle);

            cshark.AjouterPoisson(merouMale);
            cshark.AjouterPoisson(merouFemelle);

            PoissonClown poissonClownMale = new PoissonClown("Nemo", 0, Sexe.Mâle);
            PoissonClown poissonClownFemelle = new PoissonClown("Nina", 0, Sexe.Femelle);

            cshark.AjouterPoisson(poissonClownMale);
            cshark.AjouterPoisson(poissonClownFemelle);

            Sole soleMale = new Sole("Patrick", 0, 6, Sexe.Mâle);
            Sole soleFemelle = new Sole("Patricia", 0, 6, Sexe.Femelle);

            cshark.AjouterPoisson(soleMale);
            cshark.AjouterPoisson(soleFemelle);

            Thon thonMale = new Thon("Carlos", 0, Sexe.Mâle);
            Thon thonFemelle = new Thon("Charlotte", 0, Sexe.Femelle);

            cshark.AjouterPoisson(thonMale);
            cshark.AjouterPoisson(thonFemelle);

            // Tour 0 - Présentation des premiers résidents

            int nbTours = 0;

            StreamWriter sw = new StreamWriter("C:\\CSharquariumSaves\\Tour" + nbTours + ".txt"); //// Création de fichier texte dans C:\CSharquariumSaves (j'ai dû créer un dossier car C: inaccessible sur la VM)

            Console.WriteLine("----- Tour " + nbTours + " -----");
            sw.WriteLine("----- Tour " + nbTours + " -----\n");

            Console.WriteLine("\nBienvenue dans CSharquarium. Voici nos premiers résidents: \n");

            foreach(string s in cshark.Inventaire())
            {
                Console.WriteLine(s);
                sw.WriteLine(s);
            }

            Console.WriteLine("\nSouhaitez-vous ajouter d'autres résidents? 1 - Oui ou 2- Non");

            int editerOuPasEditer;
            while (!int.TryParse(Console.ReadLine(), out editerOuPasEditer))
            {
                Console.WriteLine("Veuillez entrer un chiffre valide!");
            }
            if (editerOuPasEditer == 1)
            {
                sw.WriteLine(cshark.Editer());
            }
            Console.WriteLine("\nAppuyer sur Enter pour faire passer la nuit!");
            Console.ReadLine();
            sw.Close();

            // Tours 1 à 30

            for (int i = 0; i < 30; i++)
            {
                nbTours++;
                sw = new StreamWriter($"C:\\CSharquariumSaves\\Tour{nbTours}.txt");  //// Re-création des fichiers texte / tour (toujours le doss dans C: attention)

                Console.WriteLine($"\n----- Tour {nbTours} -----\n");
                sw.WriteLine($"\n----- Tour {nbTours} -----\n");

                foreach(string s in cshark.PasserNuit())
                {
                    Console.WriteLine(s);
                    sw.WriteLine(s);
                }

                Console.WriteLine("\nSouhaitez-vous modifier l'aquarium? 1 - Oui ou 2 - Non, passer la nuit");
                int selection;
                while (!int.TryParse(Console.ReadLine(), out selection))
                {
                    Console.WriteLine("Veuillez entrer un chiffre valide!");
                }
                if (selection == 1)
                {
                    sw.WriteLine(cshark.Editer());
                }
                sw.Close();
            }
        }
    }
}
