using Xamarin.Forms;
using BlackHawk.Helpers;

namespace BlackHawk.Behaviors
{
    public class EmailValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = sender as Entry;
            var isValid = ValidationHelper.IsValidEmail(args.NewTextValue);
            entry.TextColor = isValid ? Color.Green : Color.Red;
        }
    }
}
