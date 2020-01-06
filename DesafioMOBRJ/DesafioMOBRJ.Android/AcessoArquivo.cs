using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DesafioMOBRJ.Droid
{
    public class AcessoArquivo
    {
    
        public static string GetLocalCaminhoArquivo(string nome)
        {
            string caminho = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(caminho, nome);
        }
    }
}