using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EduticXamarin.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            iniciarSlabel.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            userEntry.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry));
            passEntry.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry));

            BtnLogin.Clicked += BtnLogin_Clicked;
        }

        private async void BtnLogin_Clicked(Object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userEntry.Text))
            {
                await DisplayAlert("Error!", "Debe de ingresar un usuario.", "Aceptar");
                userEntry.Focus();
                return;
            }
            else
            {
                await Navigation.PushModalAsync(new MasterDetail(userEntry.Text));
            }
        }
    }
}
