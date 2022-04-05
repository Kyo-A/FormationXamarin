using FormationXamForms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FormationXamForms.Helpers
{
    class ApiHelper
    {
        const string BASE_URL = "https://server-rest-api.herokuapp.com/";
        const string ENDPOINT = "personnes";

        public static async Task<List<PersonModel>> GetPersonsAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + ENDPOINT);
                var persons = JsonConvert.DeserializeObject<List<PersonModel>>(jsonString);
                return persons;
            }
        }

        public static async Task<PersonModel> AddPersonAsync(PersonModel person)
        {
            using (var httpClient = new HttpClient())
            {
                string content = JsonConvert.SerializeObject(person);
                await httpClient.PostAsync(BASE_URL + ENDPOINT, new StringContent(content, Encoding.UTF8, "application/json"));
                return person;
            }
        }

        public static async Task<PersonModel> GetPersonByIdAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL + ENDPOINT + "/" + id);
                var p = JsonConvert.DeserializeObject<PersonModel>(jsonString);
                return p;
            }
        }

        public static async Task<PersonModel> UpdatePersonAsync(PersonModel person)
        {
            using (var httpClient = new HttpClient())
            {
                string content = JsonConvert.SerializeObject(person);
                await httpClient.PutAsync(BASE_URL + ENDPOINT + "/" + person.Id, new StringContent(content, Encoding.UTF8, "application/json"));
                return person;

            }
        }

        public static async Task DeletePersonAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                await httpClient.DeleteAsync(BASE_URL + ENDPOINT + "/" + id);
            }
        }
    }
}
