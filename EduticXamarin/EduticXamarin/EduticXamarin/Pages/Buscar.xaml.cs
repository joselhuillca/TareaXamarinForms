using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EduticXamarin.Pages
{
    public partial class Buscar : ContentPage
    {
        public string user_;
        public Buscar(String user)
        {
            InitializeComponent();
            resultadoListView.ItemTemplate = new DataTemplate(typeof(Cells.NoticiaCell));
            user_ = string.Format(user);
            btnBuscarNews.Clicked += LoadNoticias;
            btnBackNews.Clicked += btnBack;
        }

        public async void btnBack(Object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Pages.MasterDetail(user_));
        }
        
        public async void LoadNoticias(Object sender,EventArgs e)
        {
            string buscarq = buscarEntry.Text;
            string result;
            cargandoLabel.Text = string.Format("Cargando...");
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.BaseAddress = new Uri("http://www.faroo.com");
                string url = string.Format("/api?q={0}&start=1&length=10&l=en&src=news&f=json&key=VuCvt6PDV4LoDOIvsbwSEkkEf-Q_",buscarq);
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                await DisplayAlert("ERROR!", "No hay conexión, intente mas tarde", "Aceptar");
                return;
            }

            var notocia = Newtonsoft.Json.Linq.JObject.Parse(result);

            ObservableCollection<Models.Noticia> noticias_ = new ObservableCollection<Models.Noticia>();

            foreach (var result_ in notocia["results"])
            {
                noticias_.Add(new Models.Noticia
                {
                    title = result_["title"].ToString(),
                    kwic = result_["kwic"].ToString(),
                    content = result_["content"].ToString(),
                    url = result_["url"].ToString(),
                    iurl = result_["iurl"].ToString(),
                    domain = result_["domain"].ToString(),
                    author = result_["author"].ToString()

                });
            }

            resultadoListView.ItemsSource = noticias_;
            cargandoLabel.Text = string.Empty;
        }
    }
}
