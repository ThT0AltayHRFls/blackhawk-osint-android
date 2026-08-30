using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using BlackHawk.Models.Entities;
using BlackHawk.Services.Database;
using BlackHawk.Services.API;

namespace BlackHawk.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private string _searchQuery;
        private ObservableCollection<SearchResult> _searchResults;
        private readonly DatabaseService _databaseService;
        private readonly NewsApiService _newsApiService;
        private readonly RedditApiService _redditApiService;

        public string SearchQuery
        {
            get => _searchQuery;
            set => SetProperty(ref _searchQuery, value);
        }

        public ObservableCollection<SearchResult> SearchResults
        {
            get => _searchResults;
            set => SetProperty(ref _searchResults, value);
        }

        public Command SearchCommand { get; }

        public SearchViewModel()
        {
            _databaseService = new DatabaseService();
            _newsApiService = new NewsApiService();
            _redditApiService = new RedditApiService();
            _searchResults = new ObservableCollection<SearchResult>();

            SearchCommand = new Command(async () => await ExecuteSearchCommand());

            Title = "BlackHawk OSINT";
        }

        private async Task ExecuteSearchCommand()
        {
            if (IsBusy || string.IsNullOrWhiteSpace(SearchQuery))
                return;

            IsBusy = true;

            try
            {
                SearchResults.Clear();

                var newsResults = await _newsApiService.SearchAsync(SearchQuery);
                var redditResults = await _redditApiService.SearchAsync(SearchQuery);

                var allResults = newsResults.Concat(redditResults).ToList();

                foreach (var result in allResults)
                {
                    SearchResults.Add(result);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Search error: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
