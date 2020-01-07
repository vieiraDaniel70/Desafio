using DesafioMOBRJ.Models;
using DesafioMOBRJ.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static DesafioMOBRJ.Models.Estado;

namespace DesafioMOBRJ.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SalvarDB : ContentPage
    {
        LeituraAPIService userService = new LeituraAPIService();
        DBEstadosService dados = new DBEstadosService(App.DbCaminho);

        public SalvarDB()
        {
            InitializeComponent();
            PreencherListview();
        }

        public async void PreencherListview()
        {
            Estado usuarios = await userService.GetUsuariosAsync();
            if (usuarios == null)
            {
                lvwEstadosSDB.IsVisible = false;
                lblmsgSDB.IsVisible = true;
                lblmsgSDB.Text = "Não foi possível retornar a lista de usuários";
                lblmsgSDB.TextColor = Color.Red;

            }
            else
            {
                lvwEstadosSDB.IsVisible = false;
                lblmsgSDB.IsVisible = false;
                lvwEstadosSDB.ItemsSource = usuarios.records;
            }
        }

        private async void Button_Clicked2(object sender, EventArgs e)
        {
            List<ClasseEstado> estados = await userService.GetUsuariosRegiaoAsync();
            dados.DeletarDados();
            foreach (ClasseEstado u in estados )
            {
                dados.SalvarDados(u);
            }
            
            await DisplayAlert("", "Dados Salvos", "OK");

        }

        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
                DBEstadosService conexao = new DBEstadosService(App.DbCaminho);
                List<ClasseEstado> l = await userService.GetUsuariosRegiaoAsync();
                List<ClasseEstado> a = conexao.ListarDadosEstadosDB();
                List<ClasseEstado> result = new List<ClasseEstado>();

                foreach (var bItem in l)
                {
                    if (a.Any(aItem => bItem.id == aItem.id))
                        result.Add(bItem);
                }

                lvwEstadosSDB.IsVisible = true;
                lblmsgSDB.IsVisible = false;
                lvwEstadosSDB.ItemsSource = result;
        }
    }
}