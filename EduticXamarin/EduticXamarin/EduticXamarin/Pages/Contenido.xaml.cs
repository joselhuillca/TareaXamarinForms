using Newtonsoft.Json;
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
    public partial class Contenido : ContentPage
    {
        public Contenido()
        {
            InitializeComponent();

            noticiaListView.ItemTemplate = new DataTemplate(typeof(Cells.NoticiaCell));
            this.LoadNoticias();
        }

        public async void LoadNoticias()
        {
            cargandoLabelC.Text = string.Format("Cargando...");
            string result;
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.BaseAddress = new Uri("http://www.faroo.com");
                string url = string.Format("/api?q=&start=1&length=10&l=en&src=news&f=json&key=VuCvt6PDV4LoDOIvsbwSEkkEf-Q_");
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

            noticiaListView.ItemsSource = noticias_;
            cargandoLabelC.Text = string.Empty;
        }
    }
}
