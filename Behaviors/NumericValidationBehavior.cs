using Xamarin.Forms;
using System;

namespace BlackHawk.Behaviors
{
    public class NumericValidationBehavior : Behavior<Entry>
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
            var isValid = int.TryParse(args.NewTextValue, out _);
            entry.TextColor = isValid || string.IsNullOrEmpty(args.NewTextValue) ? Color.Black : Color.Red;
        }
    }
}
