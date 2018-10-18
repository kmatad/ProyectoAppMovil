using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XmMovies
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailContent : ContentPage
	{
        public Result objPeliculas;
        public ResultTv objTV;
        public ResultPeop objPersonas;
        public string bandera;
        List<KnownForPeop> li = new List<KnownForPeop>();
        public DetailContent(Result _obj, ResultTv _objTV, ResultPeop _objPersonas, string _bandera)
		{
			InitializeComponent ();

            objPeliculas = _obj;
            objTV = _objTV;
            objPersonas = _objPersonas;
            bandera =_bandera;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await CargarDatos();
        }

        private async Task CargarDatos()
        {
            if (bandera == "Películas")
            {
                imgImagen.Source = App.WebServiceImagePath + objPeliculas.poster_path;
                lblTitulo.Text = objPeliculas.nombreLista;
                lblInfo.Text = objPeliculas.overview;
                lblPop.Text = objPeliculas.popularity.ToString();
                lblVote.Text = objPeliculas.vote_average.ToString();
            }
            if (bandera == "Show de TV")
            {
                imgImagen.Source = App.WebServiceImagePath + objTV.poster_path;
                lblTitulo.Text = objTV.nombreLista;
                lblInfo.Text = objTV.overview;
                lblPop.Text = objTV.popularity.ToString();
                lblVote.Text = objTV.vote_average.ToString();
            }
            if (bandera == "Personal")
            {
                imgImagen.Source = App.WebServiceImagePath + objPersonas.profile_path;
                lblTitulo.Text = objPersonas.nombreLista;
                lblInfo.Text = "";
                lblPop.Text = objPersonas.popularity.ToString();
                lblVote.IsVisible = false;
                lblx2.IsVisible = false;
                lblx0.IsVisible = false;

                li = objPersonas.known_for;

                btnKnownFor.IsVisible = true;
            }
        }

        private void btnKnownFor_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new KnownForPage(li));
        }
    }
}