<!--
  ╔══════════════════════════════════════════════════════════╗
  ║  Elstract Launcher — Views/LibraryView.xaml             ║
  ║  Full library page:                                     ║
  ║  • Top bar: search filter + "Add Game" button           ║
  ║  • Grid of game cards                                   ║
  ║  • Right detail panel when a game is selected           ║
  ║  • Slide-in Steam search panel for adding games         ║
  ╚══════════════════════════════════════════════════════════╝
-->
<UserControl x:Class="ElstractLauncher.Views.LibraryView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             Background="Transparent">

  <Grid>
    <Grid.ColumnDefinitions>
      <ColumnDefinition Width="*"/>
      <!-- Game detail panel, hidden when no selection -->
      <ColumnDefinition Width="{Binding SelectedGame, 
          Converter={StaticResource NullToWidthConverter}, 
          ConverterParameter=320}"/>
    </Grid.ColumnDefinitions>

    <!-- ════════════════════════════════════════════════════
         LEFT: Game list area
         ════════════════════════════════════════════════════ -->
    <DockPanel Grid.Column="0">

      <!-- Top bar -->
      <Border DockPanel.Dock="Top"
              Background="{StaticResource BgDeepBrush}"
              BorderBrush="{StaticResource BorderSubtleBrush}"
              BorderThickness="0,0,0,1"
              Padding="24,14">
        <Grid>
          <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="Auto"/>
          </Grid.ColumnDefinitions>

          <!-- Filter search box -->
          <Grid Grid.Column="0" MaxWidth="420" HorizontalAlignment="Left">
            <TextBox Style="{StaticResource ElstractTextBox}"
                     Text="{Binding FilterText, UpdateSourceTrigger=PropertyChanged}"
                     Padding="36,9,12,9"/>
            <TextBlock Text="🔍" VerticalAlignment="Center"
                       Margin="12,0,0,0" FontSize="13"
                       Foreground="{StaticResource TextMutedBrush}"
                       IsHitTestVisible="False"/>
          </Grid>

          <!-- Add game button -->
          <Button Grid.Column="1"
                  Style="{StaticResource PrimaryButton}"
                  Command="{Binding OpenAddPanelCommand}"
                  Padding="18,9">
            <StackPanel Orientation="Horizontal" Spacing="8">
              <TextBlock Text="+" FontSize="16" FontWeight="Bold"
                         VerticalAlignment="Center"/>
              <TextBlock Text="Add Game" VerticalAlignment="Center"/>
            </StackPanel>
          </Button>
        </Grid>
      </Border>

      <!-- Games grid -->
      <ScrollViewer DockPanel.Dock="Top"
                    Style="{StaticResource ElstractScrollViewer}"
                    VerticalScrollBarVisibility="Auto"
                    Padding="20,20,8,20">
        <ItemsControl ItemsSource="{Binding GamesView}">
          <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
              <WrapPanel Orientation="Horizontal"/>
            </ItemsPanelTemplate>
          </ItemsControl.ItemsPanel>
          <ItemsControl.ItemTemplate>
            <DataTemplate>
              <!-- Game card -->
              <Border x:Name="GameCard"
                      Width="180" Height="240"
                      Margin="0,0,14,14"
                      Background="{StaticResource CardGradient}"
                      BorderBrush="{StaticResource BorderSubtleBrush}"
                      BorderThickness="1" CornerRadius="12"
                      Cursor="Hand">
                <Border.Effect>
                  <DropShadowEffect Color="#000" BlurRadius="8"
                                    ShadowDepth="1" Opacity="0.4"/>
                </Border.Effect>
                <Border.InputBindings>
                  <MouseBinding MouseAction="LeftClick"
                                Command="{Binding DataContext.SelectGameCommand,
                                          RelativeSource={RelativeSource AncestorType=UserControl}}"
                                CommandParameter="{Binding}"/>
                  <MouseBinding MouseAction="LeftDoubleClick"
                                Command="{Binding DataContext.LaunchGameCommand,
                                          RelativeSource={RelativeSource AncestorType=UserControl}}"
                                CommandParameter="{Binding}"/>
                </Border.InputBindings>

                <Grid>
                  <Grid.RowDefinitions>
                    <RowDefinition Height="*"/>
                    <RowDefinition Height="Auto"/>
                  </Grid.RowDefinitions>

                  <!-- Game banner image -->
                  <Border Grid.Row="0" CornerRadius="12,12,0,0" ClipToBounds="True">
                    <Grid>
                      <!-- Fallback gradient when no image -->
                      <Border Background="{StaticResource PinkGradientSubtle}">
                        <TextBlock Text="{Binding Name}"
                                   Foreground="{StaticResource TextMutedBrush}"
                                   HorizontalAlignment="Center"
                                   VerticalAlignment="Center"
                                   TextWrapping="Wrap"
                                   TextAlignment="Center"
                                   Margin="10" FontSize="13"
                                   Visibility="{Binding DisplayIconPath,
                                       Converter={StaticResource NullToVisibilityConverter}}"/>
                      </Border>
                      <!-- Actual image -->
                      <Image Source="{Binding DisplayIconPath}"
                             Stretch="UniformToFill"
                             HorizontalAlignment="Center"
                             VerticalAlignment="Center"
                             Visibility="{Binding DisplayIconPath,
                                 Converter={StaticResource NotNullToVisibilityConverter}}"/>

                      <!-- Running badge overlay -->
                      <Border HorizontalAlignment="Right" VerticalAlignment="Top"
                              Margin="6" Padding="6,3"
                              Background="#39D98AEE" CornerRadius="6"
                              Visibility="{Binding IsRunning,
                                  Converter={StaticResource BoolToVisibilityConverter}}">
                        <TextBlock Text="▶ Running"
                                   Foreground="White" FontSize="10" FontWeight="Bold"/>
                      </Border>

                      <!-- Favourite star -->
                      <Border HorizontalAlignment="Left" VerticalAlignment="Top"
                              Margin="6" Padding="4"
                              Visibility="{Binding IsFavourite,
                                  Converter={StaticResource BoolToVisibilityConverter}}">
                        <TextBlock Text="★" Foreground="#FFC312" FontSize="14">
                          <TextBlock.Effect>
                            <DropShadowEffect Color="#000" BlurRadius="4"
                                              ShadowDepth="0" Opacity="0.8"/>
                          </TextBlock.Effect>
                        </TextBlock>
                      </Border>
                    </Grid>
                  </Border>

                  <!-- Bottom info bar -->
                  <Border Grid.Row="1"
                          Background="#0D0A10CC"
                          CornerRadius="0,0,12,12"
                          Padding="10,8">
                    <Grid>
                      <Grid.RowDefinitions>
                        <RowDefinition/>
                        <RowDefinition/>
                      </Grid.RowDefinitions>
                      <TextBlock Grid.Row="0"
                                 Text="{Binding Name}"
                                 Foreground="{StaticResource TextPrimaryBrush}"
                                 FontSize="12" FontWeight="SemiBold"
                                 TextTrimming="CharacterEllipsis"/>
                      <StackPanel Grid.Row="1" Orientation="Horizontal" Spacing="6" Margin="0,2,0,0">
                        <TextBlock Text="⏱" FontSize="9"
                                   Foreground="{StaticResource TextMutedBrush}"
                                   VerticalAlignment="Center"/>
                        <TextBlock Text="{Binding PlayTimeDisplay}"
                                   Foreground="{StaticResource TextSecondaryBrush}"
                                   FontSize="10"/>

                        <!-- No EXE warning -->
                        <TextBlock Text="⚠ No EXE"
                                   Foreground="{StaticResource StatusYellowBrush}"
                                   FontSize="10"
                                   Visibility="{Binding IsExeLinked,
                                       Converter={StaticResource InvertBoolToVisibilityConverter}}"/>
                      </StackPanel>
                    </Grid>
                  </Border>
                </Grid>
              </Border>

              <!-- Card hover animation trigger -->
              <DataTemplate.Triggers>
                <DataTrigger Binding="{Binding IsMouseOver,
                                 RelativeSource={RelativeSource AncestorType=Border,
                                 AncestorLevel=1}}"
                             Value="True">
                  <Setter TargetName="GameCard" Property="BorderBrush"
                          Value="{StaticResource PinkPrimaryBrush}"/>
                </DataTrigger>
              </DataTemplate.Triggers>
            </DataTemplate>
          </ItemsControl.ItemTemplate>
        </ItemsControl>
      </ScrollViewer>
    </DockPanel>

    <!-- ════════════════════════════════════════════════════
         RIGHT: Game detail panel
         ════════════════════════════════════════════════════ -->
    <Border Grid.Column="1"
            Background="{StaticResource BgSidebarBrush}"
            BorderBrush="{StaticResource BorderSubtleBrush}"
            BorderThickness="1,0,0,0"
            Visibility="{Binding SelectedGame,
                Converter={StaticResource NotNullToVisibilityConverter}}">
      <DockPanel DataContext="{Binding SelectedGame}">

        <!-- Header image -->
        <Border DockPanel.Dock="Top" Height="140" ClipToBounds="True">
          <Grid>
            <Border Background="{StaticResource PinkGradientSubtle}"/>
            <Image Source="{Binding SteamHeaderUrl}"
                   Stretch="UniformToFill"/>
            <!-- Dark gradient overlay -->
            <Border>
              <Border.Background>
                <LinearGradientBrush StartPoint="0,0" EndPoint="0,1">
                  <GradientStop Color="#00000000" Offset="0"/>
                  <GradientStop Color="#CC160F1E" Offset="1"/>
                </LinearGradientBrush>
              </Border.Background>
            </Border>
          </Grid>
        </Border>

        <!-- Game name + actions -->
        <StackPanel DockPanel.Dock="Top" Margin="16,12,16,0">
          <TextBlock Text="{Binding Name}"
                     Foreground="{StaticResource TextPrimaryBrush}"
                     FontFamily="{StaticResource FontDisplay}"
                     FontSize="17" FontWeight="Bold"
                     TextWrapping="Wrap"/>

          <TextBlock Text="{Binding Developer}"
                     Foreground="{StaticResource TextSecondaryBrush}"
                     FontSize="12" Margin="0,3,0,0"/>

          <!-- Action buttons -->
          <Grid Margin="0,14,0,0">
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="*"/>
              <ColumnDefinition Width="8"/>
              <ColumnDefinition Width="Auto"/>
            </Grid.ColumnDefinitions>

            <!-- Play / No EXE button -->
            <Button Grid.Column="0"
                    Style="{StaticResource PrimaryButton}"
                    Command="{Binding DataContext.LaunchGameCommand,
                              RelativeSource={RelativeSource AncestorType=UserControl}}"
                    CommandParameter="{Binding}"
                    HorizontalAlignment="Stretch">
              <StackPanel Orientation="Horizontal" Spacing="6">
                <TextBlock Text="▶" FontSize="12" VerticalAlignment="Center"/>
                <TextBlock Text="{Binding IsExeLinked,
                               Converter={StaticResource BoolToPlayTextConverter}}"
                           VerticalAlignment="Center"/>
              </StackPanel>
            </Button>

            <!-- More options dropdown -->
            <Button Grid.Column="2"
                    Style="{StaticResource SecondaryButton}"
                    Padding="10,9"
                    ToolTip="Options">
              <TextBlock Text="⋮" FontSize="14"
                         Foreground="{StaticResource PinkLightBrush}"/>
              <Button.ContextMenu>
                <ContextMenu Background="{StaticResource BgCardBrush}"
                             BorderBrush="{StaticResource BorderSubtleBrush}"
                             BorderThickness="1">
                  <MenuItem Header="Link / Change EXE"
                            Command="{Binding DataContext.LinkExeCommand,
                                      PlacementTarget={RelativeSource Self}}"
                            CommandParameter="{Binding}"/>
                  <MenuItem Header="Change Icon"
                            Command="{Binding DataContext.ChangeIconCommand,
                                      PlacementTarget={RelativeSource Self}}"
                            CommandParameter="{Binding}"/>
                  <MenuItem Header="Toggle Favourite"
                            Command="{Binding DataContext.ToggleFavouriteCommand,
                                      PlacementTarget={RelativeSource Self}}"
                            CommandParameter="{Binding}"/>
                  <Separator/>
                  <MenuItem Header="Remove from Library"
                            Command="{Binding DataContext.RemoveGameCommand,
                                      PlacementTarget={RelativeSource Self}}"
                            CommandParameter="{Binding}"/>
                </ContextMenu>
              </Button.ContextMenu>
            </Button>
          </Grid>
        </StackPanel>

        <!-- Separator -->
        <Separator DockPanel.Dock="Top"
                   Background="{StaticResource BorderSubtleBrush}"
                   Margin="16,14,16,0"/>

        <!-- Stats -->
        <ScrollViewer DockPanel.Dock="Top"
                      Style="{StaticResource ElstractScrollViewer}"
                      VerticalScrollBarVisibility="Auto"
                      Margin="16,14,16,16">
          <StackPanel Spacing="10">

            <!-- Stat row: playtime -->
            <local:StatRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                           Label="Total Play Time"
                           Value="{Binding PlayTimeDisplay}"/>
            <local:StatRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                           Label="Last Played"
                           Value="{Binding LastPlayedDisplay}"/>
            <local:StatRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                           Label="Launch Count"
                           Value="{Binding LaunchCount}"/>
            <local:StatRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                           Label="Added"
                           Value="{Binding AddedDate, StringFormat='{}{0:dd MMM yyyy}'}"/>
            <local:StatRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                           Label="Genres"
                           Value="{Binding Genres}"/>
            <local:StatRow xmlns:local="clr-namespace:ElstractLauncher.Views"
                           Label="Steam App ID"
                           Value="{Binding SteamAppId}"/>

            <!-- EXE path -->
            <StackPanel>
              <TextBlock Text="Executable"
                         Foreground="{StaticResource TextMutedBrush}"
                         FontSize="11"/>
              <TextBlock Text="{Binding ExePath, TargetNullValue='Not linked — click ⚙ to set'}"
                         Foreground="{StaticResource TextSecondaryBrush}"
                         FontSize="11" TextWrapping="Wrap"
                         Margin="0,3,0,0"/>
            </StackPanel>

            <!-- Description -->
            <StackPanel Visibility="{Binding Description,
                            Converter={StaticResource NotNullToVisibilityConverter}}">
              <TextBlock Text="Description"
                         Foreground="{StaticResource TextMutedBrush}"
                         FontSize="11" Margin="0,6,0,4"/>
              <TextBlock Text="{Binding Description}"
                         Foreground="{StaticResource TextSecondaryBrush}"
                         FontSize="12" TextWrapping="Wrap" LineHeight="18"/>
            </StackPanel>
          </StackPanel>
        </ScrollViewer>
      </DockPanel>
    </Border>

    <!-- ════════════════════════════════════════════════════
         OVERLAY: Steam search slide-in panel
         ════════════════════════════════════════════════════ -->
    <Grid Grid.Column="0" Grid.ColumnSpan="2"
          Visibility="{Binding IsAddPanelOpen,
              Converter={StaticResource BoolToVisibilityConverter}}">

      <!-- Dark overlay -->
      <Border Background="#000000CC">
        <Border.InputBindings>
          <MouseBinding MouseAction="LeftClick"
                        Command="{Binding CloseAddPanelCommand}"/>
        </Border.InputBindings>
      </Border>

      <!-- Search panel -->
      <Border HorizontalAlignment="Center" VerticalAlignment="Center"
              Width="580" MaxHeight="680"
              Background="{StaticResource BgCardBrush}"
              BorderBrush="{StaticResource BorderActiveBrush}"
              BorderThickness="1" CornerRadius="16"
              Padding="0">
        <Border.Effect>
          <DropShadowEffect Color="#FF1A7A" BlurRadius="30"
                            ShadowDepth="0" Opacity="0.3"/>
        </Border.Effect>

        <DockPanel Margin="28,24,28,24">
          <!-- Panel header -->
          <Grid DockPanel.Dock="Top" Margin="0,0,0,20">
            <StackPanel>
              <TextBlock Text="Add Game to Library"
                         Foreground="{StaticResource TextPrimaryBrush}"
                         FontFamily="{StaticResource FontDisplay}"
                         FontSize="20" FontWeight="Bold"/>
              <TextBlock Text="Search Steam to find and add games"
                         Foreground="{StaticResource TextSecondaryBrush}"
                         FontSize="13" Margin="0,4,0,0"/>
            </StackPanel>
            <Button HorizontalAlignment="Right" VerticalAlignment="Top"
                    Style="{StaticResource IconButton}"
                    Command="{Binding CloseAddPanelCommand}"
                    Padding="6">
              <TextBlock Text="✕" FontSize="14"
                         Foreground="{StaticResource TextSecondaryBrush}"/>
            </Button>
          </Grid>

          <!-- Search input row -->
          <Grid DockPanel.Dock="Top" Margin="0,0,0,16">
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="*"/>
              <ColumnDefinition Width="10"/>
              <ColumnDefinition Width="Auto"/>
            </Grid.ColumnDefinitions>
            <TextBox Grid.Column="0"
                     Style="{StaticResource ElstractTextBox}"
                     Text="{Binding SteamQuery, UpdateSourceTrigger=PropertyChanged}"
                     FontSize="14">
              <TextBox.InputBindings>
                <KeyBinding Key="Return" Command="{Binding SteamSearchCommand}"/>
              </TextBox.InputBindings>
            </TextBox>
            <Button Grid.Column="2"
                    Style="{StaticResource PrimaryButton}"
                    Command="{Binding SteamSearchCommand}"
                    Content="Search" Padding="18,9"/>
          </Grid>

          <!-- Loading spinner -->
          <TextBlock DockPanel.Dock="Top"
                     Text="Searching Steam…"
                     Foreground="{StaticResource TextMutedBrush}"
                     FontSize="13" Margin="0,0,0,10"
                     HorizontalAlignment="Center"
                     Visibility="{Binding IsSearching,
                         Converter={StaticResource BoolToVisibilityConverter}}"/>

          <!-- Results list -->
          <ScrollViewer DockPanel.Dock="Top"
                        Style="{StaticResource ElstractScrollViewer}"
                        VerticalScrollBarVisibility="Auto"
                        MaxHeight="420">
            <ItemsControl ItemsSource="{Binding SteamResults}">
              <ItemsControl.ItemTemplate>
                <DataTemplate>
                  <Border Margin="0,0,0,8"
                          Background="{StaticResource BgInputBrush}"
                          BorderBrush="{StaticResource BorderSubtleBrush}"
                          BorderThickness="1" CornerRadius="10"
                          Padding="14,10" Cursor="Hand">
                    <Border.InputBindings>
                      <MouseBinding MouseAction="LeftClick"
                                    Command="{Binding DataContext.AddSteamGameCommand,
                                              RelativeSource={RelativeSource AncestorType=UserControl}}"
                                    CommandParameter="{Binding}"/>
                    </Border.InputBindings>
                    <Grid>
                      <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="80"/>
                        <ColumnDefinition Width="12"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="Auto"/>
                      </Grid.ColumnDefinitions>
                      <!-- Thumbnail -->
                      <Border Grid.Column="0" CornerRadius="6" ClipToBounds="True"
                              Height="37" Background="{StaticResource PinkGradientSubtle}">
                        <Image Source="{Binding IconUrl}" Stretch="UniformToFill"/>
                      </Border>
                      <!-- Info -->
                      <StackPanel Grid.Column="2" VerticalAlignment="Center">
                        <TextBlock Text="{Binding Name}"
                                   Foreground="{StaticResource TextPrimaryBrush}"
                                   FontSize="13" FontWeight="SemiBold"/>
                        <TextBlock Text="{Binding AppId, StringFormat='Steam App #{0}'}"
                                   Foreground="{StaticResource TextMutedBrush}"
                                   FontSize="11" Margin="0,2,0,0"/>
                      </StackPanel>
                      <!-- Add arrow -->
                      <TextBlock Grid.Column="3"
                                 Text="＋ Add"
                                 Foreground="{StaticResource PinkLightBrush}"
                                 FontSize="12" FontWeight="SemiBold"
                                 VerticalAlignment="Center"/>
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
</UserControl>
