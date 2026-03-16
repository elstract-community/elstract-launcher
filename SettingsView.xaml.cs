/*
 * ╔══════════════════════════════════════════════════════════╗
 * ║  Elstract Launcher — Views/SettingsToggleRow.xaml.cs    ║
 * ║  DPs: Label, Desc, IsOn (two-way bindable)              ║
 * ╚══════════════════════════════════════════════════════════╝
 */

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ElstractLauncher.ViewModels;

namespace ElstractLauncher.Views;

public partial class SettingsToggleRow : UserControl
{
    // ── Dependency Properties ─────────────────────────────────────────

    public static readonly DependencyProperty LabelProperty =
        DependencyProperty.Register(nameof(Label), typeof(string), typeof(SettingsToggleRow),
            new PropertyMetadata(string.Empty, (d, e) =>
                ((SettingsToggleRow)d).LabelText.Text = (string)e.NewValue));

    public static readonly DependencyProperty DescProperty =
        DependencyProperty.Register(nameof(Desc), typeof(string), typeof(SettingsToggleRow),
            new PropertyMetadata(string.Empty, (d, e) =>
                ((SettingsToggleRow)d).DescText.Text = (string)e.NewValue));

    public static readonly DependencyProperty IsOnProperty =
        DependencyProperty.Register(nameof(IsOn), typeof(bool), typeof(SettingsToggleRow),
            new FrameworkPropertyMetadata(false,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string Label { get => (string)GetValue(LabelProperty);  set => SetValue(LabelProperty, value); }
    public string Desc  { get => (string)GetValue(DescProperty);   set => SetValue(DescProperty, value); }
    public bool   IsOn  { get => (bool)GetValue(IsOnProperty);     set => SetValue(IsOnProperty, value); }

    // ── Toggle command ────────────────────────────────────────────────
    public ICommand ToggleCommand { get; }

    public SettingsToggleRow()
    {
        InitializeComponent();
        ToggleCommand = new RelayCommand(_ => IsOn = !IsOn);
    }
}
