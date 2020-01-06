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
            conexao.CreateTable<Fields>();
        }
    
        public void SalvarDados(ClasseEstado estado)
        {
            try
            {
                int estados = conexao.Insert(estado);
                int campos = conexao.Insert(estado.fields);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message); 
            }
        }
    
        public void DeletarDados()
        {
            conexao.DeleteAll<ClasseEstado>();
            conexao.DeleteAll<Fields>();
        }
    }
}
