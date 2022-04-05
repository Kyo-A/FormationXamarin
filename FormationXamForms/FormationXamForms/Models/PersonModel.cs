using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormationXamForms.Models
{
    public class PersonModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nom")]
        public string Nom { get; set; }

        [JsonProperty("prenom")]
        public string Prenom { get; set; }
        public PersonModel()
        {
        }

        public PersonModel(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }
    }
}
