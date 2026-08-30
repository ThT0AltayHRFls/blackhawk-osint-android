using Xamarin.Forms;

namespace BlackHawk.Behaviors
{
    public class SearchEntryBehavior : Behavior<SearchBar>
    {
        protected override void OnAttachedTo(SearchBar searchBar)
        {
            searchBar.SearchButtonPressed += OnSearchButtonPressed;
            base.OnAttachedTo(searchBar);
        }

        protected override void OnDetachingFrom(SearchBar searchBar)
        {
            searchBar.SearchButtonPressed -= OnSearchButtonPressed;
            base.OnDetachingFrom(searchBar);
        }

        private void OnSearchButtonPressed(object sender, System.EventArgs e)
        {
            var searchBar = sender as SearchBar;
            if (!string.IsNullOrWhiteSpace(searchBar.Text))
            {
                searchBar.Text = searchBar.Text.Trim();
            }
        }
    }
}
