/*
 * ╔══════════════════════════════════════════════════════════╗
 * ║  Elstract Launcher — Views/SettingsSection.xaml.cs      ║
 * ╚══════════════════════════════════════════════════════════╝
 */

using System.Windows;
using System.Windows.Controls;

namespace ElstractLauncher.Views;

public partial class SettingsSection : UserControl
{
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(nameof(Icon), typeof(string), typeof(SettingsSection),
            new PropertyMetadata(string.Empty, (d, e) =>
                ((SettingsSection)d).IconText.Text = (string)e.NewValue));

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(SettingsSection),
            new PropertyMetadata(string.Empty, (d, e) =>
                ((SettingsSection)d).TitleText.Text = (string)e.NewValue));

    public string Icon  { get => (string)GetValue(IconProperty);  set => SetValue(IconProperty, value); }
    public string Title { get => (string)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }

    public SettingsSection() => InitializeComponent();
}
