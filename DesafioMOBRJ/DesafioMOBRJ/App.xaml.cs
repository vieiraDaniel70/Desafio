using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DesafioMOBRJ.Services;
using DesafioMOBRJ.Views;

namespace DesafioMOBRJ
{
    public partial class App : Application
    {
        public static String DbCaminho;
        public static String DbNome;

        public App()
        {
            //InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            //MainPage = new MainPage();
            //MainPage = new EstadoPage();
            MainPage = new NavegarTelas();
        }

        public App(string caminho, string nome)
        {
            //InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            //MainPage = new MainPage();
            //MainPage = new EstadoPage();
            App.DbNome = nome;
            App.DbCaminho = caminho;
            MainPage = new NavegarTelas();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
