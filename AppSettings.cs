/*
 * ╔══════════════════════════════════════════════════════════╗
 * ║  Elstract Launcher — Converters/Converters.cs           ║
 * ║  All IValueConverter implementations used in XAML:      ║
 * ║  • BoolToVisibilityConverter                            ║
 * ║  • InvertBoolToVisibilityConverter                      ║
 * ║  • NotNullToVisibilityConverter                         ║
 * ║  • NullToVisibilityConverter                            ║
 * ║  • NullToWidthConverter                                 ║
 * ║  • BoolToPlayTextConverter                              ║
 * ╚══════════════════════════════════════════════════════════╝
 */

using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ElstractLauncher.Converters;

/// <summary>true → Visible, false → Collapsed</summary>
[ValueConversion(typeof(bool), typeof(Visibility))]
public class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type t, object p, CultureInfo c)
        => value is true ? Visibility.Visible : Visibility.Collapsed;

    public object ConvertBack(object value, Type t, object p, CultureInfo c)
        => (Visibility)value == Visibility.Visible;
}

/// <summary>false → Visible, true → Collapsed</summary>
[ValueConversion(typeof(bool), typeof(Visibility))]
public class InvertBoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type t, object p, CultureInfo c)
        => value is true ? Visibility.Collapsed : Visibility.Visible;

    public object ConvertBack(object value, Type t, object p, CultureInfo c)
        => (Visibility)value != Visibility.Visible;
}

/// <summary>non-null → Visible, null → Collapsed</summary>
public class NotNullToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type t, object p, CultureInfo c)
        => value is not null && value.ToString() != string.Empty
            ? Visibility.Visible : Visibility.Collapsed;

    public object ConvertBack(object v, Type t, object p, CultureInfo c)
        => throw new NotImplementedException();
}

/// <summary>null or empty → Visible (shows placeholder), non-null → Collapsed</summary>
public class NullToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type t, object p, CultureInfo c)
        => value is null || value.ToString() == string.Empty
            ? Visibility.Visible : Visibility.Collapsed;

    public object ConvertBack(object v, Type t, object p, CultureInfo c)
        => throw new NotImplementedException();
}

/// <summary>
/// Used for the game detail panel width.
/// null → 0, non-null → ConverterParameter (e.g. "320")
/// </summary>
public class NullToWidthConverter : IValueConverter
{
    public object Convert(object value, Type t, object param, CultureInfo c)
    {
        if (value is null) return new GridLength(0);
        if (param is string s && double.TryParse(s, out var width))
            return new GridLength(width);
        return new GridLength(300);
    }

    public object ConvertBack(object v, Type t, object p, CultureInfo c)
        => throw new NotImplementedException();
}

/// <summary>true (exe linked) → "Play", false → "Link EXE"</summary>
[ValueConversion(typeof(bool), typeof(string))]
public class BoolToPlayTextConverter : IValueConverter
{
    public object Convert(object value, Type t, object p, CultureInfo c)
        => value is true ? "Play" : "Link EXE";

    public object ConvertBack(object v, Type t, object p, CultureInfo c)
        => throw new NotImplementedException();
}
