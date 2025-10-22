using System.Text.Json;
using System.IO;
using Domain.Entities;

namespace Application
{
    public class ShelterManager
    {
        private const string CatsFile = "cats.json";
        private const string AdoptionsFile = "adoptions.json";

        public List<Cat> presentCats { get; private set; } = new();
        public List<Cat> adoptedCats { get; private set; } = new();
        public List<Adoption> adoptions { get; private set; } = new();

        public ShelterManager()
        {
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(CatsFile))
            {
                var cats = JsonSerializer.Deserialize<List<Cat>>(File.ReadAllText(CatsFile));
                presentCats = cats?.Where(c => c.ExitDate == null).ToList() ?? new();
                adoptedCats = cats?.Where(c => c.ExitDate != null).ToList() ?? new();
            }
            if (File.Exists(AdoptionsFile))
            {
                adoptions = JsonSerializer.Deserialize<List<Adoption>>(File.ReadAllText(AdoptionsFile)) ?? new();
            }
        }

        private void SaveCats()
        {
            var allCats = presentCats.Concat(adoptedCats).ToList();
            File.WriteAllText(CatsFile, JsonSerializer.Serialize(allCats));
        }

        private void SaveAdoptions()
        {
            File.WriteAllText(AdoptionsFile, JsonSerializer.Serialize(adoptions));
        }

        public void AddCat(Cat cat)
        {
            presentCats.Add(cat);
            SaveCats();
        }

        public void RegisterAdoption(Adoption adoption)
        {
            adoptions.Add(adoption);
            var cat = presentCats.FirstOrDefault(c => c.CodeId == adoption.Cat.CodeId);
            if (cat != null)
            {
                cat.ExitDate = adoption.AdoptionDate;
                presentCats.Remove(cat);
                adoptedCats.Add(cat);
                SaveCats();
            }
            SaveAdoptions();
        }

        public void HandleFailedAdoption(Cat cat, DateTime start, DateTime end)
        {
            cat.ExitDate = null;
            cat.Description += $" Failed adoption: start {start:dd/MM/yyyy} end {end:dd/MM/yyyy}.";
            if (!presentCats.Contains(cat))
            {
                adoptedCats.Remove(cat);
                presentCats.Add(cat);
            }
            SaveCats();
        }

        public List<Adopter> adopters { get; private set; } = new();

        public void AddAdopter(Adopter adopter)
        {
            adopters.Add(adopter);
        }
    }
}
