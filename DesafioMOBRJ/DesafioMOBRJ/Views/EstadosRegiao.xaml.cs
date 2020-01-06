﻿using DesafioMOBRJ.Models;
using DesafioMOBRJ.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static DesafioMOBRJ.Models.Estado;

namespace DesafioMOBRJ.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EstadosRegiao : ContentPage
    {
        LeituraAPIService userService = new LeituraAPIService();

        public EstadosRegiao()
        {
            InitializeComponent();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            List<ClasseEstado> usuarios = await userService.GetUsuariosRegiaoAsync();
            if (usuarios == null)
            {
                lvwEstadosRegiao.IsVisible = false;
                lblmsgRegiao.IsVisible = true;
                lblmsgRegiao.Text = "Não foi possível retornar a lista de usuários";
                lblmsgRegiao.TextColor = Color.Red;

            }
            else
            {
                lvwEstadosRegiao.IsVisible = true;
                lblmsgRegiao.IsVisible = false;
                var r = usuarios.OrderBy(x => x.fields.Regiao);
                lvwEstadosRegiao.ItemsSource = r;
            }
        }
    }
}