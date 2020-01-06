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
    public partial class EstadoPage : ContentPage
    {

        LeituraAPIService userService = new LeituraAPIService();

        public EstadoPage()
        {
            InitializeComponent();
            PreencherListview();
        }

        public async void PreencherListview()
        {
            Estado usuarios = await userService.GetUsuariosAsync();
            if (usuarios == null)
            {
                lvwEstados.IsVisible = false;
                lblmsg.IsVisible = true;
                lblmsg.Text = "Não foi possível retornar a lista de usuários";
                lblmsg.TextColor = Color.Red;

            }
            else
            {
                lvwEstados.IsVisible = true;
                lblmsg.IsVisible = false;
                lvwEstados.ItemsSource = usuarios.records;
            }
        }

        private async void EstadoSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<ClasseEstado> usuarios = await userService.GetUsuariosRegiaoAsync();
            var texto = EstadoSearchBar.Text;
            var r = usuarios.Where(x => x.fields.Estado.ToLower().Contains(texto.ToLower()) || x.fields.Capital.ToLower().Contains(texto.ToLower()));
            lvwEstados.ItemsSource = r;
        }
    }
}