using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BlackHawk.ViewModels;

namespace BlackHawk.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = new SearchViewModel();
        }
    }
}
