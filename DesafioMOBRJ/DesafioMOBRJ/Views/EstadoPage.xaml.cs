using DesafioMOBRJ.Models;
using DesafioMOBRJ.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesafioMOBRJ.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EstadoPage : ContentPage
    {

        LeituraAPIService userService = new LeituraAPIService();

        public EstadoPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
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
        private async void lvwEstados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            /*
            if (e.SelectedItem == null)
                return;
            var usuario = e.SelectedItem as Estado;
            lvwEstados.SelectedItem = null;
            await Navigation.PushAsync(new EstadoDetailsPage(usuario));
        
        */
        }

        private void lvwEstados_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}