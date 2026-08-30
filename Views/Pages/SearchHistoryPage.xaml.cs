using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BlackHawk.ViewModels;

namespace BlackHawk.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchHistoryPage : ContentPage
    {
        public SearchHistoryPage()
        {
            InitializeComponent();
            BindingContext = new HistoryViewModel();
        }
    }
}
