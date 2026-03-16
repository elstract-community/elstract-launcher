/*
 * ╔══════════════════════════════════════════════════════════╗
 * ║  Elstract Launcher — Views/StatRow.xaml.cs              ║
 * ║  Dependency properties: Label, Value                    ║
 * ╚══════════════════════════════════════════════════════════╝
 */

using System.Windows;
using System.Windows.Controls;

namespace ElstractLauncher.Views;

public partial class StatRow : UserControl
{
    public static readonly DependencyProperty LabelProperty =
        DependencyProperty.Register(nameof(Label), typeof(string), typeof(StatRow),
            new PropertyMetadata(string.Empty, (d, e) =>
                ((StatRow)d).LabelText.Text = (string)e.NewValue));

    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(object), typeof(StatRow),
            new PropertyMetadata(null, (d, e) =>
                ((StatRow)d).ValueText.Text = e.NewValue?.ToString() ?? "—"));

    public string Label { get => (string)GetValue(LabelProperty);  set => SetValue(LabelProperty, value); }
    public object Value { get => GetValue(ValueProperty);          set => SetValue(ValueProperty, value); }

    public StatRow() => InitializeComponent();
}
