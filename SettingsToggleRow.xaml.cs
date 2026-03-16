<!--
  Elstract Launcher — Views/CustomGameDialog.xaml
  Full custom game editor: name, description, icon, background image.
-->
<Window x:Class="ElstractLauncher.Views.CustomGameDialog"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Add Custom Game"
        Width="540" Height="520"
        WindowStyle="None"
        AllowsTransparency="True"
        Background="Transparent"
        WindowStartupLocation="CenterOwner"
        ResizeMode="NoResize"
        ShowInTaskbar="False">

  <Border CornerRadius="14"
          Background="{StaticResource BgCardBrush}"
          BorderBrush="{StaticResource BorderActiveBrush}"
          BorderThickness="1">
    <Border.Effect>
      <DropShadowEffect Color="#FF1A7A" BlurRadius="24" ShadowDepth="0" Opacity="0.3"/>
    </Border.Effect>

    <DockPanel Margin="28,22,28,22">

      <!-- Title bar -->
      <Grid DockPanel.Dock="Top" Margin="0,0,0,18">
        <StackPanel>
          <TextBlock Text="Add Custom Game"
                     Foreground="{StaticResource TextPrimaryBrush}"
                     FontFamily="{StaticResource FontDisplay}"
                     FontSize="19" FontWeight="Bold"/>
          <TextBlock Text="Fill in the details for your game"
                     Foreground="{StaticResource TextSecondaryBrush}"
                     FontSize="12" Margin="0,3,0,0"/>
        </StackPanel>
        <Button HorizontalAlignment="Right" VerticalAlignment="Top"
                Style="{StaticResource IconButton}"
                Click="Cancel_Click" Padding="6">
          <TextBlock Text="✕" FontSize="13" Foreground="{StaticResource TextSecondaryBrush}"/>
        </Button>
      </Grid>

      <!-- Buttons bottom -->
      <StackPanel DockPanel.Dock="Bottom" Orientation="Horizontal"
                  HorizontalAlignment="Right" Margin="0,16,0,0">
        <Button Style="{StaticResource SecondaryButton}"
                Content="Cancel" Padding="16,9" Margin="0,0,10,0"
                Click="Cancel_Click"/>
        <Button Style="{StaticResource PrimaryButton}"
                Content="Add Game" Padding="22,9"
                Click="Add_Click"/>
      </StackPanel>

      <!-- Form -->
      <ScrollViewer VerticalScrollBarVisibility="Auto"
                    Style="{StaticResource ElstractScrollViewer}">
        <StackPanel>

          <!-- Game name -->
          <TextBlock Text="Game Name *" Foreground="{StaticResource TextMutedBrush}"
                     FontSize="11" Margin="0,0,0,5"/>
          <TextBox x:Name="NameInput"
                   Style="{StaticResource ElstractTextBox}"
                   FontSize="14" Margin="0,0,0,14"/>

          <!-- Description -->
          <TextBlock Text="Description" Foreground="{StaticResource TextMutedBrush}"
                     FontSize="11" Margin="0,0,0,5"/>
          <TextBox x:Name="DescInput"
                   Style="{StaticResource ElstractTextBox}"
                   FontSize="13" Height="72"
                   TextWrapping="Wrap"
                   AcceptsReturn="True"
                   VerticalScrollBarVisibility="Auto"
                   Margin="0,0,0,14"/>

          <!-- Icon + Background side by side -->
          <Grid Margin="0,0,0,14">
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="*"/>
              <ColumnDefinition Width="12"/>
              <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>

            <!-- Icon -->
            <StackPanel Grid.Column="0">
              <TextBlock Text="Icon / Cover Image"
                         Foreground="{StaticResource TextMutedBrush}"
                         FontSize="11" Margin="0,0,0,5"/>
              <Border x:Name="IconPreview"
                      Height="80" CornerRadius="8"
                      Background="{StaticResource PinkGradientSubtle}"
                      BorderBrush="{StaticResource BorderSubtleBrush}"
                      BorderThickness="1" Cursor="Hand"
                      MouseLeftButtonDown="PickIcon_Click">
                <Grid>
                  <Image x:Name="IconImg" Stretch="UniformToFill"/>
                  <StackPanel VerticalAlignment="Center" HorizontalAlignment="Center"
                              x:Name="IconPlaceholder">
                    <TextBlock Text="🖼" FontSize="20" HorizontalAlignment="Center"/>
                    <TextBlock Text="Click to choose" FontSize="10"
                               Foreground="{StaticResource TextMutedBrush}"
                               HorizontalAlignment="Center" Margin="0,4,0,0"/>
                  </StackPanel>
                </Grid>
              </Border>
            </StackPanel>

            <!-- Background -->
            <StackPanel Grid.Column="2">
              <TextBlock Text="Background / Banner"
                         Foreground="{StaticResource TextMutedBrush}"
                         FontSize="11" Margin="0,0,0,5"/>
              <Border x:Name="BgPreview"
                      Height="80" CornerRadius="8"
                      Background="{StaticResource PinkGradientSubtle}"
                      BorderBrush="{StaticResource BorderSubtleBrush}"
                      BorderThickness="1" Cursor="Hand"
                      MouseLeftButtonDown="PickBackground_Click">
                <Grid>
                  <Image x:Name="BgImg" Stretch="UniformToFill"/>
                  <StackPanel VerticalAlignment="Center" HorizontalAlignment="Center"
                              x:Name="BgPlaceholder">
                    <TextBlock Text="🌄" FontSize="20" HorizontalAlignment="Center"/>
                    <TextBlock Text="Click to choose" FontSize="10"
                               Foreground="{StaticResource TextMutedBrush}"
                               HorizontalAlignment="Center" Margin="0,4,0,0"/>
                  </StackPanel>
                </Grid>
              </Border>
            </StackPanel>
          </Grid>

          <!-- Developer / Publisher -->
          <Grid Margin="0,0,0,14">
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="*"/>
              <ColumnDefinition Width="12"/>
              <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
            <StackPanel Grid.Column="0">
              <TextBlock Text="Developer" Foreground="{StaticResource TextMutedBrush}"
                         FontSize="11" Margin="0,0,0,5"/>
              <TextBox x:Name="DevInput" Style="{StaticResource ElstractTextBox}" FontSize="13"/>
            </StackPanel>
            <StackPanel Grid.Column="2">
              <TextBlock Text="Genre" Foreground="{StaticResource TextMutedBrush}"
                         FontSize="11" Margin="0,0,0,5"/>
              <TextBox x:Name="GenreInput" Style="{StaticResource ElstractTextBox}" FontSize="13"/>
            </StackPanel>
          </Grid>

        </StackPanel>
      </ScrollViewer>
    </DockPanel>
  </Border>
</Window>
