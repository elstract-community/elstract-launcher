<!--
  ╔══════════════════════════════════════════════════════════╗
  ║  Elstract Launcher — Themes/ControlStyles.xaml          ║
  ║  Reusable control styles: buttons, inputs, scrollbars,  ║
  ║  list boxes, tooltips, progress bars                    ║
  ╚══════════════════════════════════════════════════════════╝
-->
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

  <!-- ════════════════════════════════════════════════════════
       PRIMARY BUTTON — pink gradient with glow on hover
       ════════════════════════════════════════════════════════ -->
  <Style x:Key="PrimaryButton" TargetType="Button">
    <Setter Property="Background"   Value="{StaticResource PinkGradient}"/>
    <Setter Property="Foreground"   Value="White"/>
    <Setter Property="FontFamily"   Value="{StaticResource FontDisplay}"/>
    <Setter Property="FontSize"     Value="13"/>
    <Setter Property="FontWeight"   Value="SemiBold"/>
    <Setter Property="Padding"      Value="20,10"/>
    <Setter Property="Cursor"       Value="Hand"/>
    <Setter Property="BorderThickness" Value="0"/>
    <Setter Property="Template">
      <Setter.Value>
        <ControlTemplate TargetType="Button">
          <Border x:Name="Root"
                  Background="{TemplateBinding Background}"
                  CornerRadius="8"
                  Padding="{TemplateBinding Padding}">
            <Border.Effect>
              <DropShadowEffect x:Name="Glow" Color="#FF1A7A"
                                BlurRadius="0" ShadowDepth="0" Opacity="0"/>
            </Border.Effect>
            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
          </Border>
          <ControlTemplate.Triggers>
            <Trigger Property="IsMouseOver" Value="True">
              <Trigger.EnterActions>
                <BeginStoryboard>
                  <Storyboard>
                    <DoubleAnimation Storyboard.TargetName="Glow"
                                     Storyboard.TargetProperty="BlurRadius"
                                     To="18" Duration="0:0:0.2"/>
                    <DoubleAnimation Storyboard.TargetName="Glow"
                                     Storyboard.TargetProperty="Opacity"
                                     To="0.7" Duration="0:0:0.2"/>
                  </Storyboard>
                </BeginStoryboard>
              </Trigger.EnterActions>
              <Trigger.ExitActions>
                <BeginStoryboard>
                  <Storyboard>
                    <DoubleAnimation Storyboard.TargetName="Glow"
                                     Storyboard.TargetProperty="BlurRadius"
                                     To="0" Duration="0:0:0.2"/>
                    <DoubleAnimation Storyboard.TargetName="Glow"
                                     Storyboard.TargetProperty="Opacity"
                                     To="0" Duration="0:0:0.2"/>
                  </Storyboard>
                </BeginStoryboard>
              </Trigger.ExitActions>
            </Trigger>
            <Trigger Property="IsPressed" Value="True">
              <Setter TargetName="Root" Property="Opacity" Value="0.85"/>
            </Trigger>
            <Trigger Property="IsEnabled" Value="False">
              <Setter Property="Opacity" Value="0.4"/>
            </Trigger>
          </ControlTemplate.Triggers>
        </ControlTemplate>
      </Setter.Value>
    </Setter>
  </Style>

  <!-- ════════════════════════════════════════════════════════
       SECONDARY BUTTON — outlined border, no fill
       ════════════════════════════════════════════════════════ -->
  <Style x:Key="SecondaryButton" TargetType="Button">
    <Setter Property="Background"       Value="Transparent"/>
    <Setter Property="Foreground"       Value="{StaticResource PinkLightBrush}"/>
    <Setter Property="BorderBrush"      Value="{StaticResource PinkPrimaryBrush}"/>
    <Setter Property="BorderThickness"  Value="1"/>
    <Setter Property="FontFamily"       Value="{StaticResource FontDisplay}"/>
    <Setter Property="FontSize"         Value="13"/>
    <Setter Property="Padding"          Value="18,9"/>
    <Setter Property="Cursor"           Value="Hand"/>
    <Setter Property="Template">
      <Setter.Value>
        <ControlTemplate TargetType="Button">
          <Border x:Name="Root"
                  Background="{TemplateBinding Background}"
                  BorderBrush="{TemplateBinding BorderBrush}"
                  BorderThickness="{TemplateBinding BorderThickness}"
                  CornerRadius="8"
                  Padding="{TemplateBinding Padding}">
            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
          </Border>
          <ControlTemplate.Triggers>
            <Trigger Property="IsMouseOver" Value="True">
              <Setter TargetName="Root" Property="Background" Value="#FF1A7A22"/>
            </Trigger>
            <Trigger Property="IsPressed" Value="True">
              <Setter TargetName="Root" Property="Background" Value="#FF1A7A44"/>
            </Trigger>
          </ControlTemplate.Triggers>
        </ControlTemplate>
      </Setter.Value>
    </Setter>
  </Style>

  <!-- ════════════════════════════════════════════════════════
       ICON BUTTON — transparent, icon only, subtle hover
       ════════════════════════════════════════════════════════ -->
  <Style x:Key="IconButton" TargetType="Button">
    <Setter Property="Background"    Value="Transparent"/>
    <Setter Property="Foreground"    Value="{StaticResource TextSecondaryBrush}"/>
    <Setter Property="BorderThickness" Value="0"/>
    <Setter Property="Padding"       Value="8"/>
    <Setter Property="Cursor"        Value="Hand"/>
    <Setter Property="Template">
      <Setter.Value>
        <ControlTemplate TargetType="Button">
          <Border x:Name="Root" Background="{TemplateBinding Background}"
                  CornerRadius="6" Padding="{TemplateBinding Padding}">
            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
          </Border>
          <ControlTemplate.Triggers>
            <Trigger Property="IsMouseOver" Value="True">
              <Setter TargetName="Root" Property="Background" Value="#FF1A7A22"/>
              <Setter Property="Foreground" Value="{StaticResource PinkLightBrush}"/>
            </Trigger>
            <Trigger Property="IsPressed" Value="True">
              <Setter TargetName="Root" Property="Background" Value="#FF1A7A44"/>
            </Trigger>
          </ControlTemplate.Triggers>
        </ControlTemplate>
      </Setter.Value>
    </Setter>
  </Style>

  <!-- ════════════════════════════════════════════════════════
       SIDEBAR NAV BUTTON — full-width, left-aligned
       ════════════════════════════════════════════════════════ -->
  <Style x:Key="NavButton" TargetType="Button">
    <Setter Property="Background"    Value="Transparent"/>
    <Setter Property="Foreground"    Value="{StaticResource TextSecondaryBrush}"/>
    <Setter Property="BorderThickness" Value="0"/>
    <Setter Property="Padding"       Value="16,12"/>
    <Setter Property="HorizontalContentAlignment" Value="Left"/>
    <Setter Property="FontFamily"    Value="{StaticResource FontPrimary}"/>
    <Setter Property="FontSize"      Value="14"/>
    <Setter Property="Cursor"        Value="Hand"/>
    <Setter Property="Template">
      <Setter.Value>
        <ControlTemplate TargetType="Button">
          <Border x:Name="Root" Background="{TemplateBinding Background}"
                  CornerRadius="8" Padding="{TemplateBinding Padding}">
            <Border x:Name="LeftBar" BorderThickness="0"
                    Padding="0">
              <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                VerticalAlignment="Center"/>
            </Border>
          </Border>
          <ControlTemplate.Triggers>
            <Trigger Property="IsMouseOver" Value="True">
              <Setter TargetName="Root" Property="Background" Value="#FF1A7A1A"/>
              <Setter Property="Foreground" Value="{StaticResource TextPrimaryBrush}"/>
            </Trigger>
          </ControlTemplate.Triggers>
        </ControlTemplate>
      </Setter.Value>
    </Setter>
  </Style>

  <!-- ════════════════════════════════════════════════════════
       TEXT INPUT
       ════════════════════════════════════════════════════════ -->
  <Style x:Key="ElstractTextBox" TargetType="TextBox">
    <Setter Property="Background"       Value="{StaticResource BgInputBrush}"/>
    <Setter Property="Foreground"       Value="{StaticResource TextPrimaryBrush}"/>
    <Setter Property="CaretBrush"       Value="{StaticResource PinkPrimaryBrush}"/>
    <Setter Property="BorderBrush"      Value="{StaticResource BorderSubtleBrush}"/>
    <Setter Property="BorderThickness"  Value="1"/>
    <Setter Property="Padding"          Value="12,8"/>
    <Setter Property="FontFamily"       Value="{StaticResource FontPrimary}"/>
    <Setter Property="FontSize"         Value="13"/>
    <Setter Property="Template">
      <Setter.Value>
        <ControlTemplate TargetType="TextBox">
          <Border x:Name="Root"
                  Background="{TemplateBinding Background}"
                  BorderBrush="{TemplateBinding BorderBrush}"
                  BorderThickness="{TemplateBinding BorderThickness}"
                  CornerRadius="8">
            <ScrollViewer x:Name="PART_ContentHost"
                          Padding="{TemplateBinding Padding}"
                          VerticalAlignment="Center"/>
          </Border>
          <ControlTemplate.Triggers>
            <Trigger Property="IsFocused" Value="True">
              <Setter TargetName="Root" Property="BorderBrush"
                      Value="{StaticResource PinkPrimaryBrush}"/>
            </Trigger>
          </ControlTemplate.Triggers>
        </ControlTemplate>
      </Setter.Value>
    </Setter>
  </Style>

  <!-- ════════════════════════════════════════════════════════
       SCROLLBAR — thin, pink accent
       ════════════════════════════════════════════════════════ -->
  <Style x:Key="ElstractScrollBar" TargetType="ScrollBar">
    <Setter Property="Background" Value="Transparent"/>
    <Setter Property="Width" Value="6"/>
    <Setter Property="Template">
      <Setter.Value>
        <ControlTemplate TargetType="ScrollBar">
          <Grid>
            <Track x:Name="PART_Track" IsDirectionReversed="True">
              <Track.Thumb>
                <Thumb>
                  <Thumb.Template>
                    <ControlTemplate TargetType="Thumb">
                      <Border Background="{StaticResource PinkPrimaryBrush}"
                              CornerRadius="3" Opacity="0.5"/>
                    </ControlTemplate>
                  </Thumb.Template>
                </Thumb>
              </Track.Thumb>
            </Track>
          </Grid>
        </ControlTemplate>
      </Setter.Value>
    </Setter>
  </Style>

  <!-- ════════════════════════════════════════════════════════
       SCROLL VIEWER using custom scrollbar
       ════════════════════════════════════════════════════════ -->
  <Style x:Key="ElstractScrollViewer" TargetType="ScrollViewer">
    <Setter Property="Template">
      <Setter.Value>
        <ControlTemplate TargetType="ScrollViewer">
          <Grid>
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="*"/>
              <ColumnDefinition Width="Auto"/>
            </Grid.ColumnDefinitions>
            <ScrollContentPresenter Grid.Column="0"/>
            <ScrollBar Grid.Column="1"
                       x:Name="PART_VerticalScrollBar"
                       Style="{StaticResource ElstractScrollBar}"
                       Value="{TemplateBinding VerticalOffset}"
                       Maximum="{TemplateBinding ScrollableHeight}"
                       ViewportSize="{TemplateBinding ViewportHeight}"
                       Visibility="{TemplateBinding ComputedVerticalScrollBarVisibility}"/>
          </Grid>
        </ControlTemplate>
      </Setter.Value>
    </Setter>
  </Style>

  <!-- ════════════════════════════════════════════════════════
       PROGRESS BAR
       ════════════════════════════════════════════════════════ -->
  <Style x:Key="ElstractProgressBar" TargetType="ProgressBar">
    <Setter Property="Background" Value="{StaticResource BorderSubtleBrush}"/>
    <Setter Property="Foreground" Value="{StaticResource PinkPrimaryBrush}"/>
    <Setter Property="Height"     Value="4"/>
    <Setter Property="Template">
      <Setter.Value>
        <ControlTemplate TargetType="ProgressBar">
          <Border Background="{TemplateBinding Background}" CornerRadius="2">
            <Border x:Name="PART_Track">
              <Border x:Name="PART_Indicator"
                      HorizontalAlignment="Left"
                      Background="{TemplateBinding Foreground}"
                      CornerRadius="2">
                <Border.Effect>
                  <DropShadowEffect Color="#FF1A7A" BlurRadius="6" ShadowDepth="0" Opacity="0.8"/>
                </Border.Effect>
              </Border>
            </Border>
          </Border>
        </ControlTemplate>
      </Setter.Value>
    </Setter>
  </Style>

  <!-- ════════════════════════════════════════════════════════
       TOOLTIP
       ════════════════════════════════════════════════════════ -->
  <Style TargetType="ToolTip">
    <Setter Property="Background"      Value="{StaticResource BgCardBrush}"/>
    <Setter Property="Foreground"      Value="{StaticResource TextPrimaryBrush}"/>
    <Setter Property="BorderBrush"     Value="{StaticResource BorderSubtleBrush}"/>
    <Setter Property="BorderThickness" Value="1"/>
    <Setter Property="Padding"         Value="8,5"/>
    <Setter Property="FontFamily"      Value="{StaticResource FontPrimary}"/>
    <Setter Property="FontSize"        Value="12"/>
    <Setter Property="Template">
      <Setter.Value>
        <ControlTemplate TargetType="ToolTip">
          <Border Background="{TemplateBinding Background}"
                  BorderBrush="{TemplateBinding BorderBrush}"
                  BorderThickness="{TemplateBinding BorderThickness}"
                  CornerRadius="6" Padding="{TemplateBinding Padding}">
            <ContentPresenter/>
          </Border>
        </ControlTemplate>
      </Setter.Value>
    </Setter>
  </Style>

  <!-- ════════════════════════════════════════════════════════
       COMBO BOX
       ════════════════════════════════════════════════════════ -->
  <Style x:Key="ElstractComboBox" TargetType="ComboBox">
    <Setter Property="Background"      Value="{StaticResource BgInputBrush}"/>
    <Setter Property="Foreground"      Value="{StaticResource TextPrimaryBrush}"/>
    <Setter Property="BorderBrush"     Value="{StaticResource BorderSubtleBrush}"/>
    <Setter Property="BorderThickness" Value="1"/>
    <Setter Property="Padding"         Value="12,8"/>
    <Setter Property="FontFamily"      Value="{StaticResource FontPrimary}"/>
    <Setter Property="FontSize"        Value="13"/>
  </Style>

  <!-- ════════════════════════════════════════════════════════
       CHECKBOX
       ════════════════════════════════════════════════════════ -->
  <Style x:Key="ElstractCheckBox" TargetType="CheckBox">
    <Setter Property="Foreground"  Value="{StaticResource TextPrimaryBrush}"/>
    <Setter Property="FontFamily"  Value="{StaticResource FontPrimary}"/>
    <Setter Property="FontSize"    Value="13"/>
    <Setter Property="Cursor"      Value="Hand"/>
  </Style>

</ResourceDictionary>
