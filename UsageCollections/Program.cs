using System;
using System.Collections;

namespace UsageCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList lstÉtudiants = new SortedList();
            bool continuer = true;

            while (continuer)
            {
                Console.WriteLine("\n=== Menu Principal ===");
                Console.WriteLine("1. Ajouter un étudiant");
                Console.WriteLine("2. Afficher un étudiant");
                Console.WriteLine("3. Afficher tous les étudiants");
                Console.WriteLine("4. Quitter");
                Console.Write("Votre choix : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AjouterÉtudiant(lstÉtudiants);
                        break;
                    case "2":
                        AfficherÉtudiant(lstÉtudiants);
                        break;
                    case "3":
                        AfficherTousLesÉtudiants(lstÉtudiants);
                        break;
                    case "4":
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            }

            Console.WriteLine("Programme terminé.");
        }

        // Méthode pour ajouter un étudiant
        static void AjouterÉtudiant(SortedList lstÉtudiants)
        {
            Console.Write("Entrez le nom de l'étudiant : ");
            string nom = Console.ReadLine();

            if (lstÉtudiants.ContainsKey(nom))
            {
                Console.WriteLine("Cet étudiant existe déjà.");
                return;
            }

            Console.Write("Entrez la note de Contrôle Continu (sur 20) : ");
            double noteCC = LireNote();
            Console.Write("Entrez la note de Devoir (sur 20) : ");
            double noteDevoir = LireNote();

            Étudiant nouvelÉtudiant = new Étudiant
            {
                Nom = nom,
                NoteCC = noteCC,
                NoteDevoir = noteDevoir
            };

            lstÉtudiants.Add(nom, nouvelÉtudiant);
            Console.WriteLine($"Étudiant {nom} ajouté avec succès !");
        }

        // Méthode pour lire une note avec validation
        static double LireNote()
        {
            double note;
            while (!double.TryParse(Console.ReadLine(), out note) || note < 0 || note > 20)
            {
                Console.Write("Veuillez entrer une note valide (entre 0 et 20) : ");
            }
            return note;
        }

        // Méthode pour afficher un étudiant
        static void AfficherÉtudiant(SortedList lstÉtudiants)
        {
            Console.Write("Entrez le nom de l'étudiant à afficher : ");
            string nom = Console.ReadLine();

            if (lstÉtudiants.ContainsKey(nom))
            {
                Étudiant étudiant = (Étudiant)lstÉtudiants[nom];
                Console.WriteLine(étudiant);
            }
            else
            {
                Console.WriteLine("Étudiant introuvable.");
            }
        }

        // Méthode pour afficher tous les étudiants
        static void AfficherTousLesÉtudiants(SortedList lstÉtudiants)
        {
            if (lstÉtudiants.Count == 0)
            {
                Console.WriteLine("Aucun étudiant dans la liste.");
                return;
            }

            Console.WriteLine("\nListe des étudiants :");
            foreach (DictionaryEntry entry in lstÉtudiants)
            {
                Étudiant étudiant = (Étudiant)entry.Value;
                Console.WriteLine(étudiant);
            }
        }
    }
}
