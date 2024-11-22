using System;

namespace UsageCollections
{
    public class Étudiant
    {
        public string Nom { get; set; }
        public double NoteCC { get; set; } // Note de Contrôle Continu
        public double NoteDevoir { get; set; } // Note de Devoir

        // Calcul de la moyenne pondérée
        public double Moyenne => (NoteCC * 0.33) + (NoteDevoir * 0.67);

        // Méthode d'affichage d'un étudiant
        public override string ToString()
        {
            return $"Nom : {Nom}, Note CC : {NoteCC}, Note Devoir : {NoteDevoir}, Moyenne : {Moyenne:F2}";
        }
    }
}
