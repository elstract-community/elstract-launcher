<!--
  ╔══════════════════════════════════════════════════════════╗
  ║  Elstract Launcher — Views/FeatureRow.xaml              ║
  ║  Reusable component: icon + title + description row     ║
  ║  used on the Home page feature highlights section.      ║
  ╚══════════════════════════════════════════════════════════╝
-->
<UserControl x:Class="ElstractLauncher.Views.FeatureRow"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             Margin="0,0,0,12">
  <Grid>
    <Grid.ColumnDefinitions>
      <ColumnDefinition Width="38"/>
      <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>

    <!-- Icon circle -->
    <Border Grid.Column="0"
            Width="32" Height="32"
            Background="{StaticResource PinkGradientSubtle}"
            BorderBrush="{StaticResource BorderActiveBrush}"
            BorderThickness="1" CornerRadius="8"
            VerticalAlignment="Top">
      <TextBlock x:Name="IconText"
                 HorizontalAlignment="Center"
                 VerticalAlignment="Center"
                 FontSize="14"/>
    </Border>

    <!-- Text -->
    <StackPanel Grid.Column="1" Margin="10,0,0,0">
      <TextBlock x:Name="TitleText"
                 Foreground="{StaticResource TextPrimaryBrush}"
                 FontFamily="{StaticResource FontDisplay}"
                 FontSize="13" FontWeight="SemiBold"/>
      <TextBlock x:Name="DescText"
                 Foreground="{StaticResource TextSecondaryBrush}"
                 FontFamily="{StaticResource FontPrimary}"
                 FontSize="12" TextWrapping="Wrap" LineHeight="18"
                 Margin="0,2,0,0"/>
    </StackPanel>
  </Grid>
</UserControl>
