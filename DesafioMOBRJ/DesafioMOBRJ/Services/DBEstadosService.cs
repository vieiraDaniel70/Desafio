using DesafioMOBRJ.Models;
using SQLite;
using System;
using System.Collections.Generic;
using static DesafioMOBRJ.Models.Estado;

namespace DesafioMOBRJ.Services
{
    public class DBEstadosService
    {
        SQLiteConnection conexao;
      
        public string MensagemStatus { get; set; }

        public DBEstadosService(string caminho)
        {
            conexao = new SQLiteConnection(caminho);
            conexao.CreateTable<ClasseEstado>();
            
        }
    
        public void SalvarDados(ClasseEstado estado)
        {
            try
            {
                int resultado = conexao.Insert(estado);
                this.MensagemStatus = string.Format("{0} registro incluídos", resultado);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message); 
            }
        }
    }
}
