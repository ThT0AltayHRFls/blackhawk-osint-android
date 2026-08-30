using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using BlackHawk.Models.Entities;
using BlackHawk.Services.Database;

namespace BlackHawk.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        private ObservableCollection<SearchHistory> _searchHistory;
        private readonly DatabaseService _databaseService;

        public ObservableCollection<SearchHistory> SearchHistory
        {
            get => _searchHistory;
            set => SetProperty(ref _searchHistory, value);
        }

        public Command ClearHistoryCommand { get; }
        public Command LoadHistoryCommand { get; }

        public HistoryViewModel()
        {
            _databaseService = new DatabaseService();
            _searchHistory = new ObservableCollection<SearchHistory>();

            ClearHistoryCommand = new Command(async () => await ExecuteClearHistory());
            LoadHistoryCommand = new Command(async () => await ExecuteLoadHistory());

            Title = "Arama Geçmişi";
        }

        private async Task ExecuteLoadHistory()
        {
            IsBusy = true;

            try
            {
                var history = await _databaseService.GetSearchHistoryAsync();
                SearchHistory.Clear();

                foreach (var item in history)
                {
                    SearchHistory.Add(item);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Load history error: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExecuteClearHistory()
        {
            if (await Application.Current.MainPage.DisplayAlert("Onayla", "Tüm geçmişi silmek istediğinize emin misiniz?", "Evet", "Hayır"))
            {
                await _databaseService.ClearSearchHistoryAsync();
                SearchHistory.Clear();
            }
        }
    }
}
