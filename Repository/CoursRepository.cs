using System.Text.Json;
using System.IO;
using examenC_.Models;
using System;

namespace examenC_.Repository
{

    public class CoursRepository
    {
        public List<Cours>? GetCourss() {

            List<Cours>? cours = new List<Cours>();

            var jsonData = File.ReadAllText("Cours.json");

            cours = JsonSerializer.Deserialize<List<Cours>>(jsonData);

            return cours; 
        }

        public void Ajouter(Cours cours)
        {
            List<Cours>? courss = new List<Cours>();

            var jsonData = File.ReadAllText("Cours.json");

            courss = JsonSerializer.Deserialize<List<Cours>>(jsonData);

            cours.IdCours = courss.Any() ? courss.Max(x => x.IdCours) + 1 : 1;

            courss.Add(cours);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // Pour une meilleure lisibilité
            };

            jsonData = JsonSerializer.Serialize(courss, options);
            File.WriteAllText("Cours.json", jsonData);

        }

        public void Modifier(Cours cours)
        {
            List<Cours>? courss = new List<Cours>();

            var jsonData = File.ReadAllText("Cours.json");

            courss = JsonSerializer.Deserialize<List<Cours>>(jsonData);

            Cours f = courss.Find(f => f.IdCours == cours.IdCours);

            if(f != null)
            {
                f.Nom = cours.Nom;
                f.Prof = cours.Prof;
                f.Filiere = cours.Filiere;
                f.Description = cours.Description;
            }

            jsonData = JsonSerializer.Serialize(courss, new JsonSerializerOptions 
            { 
                WriteIndented = true 
            });
            File.WriteAllText("Cours.json", jsonData);

        }

        public void Supprimer(int Id)
        {
            List<Cours>? Courss = new List<Cours>();

            var jsonData = File.ReadAllText("Cours.json");

            Courss = JsonSerializer.Deserialize<List<Cours>>(jsonData);

            Cours f = Courss.Find(f => f.IdCours == Id);

            if (f != null)
            {
                Courss.Remove(f);
            }

            jsonData = JsonSerializer.Serialize(Courss, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("Cours.json", jsonData);
        }
    }
}
