using DesafioMOBRJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesafioMOBRJ.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
        public partial class EstadoDetailsPage : ContentPage
        {
            public EstadoDetailsPage(Estado _user)
            {
                InitializeComponent();
                //verifica se o objeto é null 
                //lança a exceção
                if (_user == null)
                    throw new ArgumentNullException(nameof(_user));
                //vincula o filme ao BindingContext 
                //para fazer o databinding na view
                BindingContext = _user;
            }
        }

    }