using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EduticXamarin.Pages
{
    public partial class Menu : ContentPage
    {
        public string username_;
        public Menu(String username)
        {
            InitializeComponent();
            userMenuLabel.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            userMenuLabel.Text = string.Format("Bienvenido {0}", username);
            buscarMenu.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            username_ = string.Format(username);

            buscarMenu.Clicked += btnInicioMenu;
        }

        public async void btnInicioMenu(Object sender, EventArgs e)
        {
            buscarMenu.TextColor = Color.Green;
            
            await Navigation.PushModalAsync(new Pages.Buscar(username_));
        }
    }
}
