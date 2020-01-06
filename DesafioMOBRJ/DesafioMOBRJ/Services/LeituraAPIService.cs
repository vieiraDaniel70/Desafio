
using DesafioMOBRJ.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static DesafioMOBRJ.Models.Estado;

namespace DesafioMOBRJ.Services
{
    public class LeituraAPIService
    {
        private HttpClient _client = new HttpClient();
        private Estado _users;
        public async Task<Estado> GetUsuarioPorNomeAsync(int _userId)
        {
            string url = string.Format("https://api.airtable.com/v0/app0RCW0xYP8RT3U9/Estados?api_key=keyhS9s7U3bGKSuml" + _userId);
            if (_userId <= 0)
            {
                return null;
            }
            else
            {
                var response = await _client.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    _users = new Estado();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var usuarios = JsonConvert.DeserializeObject<Estado>(content);
                    _users = usuarios;
                    
                }
                return _users;
            }
        }
        public async Task<Estado> GetUsuariosAsync()
        {
            try
            {
                string url = string.Format("https://api.airtable.com/v0/app0RCW0xYP8RT3U9/Estados?api_key=keyhS9s7U3bGKSuml");
                var response = await _client.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    _users = new Estado();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var usuarios = JsonConvert.DeserializeObject<Estado>(content);
                    _users = usuarios;
                }
                return _users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ClasseEstado>> GetUsuariosRegiaoAsync()
        {
            try
            {
                string url = string.Format("https://api.airtable.com/v0/app0RCW0xYP8RT3U9/Estados?api_key=keyhS9s7U3bGKSuml");
                var response = await _client.GetAsync(url);
                List<ClasseEstado> lista;
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    _users = new Estado();
                    lista = new List<ClasseEstado>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var usuarios = JsonConvert.DeserializeObject<Estado>(content);
                    _users = usuarios;
                    lista = usuarios.records;
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}