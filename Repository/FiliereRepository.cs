using System.Text.Json;
using System.IO;
using examenC_.Models;
using System;

namespace examenC_.Repository
{

    public class FiliereRepository
    {
        public List<Filiere>? GetFilieres() {

            List<Filiere>? filieres = new List<Filiere>();

            var jsonData = File.ReadAllText("Filiere.json");

            filieres = JsonSerializer.Deserialize<List<Filiere>>(jsonData);

            return filieres; 
        }

        public void Ajouter(Filiere filiere)
        {
            List<Filiere>? filieres = new List<Filiere>();

            var jsonData = File.ReadAllText("Filiere.json");

            filieres = JsonSerializer.Deserialize<List<Filiere>>(jsonData);

            filiere.IdFiliere = filieres.Any() ? filieres.Max(x => x.IdFiliere) + 1 : 1;

            filieres.Add(filiere);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // Pour une meilleure lisibilité
            };

            jsonData = JsonSerializer.Serialize(filieres, options);
            File.WriteAllText("Filiere.json", jsonData);

        }

        public void Modifier(Filiere filiere)
        {
            List<Filiere>? filieres = new List<Filiere>();

            var jsonData = File.ReadAllText("Filiere.json");

            filieres = JsonSerializer.Deserialize<List<Filiere>>(jsonData);

            Filiere f = filieres.Find(f => f.IdFiliere == filiere.IdFiliere);

            if(f != null)
            {
                f.Nom = filiere.Nom;
                f.Description = filiere.Description;
            }

            jsonData = JsonSerializer.Serialize(filieres, new JsonSerializerOptions 
            { 
                WriteIndented = true 
            });
            File.WriteAllText("Filiere.json", jsonData);

        }

        public void Supprimer(int Id)
        {
            List<Filiere>? filieres = new List<Filiere>();

            var jsonData = File.ReadAllText("Filiere.json");

            filieres = JsonSerializer.Deserialize<List<Filiere>>(jsonData);

            Filiere f = filieres.Find(f => f.IdFiliere == Id);

            if (f != null)
            {
                filieres.Remove(f);
            }

            jsonData = JsonSerializer.Serialize(filieres, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("Filiere.json", jsonData);
        }
    }
}
