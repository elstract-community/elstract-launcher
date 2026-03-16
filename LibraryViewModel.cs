<!--
  ╔══════════════════════════════════════════════════════════╗
  ║  Elstract Launcher — Themes/ElstractTheme.xaml          ║
  ║  Core color palette: dark backgrounds + vivid pink      ║
  ╚══════════════════════════════════════════════════════════╝
-->
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

  <!-- ── Primary palette ──────────────────────────────────────────── -->
  <Color x:Key="PinkPrimary">#FF1A7A</Color>
  <Color x:Key="PinkLight">#FF5FA3</Color>
  <Color x:Key="PinkDark">#C4004F</Color>
  <Color x:Key="PinkGlow">#FF1A7A44</Color>   <!-- semi-transparent for glows -->

  <!-- ── Background layers ─────────────────────────────────────────── -->
  <Color x:Key="BgDeep">#0D0A10</Color>        <!-- deepest background -->
  <Color x:Key="BgBase">#130F18</Color>        <!-- main window bg      -->
  <Color x:Key="BgCard">#1C1625</Color>        <!-- cards / panels      -->
  <Color x:Key="BgCardHover">#241D2F</Color>   <!-- card on hover       -->
  <Color x:Key="BgSidebar">#160F1E</Color>     <!-- left sidebar        -->
  <Color x:Key="BgInput">#221A2E</Color>       <!-- inputs              -->
  <Color x:Key="BgOverlay">#0D0A10CC</Color>   <!-- modal overlay       -->

  <!-- ── Text colors ───────────────────────────────────────────────── -->
  <Color x:Key="TextPrimary">#F0ECF8</Color>
  <Color x:Key="TextSecondary">#A895C4</Color>
  <Color x:Key="TextMuted">#5E4D7A</Color>
  <Color x:Key="TextAccent">#FF1A7A</Color>

  <!-- ── Border colors ─────────────────────────────────────────────── -->
  <Color x:Key="BorderSubtle">#2D2040</Color>
  <Color x:Key="BorderActive">#FF1A7A88</Color>

  <!-- ── Status colors ─────────────────────────────────────────────── -->
  <Color x:Key="StatusGreen">#39D98A</Color>
  <Color x:Key="StatusRed">#FF4757</Color>
  <Color x:Key="StatusYellow">#FFC312</Color>

  <!-- ── SolidColorBrushes ─────────────────────────────────────────── -->
  <SolidColorBrush x:Key="PinkPrimaryBrush"    Color="{StaticResource PinkPrimary}"/>
  <SolidColorBrush x:Key="PinkLightBrush"      Color="{StaticResource PinkLight}"/>
  <SolidColorBrush x:Key="PinkDarkBrush"       Color="{StaticResource PinkDark}"/>

  <SolidColorBrush x:Key="BgDeepBrush"         Color="{StaticResource BgDeep}"/>
  <SolidColorBrush x:Key="BgBaseBrush"         Color="{StaticResource BgBase}"/>
  <SolidColorBrush x:Key="BgCardBrush"         Color="{StaticResource BgCard}"/>
  <SolidColorBrush x:Key="BgCardHoverBrush"    Color="{StaticResource BgCardHover}"/>
  <SolidColorBrush x:Key="BgSidebarBrush"      Color="{StaticResource BgSidebar}"/>
  <SolidColorBrush x:Key="BgInputBrush"        Color="{StaticResource BgInput}"/>

  <SolidColorBrush x:Key="TextPrimaryBrush"    Color="{StaticResource TextPrimary}"/>
  <SolidColorBrush x:Key="TextSecondaryBrush"  Color="{StaticResource TextSecondary}"/>
  <SolidColorBrush x:Key="TextMutedBrush"      Color="{StaticResource TextMuted}"/>
  <SolidColorBrush x:Key="TextAccentBrush"     Color="{StaticResource TextAccent}"/>

  <SolidColorBrush x:Key="BorderSubtleBrush"   Color="{StaticResource BorderSubtle}"/>
  <SolidColorBrush x:Key="BorderActiveBrush"   Color="{StaticResource BorderActive}"/>

  <SolidColorBrush x:Key="StatusGreenBrush"    Color="{StaticResource StatusGreen}"/>
  <SolidColorBrush x:Key="StatusRedBrush"      Color="{StaticResource StatusRed}"/>
  <SolidColorBrush x:Key="StatusYellowBrush"   Color="{StaticResource StatusYellow}"/>

  <!-- ── Gradient brushes ──────────────────────────────────────────── -->
  <LinearGradientBrush x:Key="PinkGradient" StartPoint="0,0" EndPoint="1,1">
    <GradientStop Color="#FF1A7A" Offset="0"/>
    <GradientStop Color="#C4004F" Offset="1"/>
  </LinearGradientBrush>

  <LinearGradientBrush x:Key="PinkGradientSubtle" StartPoint="0,0" EndPoint="1,1">
    <GradientStop Color="#FF1A7A22" Offset="0"/>
    <GradientStop Color="#C4004F11" Offset="1"/>
  </LinearGradientBrush>

  <LinearGradientBrush x:Key="CardGradient" StartPoint="0,0" EndPoint="0,1">
    <GradientStop Color="#1C1625" Offset="0"/>
    <GradientStop Color="#160F1E" Offset="1"/>
  </LinearGradientBrush>

  <LinearGradientBrush x:Key="SidebarGradient" StartPoint="0,0" EndPoint="0,1">
    <GradientStop Color="#160F1E" Offset="0"/>
    <GradientStop Color="#0D0A10" Offset="1"/>
  </LinearGradientBrush>

  <!-- ── Drop shadow effects ───────────────────────────────────────── -->
  <DropShadowEffect x:Key="PinkGlowEffect"
                    Color="#FF1A7A" BlurRadius="20" ShadowDepth="0" Opacity="0.6"/>
  <DropShadowEffect x:Key="CardShadow"
                    Color="#000000" BlurRadius="12" ShadowDepth="2" Opacity="0.5"/>
  <DropShadowEffect x:Key="ButtonGlow"
                    Color="#FF1A7A" BlurRadius="14" ShadowDepth="0" Opacity="0.4"/>

  <!-- ── Corner radii ───────────────────────────────────────────────── -->
  <CornerRadius x:Key="RadiusSm">6</CornerRadius>
  <CornerRadius x:Key="RadiusMd">10</CornerRadius>
  <CornerRadius x:Key="RadiusLg">16</CornerRadius>
  <CornerRadius x:Key="RadiusXl">20</CornerRadius>

  <!-- ── Typography ─────────────────────────────────────────────────── -->
  <FontFamily x:Key="FontPrimary">Segoe UI, Arial</FontFamily>
  <FontFamily x:Key="FontDisplay">Segoe UI Semibold, Arial Bold</FontFamily>
  <FontFamily x:Key="FontMono">Consolas, Courier New</FontFamily>

</ResourceDictionary>
