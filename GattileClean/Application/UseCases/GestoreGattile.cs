using System.Text.Json;
using System.IO;
using GattileLib;

namespace Gattile
{
    public class GestoreGattile
    {
        private const string GattiFile = "gatti.json";
        private const string AdozioniFile = "adozioni.json";

        public List<Gatto> gattiPresenti { get; private set; } = new();
        public List<Gatto> gattiAdottati { get; private set; } = new();
        public List<Adozione> adozioni { get; private set; } = new();

        public GestoreGattile()
        {
            CaricaDati();
        }

        private void CaricaDati()
        {
            if (File.Exists(GattiFile))
            {
                var gatti = JsonSerializer.Deserialize<List<Gatto>>(File.ReadAllText(GattiFile));
                gattiPresenti = gatti?.Where(g => g.DataUscita == null).ToList() ?? new();
                gattiAdottati = gatti?.Where(g => g.DataUscita != null).ToList() ?? new();
            }
            if (File.Exists(AdozioniFile))
            {
                adozioni = JsonSerializer.Deserialize<List<Adozione>>(File.ReadAllText(AdozioniFile)) ?? new();
            }
        }

        private void SalvaGatti()
        {
            var tuttiGatti = gattiPresenti.Concat(gattiAdottati).ToList();
            File.WriteAllText(GattiFile, JsonSerializer.Serialize(tuttiGatti));
        }

        private void SalvaAdozioni()
        {
            File.WriteAllText(AdozioniFile, JsonSerializer.Serialize(adozioni));
        }

        public void InserisciGatto(Gatto gatto)
        {
            gattiPresenti.Add(gatto);
            SalvaGatti();
        }

        public void RegistraAdozione(Adozione adozione)
        {
            adozioni.Add(adozione);
            var gatto = gattiPresenti.FirstOrDefault(g => g.CodiceId == adozione.Gatto.CodiceId);
            if (gatto != null)
            {
                gatto.DataUscita = adozione.DataAdozione;
                gattiPresenti.Remove(gatto);
                gattiAdottati.Add(gatto);
                SalvaGatti();
            }
            SalvaAdozioni();
        }

        public void GestisciAdozioneFallita(Gatto gatto, DateTime inizio, DateTime termine)
        {
            gatto.DataUscita = null;
            gatto.Descrizione += $" Adozione fallita: inizio {inizio:dd/MM/yyyy} termine {termine:dd/MM/yyyy}.";
            if (!gattiPresenti.Contains(gatto))
            {
                gattiAdottati.Remove(gatto);
                gattiPresenti.Add(gatto);
            }
            SalvaGatti();
        }
        public List<Adottante> adottanti { get; private set; } = new();

        public void InserisciAdottante(Adottante adottante)
        {
            adottanti.Add(adottante);
            
        }
    }

}
