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
	public partial class KnownForPage : ContentPage
	{
        public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object>();
        List<KnownForPeop> cls = new List<KnownForPeop>();
        public KnownForPage (List<KnownForPeop> _cls)
		{
			InitializeComponent ();

            cls = _cls;


            foreach (var item in cls)
            {
                item.poster_path = App.WebServiceImagePath + item.poster_path;
            }
            foreach (var item in cls)
            {
                Items.Add(item);
            }
        }


	}
}