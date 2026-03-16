<!--
  ╔══════════════════════════════════════════════════════════╗
  ║  Elstract Launcher — Views/HomePageView.xaml            ║
  ║  Welcome / Home page shown on every launcher start.     ║
  ║  Displays: version badge, open-source description,      ║
  ║  GitHub releases feed, quick-start buttons.             ║
  ╚══════════════════════════════════════════════════════════╝
-->
<UserControl x:Class="ElstractLauncher.Views.HomePageView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:vm="clr-namespace:ElstractLauncher.ViewModels"
             Background="Transparent">

  <ScrollViewer Style="{StaticResource ElstractScrollViewer}"
                VerticalScrollBarVisibility="Auto">
    <Grid Margin="40,36,40,36">
      <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>   <!-- Hero header          -->
        <RowDefinition Height="32"/>     <!-- Spacer               -->
        <RowDefinition Height="Auto"/>   <!-- Open source card     -->
        <RowDefinition Height="32"/>     <!-- Spacer               -->
        <RowDefinition Height="Auto"/>   <!-- Two-column bottom    -->
      </Grid.RowDefinitions>

      <!-- ══════════════════════════════════════════════
           HERO HEADER
           ══════════════════════════════════════════════ -->
      <Grid Grid.Row="0">
        <Grid.ColumnDefinitions>
          <ColumnDefinition Width="*"/>
          <ColumnDefinition Width="Auto"/>
        </Grid.ColumnDefinitions>

        <!-- Left: title + description -->
        <StackPanel Grid.Column="0" VerticalAlignment="Center">
          <!-- Greeting line -->
          <TextBlock Text="WELCOME TO"
                     Foreground="{StaticResource TextMutedBrush}"
                     FontFamily="{StaticResource FontDisplay}"
                     FontSize="12"
                     Margin="0,0,0,6"/>

          <!-- Large title -->
          <StackPanel Orientation="Horizontal">
            <TextBlock Text="Elstract"
                       Foreground="{StaticResource TextPrimaryBrush}"
                       FontFamily="{StaticResource FontDisplay}"
                       FontSize="42" FontWeight="Bold"/>
            <TextBlock Text=" Launcher"
                       FontFamily="{StaticResource FontDisplay}"
                       FontSize="42" FontWeight="Bold">
              <TextBlock.Foreground>
                <LinearGradientBrush StartPoint="0,0" EndPoint="1,0">
                  <GradientStop Color="#FF1A7A" Offset="0"/>
                  <GradientStop Color="#FF5FA3" Offset="1"/>
                </LinearGradientBrush>
              </TextBlock.Foreground>
              <TextBlock.Effect>
                <DropShadowEffect Color="#FF1A7A" BlurRadius="16"
                                  ShadowDepth="0" Opacity="0.5"/>
              </TextBlock.Effect>
            </TextBlock>
          </StackPanel>

          <TextBlock Text="Your personal open-source game library"
                     Foreground="{StaticResource TextSecondaryBrush}"
                     FontFamily="{StaticResource FontPrimary}"
                     FontSize="16" Margin="2,8,0,20"/>

          <!-- CTA buttons -->
          <StackPanel Orientation="Horizontal">
            <Button Style="{StaticResource PrimaryButton}"
                    Command="{Binding DataContext.NavLibraryCommand,
                              RelativeSource={RelativeSource AncestorType=Window}}"
                    Content="Open Library"
                    Padding="22,11" Margin="0,0,12,0"/>
            <Button Style="{StaticResource SecondaryButton}"
                    Command="{Binding OpenGitHubCommand}"
                    Content="★  View on GitHub"
                    Padding="18,11"/>
          </StackPanel>
        </StackPanel>

        <!-- Right: version + update badge -->
        <Border Grid.Column="1"
                Background="{StaticResource CardGradient}"
                BorderBrush="{StaticResource BorderSubtleBrush}"
                BorderThickness="1" CornerRadius="14"
                Padding="24,20" MinWidth="220"
                VerticalAlignment="Top" Margin="24,0,0,0">
          <Border.Effect>
            <DropShadowEffect Color="#000" BlurRadius="12" ShadowDepth="1" Opacity="0.4"/>
          </Border.Effect>
          <StackPanel>
            <TextBlock Text="CURRENT VERSION"
                       Foreground="{StaticResource TextMutedBrush}"
                       FontSize="10" FontWeight="SemiBold"
                       Margin="0,0,0,6"/>

            <StackPanel Orientation="Horizontal" VerticalAlignment="Center">
              <!-- Pink diamond icon -->
              <Viewbox Width="18" Height="18" Margin="0,0,10,0">
                <Canvas Width="100" Height="100">
                  <Polygon Points="50,5 95,50 50,95 5,50"
                           Fill="{StaticResource PinkGradient}"/>
                </Canvas>
              </Viewbox>
              <TextBlock Text="{Binding CurrentVersion, StringFormat='v{0}'}"
                         Foreground="{StaticResource TextPrimaryBrush}"
                         FontFamily="{StaticResource FontDisplay}"
                         FontSize="28" FontWeight="Bold"/>
            </StackPanel>

            <Separator Background="{StaticResource BorderSubtleBrush}" Margin="0,14,0,14"/>

            <!-- Update available banner -->
            <Border Visibility="{Binding UpdateAvailable,
                        Converter={StaticResource BoolToVisibilityConverter}}"
                    Background="#FF1A7A22"
                    BorderBrush="{StaticResource PinkPrimaryBrush}"
                    BorderThickness="1" CornerRadius="8"
                    Padding="10,8" Margin="0,0,0,10">
              <StackPanel>
                <TextBlock Text="🚀 Update Available!"
                           Foreground="{StaticResource PinkLightBrush}"
                           FontWeight="SemiBold" FontSize="12"/>
                <TextBlock Text="{Binding LatestVersion, StringFormat='Latest: {0}'}"
                           Foreground="{StaticResource TextSecondaryBrush}"
                           FontSize="11" Margin="0,2,0,0"/>
              </StackPanel>
            </Border>

            <!-- Up to date -->
            <Border Visibility="{Binding UpdateAvailable,
                        Converter={StaticResource InvertBoolToVisibilityConverter}}"
                    Background="#39D98A18"
                    BorderBrush="{StaticResource StatusGreenBrush}"
                    BorderThickness="1" CornerRadius="8"
                    Padding="10,8" Margin="0,0,0,10">
              <TextBlock Text="✓  Up to date"
                         Foreground="{StaticResource StatusGreenBrush}"
                         FontSize="12" FontWeight="SemiBold"/>
            </Border>

            <Button Style="{StaticResource SecondaryButton}"
                    Command="{Binding OpenReleasesCommand}"
                    Content="View Releases"
                    HorizontalAlignment="Stretch"
                    Padding="12,8"/>
          </StackPanel>
        </Border>
      </Grid>

      <!-- ══════════════════════════════════════════════
           OPEN SOURCE CARD
           ══════════════════════════════════════════════ -->
      <Border Grid.Row="2"
              Background="{StaticResource CardGradient}"
              BorderBrush="{StaticResource BorderSubtleBrush}"
              BorderThickness="1" CornerRadius="14"
              Padding="28,22">
        <Border.Effect>
          <DropShadowEffect Color="#000" BlurRadius="10" ShadowDepth="1" Opacity="0.35"/>
        </Border.Effect>
        <Grid>
          <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition Width="20"/>
            <ColumnDefinition Width="*"/>
          </Grid.ColumnDefinitions>

          <!-- MIT badge -->
          <Border Grid.Column="0"
                  Background="{StaticResource PinkGradient}"
                  CornerRadius="10" Padding="14,10"
                  VerticalAlignment="Top">
            <Border.Effect>
              <DropShadowEffect Color="#FF1A7A" BlurRadius="14"
                                ShadowDepth="0" Opacity="0.5"/>
            </Border.Effect>
            <StackPanel HorizontalAlignment="Center">
              <TextBlock Text="⊕"
                         Foreground="White" FontSize="26"
                         HorizontalAlignment="Center"/>
              <TextBlock Text="OPEN SOURCE"
                         Foreground="White" FontSize="9"
                         FontWeight="Bold"
                         HorizontalAlignment="Center" Margin="0,4,0,0"/>
              <TextBlock Text="MIT LICENSE"
                         Foreground="#FFFFFF99" FontSize="9"
                         HorizontalAlignment="Center"/>
            </StackPanel>
          </Border>

          <!-- Description -->
          <StackPanel Grid.Column="2">
            <TextBlock Text="Free &amp; Open Source for Everyone"
                       Foreground="{StaticResource TextPrimaryBrush}"
                       FontFamily="{StaticResource FontDisplay}"
                       FontSize="20" FontWeight="SemiBold"
                       Margin="0,0,0,10"/>

            <TextBlock Text="{Binding OpenSourceDescription}"
                       Foreground="{StaticResource TextSecondaryBrush}"
                       FontFamily="{StaticResource FontPrimary}"
                       FontSize="13.5" LineHeight="22"
                       TextWrapping="Wrap"/>

            <StackPanel Orientation="Horizontal" Margin="0,16,0,0">
              <Border Background="#FF1A7A22" BorderBrush="{StaticResource PinkPrimaryBrush}"
                      BorderThickness="1" CornerRadius="6" Padding="10,5" Margin="0,0,10,0">
                <TextBlock Text="⭐  Star on GitHub"
                           Foreground="{StaticResource PinkLightBrush}"
                           FontSize="12" FontWeight="SemiBold"
                           Cursor="Hand">
                  <TextBlock.InputBindings>
                    <MouseBinding MouseAction="LeftClick"
                                  Command="{Binding OpenGitHubCommand}"/>
                  </TextBlock.InputBindings>
                </TextBlock>
              </Border>
              <Border Background="#39D98A18" BorderBrush="{StaticResource StatusGreenBrush}"
                      BorderThickness="1" CornerRadius="6" Padding="10,5" Margin="0,0,10,0">
                <TextBlock Text="🍴  Fork &amp; Customize"
                           Foreground="{StaticResource StatusGreenBrush}"
                           FontSize="12" FontWeight="SemiBold"
                           Cursor="Hand">
                  <TextBlock.InputBindings>
                    <MouseBinding MouseAction="LeftClick"
                                  Command="{Binding OpenGitHubCommand}"/>
                  </TextBlock.InputBindings>
                </TextBlock>
              </Border>
              <Border Background="#22B8FF18" BorderBrush="#22B8FF"
                      BorderThickness="1" CornerRadius="6" Padding="10,5">
                <TextBlock Text="🔧  Contribute"
                           Foreground="#22B8FF"
                           FontSize="12" FontWeight="SemiBold"
                           Cursor="Hand">
                  <TextBlock.InputBindings>
                    <MouseBinding MouseAction="LeftClick"
                                  Command="{Binding OpenGitHubCommand}"/>
                  </TextBlock.InputBindings>
                </TextBlock>
              </Border>
            </StackPanel>
          </StackPanel>
        </Grid>
      </Border>

      <!-- ══════════════════════════════════════════════
           BOTTOM: Features + GitHub Releases
           ══════════════════════════════════════════════ -->
      <Grid Grid.Row="4">
        <Grid.ColumnDefinitions>
          <ColumnDefinition Width="*"/>
          <ColumnDefinition Width="20"/>
          <ColumnDefinition Width="340"/>
        </Grid.ColumnDefinitions>

        <!-- Feature highlights -->
        <Border Grid.Column="0"
                Background="{StaticResource CardGradient}"
                BorderBrush="{StaticResource BorderSubtleBrush}"
                BorderThickness="1" CornerRadius="14"
                Padding="24,20">
          <StackPanel>
            <TextBlock Text="FEATURES"
                       Foreground="{StaticResource TextMutedBrush}"
                       FontSize="10" FontWeight="Bold"
                       Margin="0,0,0,14"/>

            <ItemsControl>
              <ItemsControl.Items>
                <StackPanel/>
              </ItemsControl.Items>
            </ItemsControl>

            <!-- Feature rows -->
            <local:FeatureRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                              Icon="🎮" Title="Game Library"
                              Desc="Add any game by searching Steam or SteamDB. Fully offline after adding."/>
            <local:FeatureRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                              Icon="⏱" Title="Play Time Tracking"
                              Desc="Automatic session timer. See total hours per game."/>
            <local:FeatureRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                              Icon="🎨" Title="Custom Icons"
                              Desc="Override any game icon with your own image or auto-fetch from Steam CDN."/>
            <local:FeatureRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                              Icon="💬" Title="Discord Rich Presence"
                              Desc="Shows what you're playing in Discord with game art and timer."/>
            <local:FeatureRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                              Icon="🔒" Title="100% Local &amp; Private"
                              Desc="No accounts, no telemetry, no external servers. Everything stays on your PC."/>
            <local:FeatureRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                              Icon="🚀" Title="Lightning Fast Launch"
                              Desc="Direct .exe launch with optional minimize-on-start."/>
          </StackPanel>
        </Border>

        <!-- GitHub Releases feed -->
        <Border Grid.Column="2"
                Background="{StaticResource CardGradient}"
                BorderBrush="{StaticResource BorderSubtleBrush}"
                BorderThickness="1" CornerRadius="14"
                Padding="20,20">
          <DockPanel>
            <Grid DockPanel.Dock="Top" Margin="0,0,0,14">
              <TextBlock Text="GITHUB RELEASES"
                         Foreground="{StaticResource TextMutedBrush}"
                         FontSize="10" FontWeight="Bold"
                         VerticalAlignment="Center"/>
              <Button DockPanel.Dock="Right"
                      HorizontalAlignment="Right"
                      Style="{StaticResource IconButton}"
                      Command="{Binding RefreshReleasesCommand}"
                      ToolTip="Refresh" Padding="4">
                <TextBlock Text="↻" Foreground="{StaticResource TextSecondaryBrush}" FontSize="14"/>
              </Button>
            </Grid>

            <!-- Loading indicator -->
            <TextBlock DockPanel.Dock="Top"
                       Text="Loading releases…"
                       Foreground="{StaticResource TextMutedBrush}"
                       FontSize="12" Margin="0,0,0,8"
                       Visibility="{Binding IsLoadingReleases,
                           Converter={StaticResource BoolToVisibilityConverter}}"/>

            <!-- Releases list -->
            <ScrollViewer DockPanel.Dock="Top"
                          Style="{StaticResource ElstractScrollViewer}"
                          VerticalScrollBarVisibility="Auto"
                          MaxHeight="340">
              <ItemsControl ItemsSource="{Binding Releases}">
                <ItemsControl.ItemTemplate>
                  <DataTemplate>
                    <Border Margin="0,0,0,8"
                            Background="{StaticResource BgInputBrush}"
                            BorderBrush="{StaticResource BorderSubtleBrush}"
                            BorderThickness="1" CornerRadius="8"
                            Padding="12,10"
                            Cursor="Hand">
                      <Border.InputBindings>
                        <MouseBinding MouseAction="LeftClick"
                                      Command="{Binding DataContext.OpenReleasesCommand,
                                                RelativeSource={RelativeSource AncestorType=UserControl}}"/>
                      </Border.InputBindings>
                      <Grid>
                        <Grid.ColumnDefinitions>
                          <ColumnDefinition Width="*"/>
                          <ColumnDefinition Width="Auto"/>
                        </Grid.ColumnDefinitions>
                        <StackPanel Grid.Column="0">
                          <TextBlock Text="{Binding TagName}"
                                     Foreground="{StaticResource PinkLightBrush}"
                                     FontSize="13" FontWeight="SemiBold"/>
                          <TextBlock Text="{Binding Name}"
                                     Foreground="{StaticResource TextSecondaryBrush}"
                                     FontSize="11" Margin="0,2,0,0"
                                     TextTrimming="CharacterEllipsis"/>
                          <TextBlock Text="{Binding PublishedAt, StringFormat='{}{0:dd MMM yyyy}'}"
                                     Foreground="{StaticResource TextMutedBrush}"
                                     FontSize="10" Margin="0,2,0,0"/>
                        </StackPanel>
                        <!-- Pre-release badge -->
                        <Border Grid.Column="1"
                                Background="#FFC31222"
                                BorderBrush="#FFC312"
                                BorderThickness="1" CornerRadius="4"
                                Padding="5,2" VerticalAlignment="Top"
                                Visibility="{Binding IsPreRelease,
                                    Converter={StaticResource BoolToVisibilityConverter}}">
                          <TextBlock Text="PRE"
                                     Foreground="#FFC312"
                                     FontSize="9" FontWeight="Bold"/>
                        </Border>
                      </Grid>
                    </Border>
                  </DataTemplate>
                </ItemsControl.ItemTemplate>
              </ItemsControl>
            </ScrollViewer>
          </DockPanel>
        </Border>
      </Grid>

    </Grid>
  </ScrollViewer>
</UserControl>
