using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Challenge.Behaviors
{
    public class EntryTextBehavior : Behavior<Entry>
    {
        const string textRegex = @"^[a-zA-Z]+$";

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        void OnEntryTextChanged(object s, TextChangedEventArgs e)
        {
            var entry = s as Entry;
            if (!string.IsNullOrWhiteSpace(entry.Text))
                entry.TextColor = Regex.IsMatch(e.NewTextValue, textRegex, RegexOptions.IgnoreCase) 
                    ? Color.Default 
                    : Color.Red;
            else
                entry.TextColor = Color.Red;
        }


        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }
    }
}
