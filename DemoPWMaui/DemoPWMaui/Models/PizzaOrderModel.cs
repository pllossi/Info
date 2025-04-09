using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DemoPWMaui.Models
{
    public class PizzaOrderModel
    {
        public int Id { get; set; }

        public string Base { get; set; } = string.Empty;

        public List<string> Toppings { get; set; } = [];

        public string Notes { get; set; } = string.Empty;

        public int Quantity { get; set; } = 1;

        [JsonIgnore]
        public bool ToppingsAreSet => Toppings.Count != 0;

        [JsonIgnore]
        public bool NotesAreSet => string.IsNullOrEmpty(Notes) == false;
    }
}
