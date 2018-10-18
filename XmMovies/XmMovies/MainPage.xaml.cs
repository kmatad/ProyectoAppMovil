using System;
using System.Collections.Generic;

using System.Collections.ObjectModel;

using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace XmMovies
{
	public partial class MainPage : ContentPage
	{
        public string busqueda;
        public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object>();
        List<Result> peliculas { get; set; } = new List<Result>();
        List<ResultTv> tvs { get; set; } = new List<ResultTv>();
        List<ResultPeop> personas { get; set; } = new List<ResultPeop>();
        string bandera = "";
        public Command ObtenerComando { get; set; }
        public MainPage()
		{
            ObtenerComando = new Command(async () => await CargarItems());
            InitializeComponent();
           
		}

        private async Task<RootObject> CargarPeliculas()
        {
            try
            {
                var apiExt = "search/movie";

                var cliente = new HttpClient();
               
                cliente.BaseAddress = new Uri(App.WebServiceUrl);
                var json = await cliente.GetStringAsync(apiExt+"?api_key=" +App.ApiKey+"&language=en-US&query="+ tbBusqueda.Text + "&page=1&include_adult=false");

                Console.WriteLine(json);


                var resultado  = JsonConvert.DeserializeObject<RootObject>(json);
                   

                return resultado;

            }
            catch (Exception ex)
            {
                // Log 
                return new RootObject();
            }
        }

        private async Task<RootObjectTv> CargarTv()
        {
            try
            {
                var apiExt = "search/tv";

                var cliente = new HttpClient();

                cliente.BaseAddress = new Uri(App.WebServiceUrl);
                var json = await cliente.GetStringAsync(apiExt + "?api_key=" + App.ApiKey + "&language=en-US&query=" + tbBusqueda.Text + "&page=1&include_adult=false");

                Console.WriteLine(json);


                var resultado = JsonConvert.DeserializeObject<RootObjectTv>(json);


                return resultado;

            }
            catch (Exception ex)
            {
                // Log 
                return new RootObjectTv();
            }
        }

        private async Task<RootObjectPeop> CargarPersonas()
        {
            try
            {
                var apiExt = "search/person";
              
                var cliente = new HttpClient();

                cliente.BaseAddress = new Uri(App.WebServiceUrl);
                var json = await cliente.GetStringAsync(apiExt + "?api_key=" + App.ApiKey + "&language=en-US&query=" + tbBusqueda.Text + "&page=1&include_adult=false");

                Console.WriteLine(json);


                var resultado = JsonConvert.DeserializeObject<RootObjectPeop>(json);


                return resultado;

            }
            catch (Exception ex)
            {
                // Log 
                return new RootObjectPeop();
            }
        }

        private async Task CargarItems()
        {
            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Advertencia", "No hay internet", "Cerrar");
                return;
            }
            IsBusy = true;

            //await Task.Delay(2500);

            //Items.Add($"Elemento #{Items.Count}");

            Items.Clear();

            if (this.Title == "Películas") {
                var productos = await CargarPeliculas();

                foreach (var item in productos.results)
                {
                    Items.Add(item);
                    peliculas.Add(item);
                }
            }
            if (this.Title == "Show de TV") {
                var productos = await CargarTv();

                foreach (var item in productos.results)
                {
                    Items.Add(item);
                    tvs.Add(item);
                }
            }
            if (this.Title == "Personal") {
                var productos = await CargarPersonas();

                foreach (var item in productos.results)
                {
                    Items.Add(item);
                    personas.Add(item);
                }
            }

            bandera = this.Title;

            IsBusy = false;

            //await DisplayAlert("Titulo", "Hola!", "Cerrar");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (tbBusqueda.Text != "") {
                await CargarItems();
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var index = (lvItems.ItemsSource as ObservableCollection<object>).IndexOf(e.SelectedItem as object);

            Result itemPeliculas = new Result();
            ResultTv itemTV = new ResultTv();
            ResultPeop itemPersonas = new ResultPeop();

            if (bandera == "Películas") {  itemPeliculas = peliculas.ElementAt(index); }
            if (bandera == "Show de TV") {  itemTV = tvs.ElementAt(index); }
            if (bandera == "Personal") {  itemPersonas = personas.ElementAt(index); }

            Navigation.PushAsync(new DetailContent(itemPeliculas,itemTV, itemPersonas, bandera));
        }
    }
}
