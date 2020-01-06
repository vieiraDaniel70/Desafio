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

    }
}