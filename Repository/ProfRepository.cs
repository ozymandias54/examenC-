using examenC_.Models;
using System.Text.Json;

namespace examenC_.Repository
{
    public class ProfRepository
    {
        public List<Prof>? GetProfs()
        {

            List<Prof>? profs = new List<Prof>();

            var jsonData = File.ReadAllText("Prof.json");

            profs = JsonSerializer.Deserialize<List<Prof>>(jsonData);

            return profs;
        }

        public void Ajouter(Prof prof)
        {
            List<Prof>? profs = new List<Prof>();

            var jsonData = File.ReadAllText("Prof.json");

            profs = JsonSerializer.Deserialize<List<Prof>>(jsonData);

            prof.IdProf = profs.Any() ? profs.Max(x => x.IdProf) + 1 : 1;

            profs.Add(prof);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // Pour une meilleure lisibilité
            };

            jsonData = JsonSerializer.Serialize(profs, options);
            File.WriteAllText("Prof.json", jsonData);

        }

        public void Modifier(Prof prof)
        {
            List<Prof>? profs = new List<Prof>();

            var jsonData = File.ReadAllText("Prof.json");

            profs = JsonSerializer.Deserialize<List<Prof>>(jsonData);

            Prof f = profs.Find(f => f.IdProf == prof.IdProf);

            if (f != null)
            {
                f.Nom = prof.Nom;
                f.Prenom = prof.Prenom;
                f.Email = prof.Email;
            }

            jsonData = JsonSerializer.Serialize(profs, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("Prof.json", jsonData);

        }

        public void Supprimer(int Id)
        {
            List<Prof>? profs = new List<Prof>();

            var jsonData = File.ReadAllText("Prof.json");

            profs = JsonSerializer.Deserialize<List<Prof>>(jsonData);

            Prof f = profs.Find(f => f.IdProf == Id);

            if (f != null)
            {
                profs.Remove(f);
            }

            jsonData = JsonSerializer.Serialize(profs, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("Prof.json", jsonData);
        }
    }
}
