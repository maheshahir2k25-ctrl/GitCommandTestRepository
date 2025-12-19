using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVM.Utilities
{
    public static class FocusExtension
    {
        // 1. Define the Attached Property "IsFocused"
        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.RegisterAttached(
                "IsFocused",
                typeof(bool),
                typeof(FocusExtension),
                new UIPropertyMetadata(false, OnIsFocusedChanged));

        // Standard Get/Set accessors for XAML
        public static bool GetIsFocused(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsFocusedProperty);
        }

        public static void SetIsFocused(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFocusedProperty, value);
        }

        // 2. The Logic: What happens when the bool changes?
        private static void OnIsFocusedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as Control;
            if (control != null && (bool)e.NewValue)
            {
                // FORCE FOCUS
                control.Focus();
            }
        }
    }
}
