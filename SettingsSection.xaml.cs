<!--
  ╔══════════════════════════════════════════════════════════╗
  ║  Elstract Launcher — Views/SettingsView.xaml            ║
  ║  Settings page: launch behavior, Discord RPC, UI prefs  ║
  ╚══════════════════════════════════════════════════════════╝
-->
<UserControl x:Class="ElstractLauncher.Views.SettingsView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             Background="Transparent">

  <ScrollViewer Style="{StaticResource ElstractScrollViewer}"
                VerticalScrollBarVisibility="Auto">
    <StackPanel Margin="40,36,40,36" MaxWidth="700">

      <!-- Page header -->
      <TextBlock Text="Settings"
                 Foreground="{StaticResource TextPrimaryBrush}"
                 FontFamily="{StaticResource FontDisplay}"
                 FontSize="32" FontWeight="Bold"
                 Margin="0,0,0,6"/>
      <TextBlock Text="Customise how Elstract Launcher behaves"
                 Foreground="{StaticResource TextSecondaryBrush}"
                 FontSize="14" Margin="0,0,0,32"/>

      <!-- ── Launch behavior ─────────────────────────────────── -->
      <local:SettingsSection xmlns:local="clr-namespace:ElstractLauncher.Views"
                             Title="Launch Behavior"
                             Icon="🚀"/>

      <local:SettingsToggleRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                               Label="Minimize on game launch"
                               Desc="Minimise the launcher to the taskbar when a game starts"
                               IsOn="{Binding Settings.MinimizeOnLaunch, Mode=TwoWay}"/>

      <local:SettingsToggleRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                               Label="Close launcher when game exits"
                               Desc="Automatically close Elstract when you quit a game"
                               IsOn="{Binding Settings.CloseOnGameExit, Mode=TwoWay}"/>

      <local:SettingsToggleRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                               Label="Track play time"
                               Desc="Record how long you play each session"
                               IsOn="{Binding Settings.TrackPlayTime, Mode=TwoWay}"/>

      <Border Height="1" Background="{StaticResource BorderSubtleBrush}" Margin="0,20,0,20"/>

      <!-- ── Discord RPC ─────────────────────────────────────── -->
      <local:SettingsSection xmlns:local="clr-namespace:ElstractLauncher.Views"
                             Title="Discord Rich Presence"
                             Icon="💬"/>

      <local:SettingsToggleRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                               Label="Enable Discord Rich Presence"
                               Desc="Show your status in Discord while the launcher is open"
                               IsOn="{Binding Settings.DiscordRpcEnabled, Mode=TwoWay}"/>

      <local:SettingsToggleRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                               Label="Show game name in Discord status"
                               Desc="Display which game you are currently playing"
                               IsOn="{Binding Settings.DiscordRpcShowGameName, Mode=TwoWay}"/>

      <!-- Discord app ID note -->
      <Border Background="{StaticResource PinkGradientSubtle}"
              BorderBrush="{StaticResource BorderActiveBrush}"
              BorderThickness="1" CornerRadius="8"
              Padding="14,10" Margin="0,4,0,0">
        <StackPanel Orientation="Horizontal">
          <TextBlock Text="ℹ" Foreground="{StaticResource PinkLightBrush}" FontSize="14"
                     VerticalAlignment="Center"/>
          <TextBlock Foreground="{StaticResource TextSecondaryBrush}" FontSize="12"
                     TextWrapping="Wrap">
            <Run Text="Rich Presence requires a Discord Application ID. Set yours in "/>
            <Run Text="Services/DiscordService.cs → ClientId"
                 Foreground="{StaticResource PinkLightBrush}"
                 FontFamily="{StaticResource FontMono}"/>
            <Run Text=". Register at discord.com/developers"/>
          </TextBlock>
        </StackPanel>
      </Border>

      <Border Height="1" Background="{StaticResource BorderSubtleBrush}" Margin="0,20,0,20"/>

      <!-- ── Data & Storage ─────────────────────────────────── -->
      <local:SettingsSection xmlns:local="clr-namespace:ElstractLauncher.Views"
                             Title="Data &amp; Storage"
                             Icon="💾"/>

      <StackPanel Margin="0,0,0,14">
        <TextBlock Text="Library data location"
                   Foreground="{StaticResource TextPrimaryBrush}"
                   FontSize="13" FontWeight="SemiBold"/>
        <Border Background="{StaticResource BgInputBrush}"
                BorderBrush="{StaticResource BorderSubtleBrush}"
                BorderThickness="1" CornerRadius="8"
                Padding="12,8" Margin="0,6,0,0">
          <TextBlock FontFamily="{StaticResource FontMono}"
                     FontSize="11"
                     Foreground="{StaticResource TextSecondaryBrush}"
                     Text="%AppData%\Elstract\library.json"/>
        </Border>
      </StackPanel>

      <StackPanel Margin="0,0,0,14">
        <TextBlock Text="Icons cache location"
                   Foreground="{StaticResource TextPrimaryBrush}"
                   FontSize="13" FontWeight="SemiBold"/>
        <Border Background="{StaticResource BgInputBrush}"
                BorderBrush="{StaticResource BorderSubtleBrush}"
                BorderThickness="1" CornerRadius="8"
                Padding="12,8" Margin="0,6,0,0">
          <TextBlock FontFamily="{StaticResource FontMono}"
                     FontSize="11"
                     Foreground="{StaticResource TextSecondaryBrush}"
                     Text="{Binding Settings.CustomIconsFolder}"/>
        </Border>
      </StackPanel>

      <Border Height="1" Background="{StaticResource BorderSubtleBrush}" Margin="0,20,0,20"/>

      <!-- ── About ──────────────────────────────────────────── -->
      <local:SettingsSection xmlns:local="clr-namespace:ElstractLauncher.Views"
                             Title="About"
                             Icon="★"/>

      <Border Background="{StaticResource CardGradient}"
              BorderBrush="{StaticResource BorderSubtleBrush}"
              BorderThickness="1" CornerRadius="12"
              Padding="20,16" Margin="0,0,0,20">
        <Grid>
          <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="Auto"/>
          </Grid.ColumnDefinitions>
          <StackPanel Grid.Column="0">
            <TextBlock Text="Elstract Launcher"
                       Foreground="{StaticResource TextPrimaryBrush}"
                       FontFamily="{StaticResource FontDisplay}"
                       FontSize="16" FontWeight="Bold"/>
            <TextBlock Text="{Binding Source={x:Static system:App.AppVersion},
                              StringFormat='Version {0}', FallbackValue='Version 1.0.0'}"
                       xmlns:system="clr-namespace:ElstractLauncher"
                       Foreground="{StaticResource TextSecondaryBrush}"
                       FontSize="12" Margin="0,3,0,6"/>
            <TextBlock Text="MIT License — Free &amp; Open Source"
                       Foreground="{StaticResource TextMutedBrush}"
                       FontSize="11"/>
            <TextBlock Text="© 2025 Elstract Community"
                       Foreground="{StaticResource TextMutedBrush}"
                       FontSize="11" Margin="0,2,0,0"/>
          </StackPanel>
          <Viewbox Grid.Column="1" Width="40" Height="40" VerticalAlignment="Center">
            <Canvas Width="100" Height="100">
              <Polygon Points="50,5 95,50 50,95 5,50"
                       Fill="{StaticResource PinkGradient}"/>
              <Polygon Points="50,28 72,50 50,72 28,50"
                       Fill="#130F18" Opacity="0.7"/>
            </Canvas>
          </Viewbox>
        </Grid>
      </Border>

      <!-- Save button -->
      <Button Style="{StaticResource PrimaryButton}"
              Command="{Binding SaveCommand}"
              Content="Save Settings"
              HorizontalAlignment="Left"
              Padding="24,12"/>

    </StackPanel>
  </ScrollViewer>
</UserControl>
