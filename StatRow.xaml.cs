<!--
  ╔══════════════════════════════════════════════════════════╗
  ║  Elstract Launcher — Views/StatRow.xaml                 ║
  ║  Reusable label + value row for game detail stats panel ║
  ╚══════════════════════════════════════════════════════════╝
-->
<UserControl x:Class="ElstractLauncher.Views.StatRow"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
  <Grid>
    <Grid.ColumnDefinitions>
      <ColumnDefinition Width="*"/>
      <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>
    <TextBlock Grid.Column="0"
               x:Name="LabelText"
               Foreground="{StaticResource TextMutedBrush}"
               FontSize="11"/>
    <TextBlock Grid.Column="1"
               x:Name="ValueText"
               Foreground="{StaticResource TextSecondaryBrush}"
               FontSize="12" FontWeight="SemiBold"
               HorizontalAlignment="Right"
               TextTrimming="CharacterEllipsis"/>
  </Grid>
</UserControl>
