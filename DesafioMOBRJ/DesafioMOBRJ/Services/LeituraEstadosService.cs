using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DesafioMOBRJ.Models;

namespace DesafioMOBRJ.Services
{
    public class LeituraEstadosService
    {
        private HttpClient _client = new HttpClient();
        private List<Estado> _users;
        
        public async Task<List<Estado>> GetUsuarioPorNomeAsync(int _userId)
        {

            //string url = string.Format("https://api.airtable.com/v0/app0RCW0xYP8RT3U9/Estados?api_key=keyhS9s7U3bGKSuml");
            string url = string.Format("http://jsonplaceholder.typicode.com/users/" + _userId);
            if (_userId <= 0)
            {
                return null;
            }
            else
            {
                var response = await _client.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    _users = new List<Estado>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var usuarios = JsonConvert.DeserializeObject<List<Estado>>(content);
                    _users = new List<Estado>(usuarios);
                }
                return _users;
            }
        }

        public async Task<List<Estado>> GetUsuariosAsync()
        {
            try
            {
                //string url = string.Format("https://api.airtable.com/v0/app0RCW0xYP8RT3U9/Estados?api_key=keyhS9s7U3bGKSuml");
                string url = string.Format("http://jsonplaceholder.typicode.com/users/");
                var response = await _client.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    _users = new List<Estado>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var usuarios = JsonConvert.DeserializeObject<List<Estado>>(content);
                    _users = JsonConvert.DeserializeObject<List<Estado>>(content);
                    _users = new List<Estado>(usuarios);

                }
                return _users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}