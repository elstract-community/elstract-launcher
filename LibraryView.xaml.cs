<!--
  ╔══════════════════════════════════════════════════════════╗
  ║  Elstract Launcher — Views/SettingsSection.xaml         ║
  ║  Section header with icon + title                       ║
  ╚══════════════════════════════════════════════════════════╝
-->
<UserControl x:Class="ElstractLauncher.Views.SettingsSection"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             Margin="0,0,0,14">
  <StackPanel Orientation="Horizontal" Spacing="10">
    <TextBlock x:Name="IconText"
               FontSize="16" VerticalAlignment="Center"/>
    <TextBlock x:Name="TitleText"
               Foreground="{StaticResource TextPrimaryBrush}"
               FontFamily="{StaticResource FontDisplay}"
               FontSize="16" FontWeight="SemiBold"
               VerticalAlignment="Center"/>
  </StackPanel>
</UserControl>
