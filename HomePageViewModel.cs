<!--
  ╔══════════════════════════════════════════════════════════╗
  ║  Elstract Launcher — Themes/Converters.xaml             ║
  ║  Registers all converters as application-level          ║
  ║  StaticResources accessible from every XAML file.       ║
  ╚══════════════════════════════════════════════════════════╝
-->
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:conv="clr-namespace:ElstractLauncher.Converters">

  <conv:BoolToVisibilityConverter        x:Key="BoolToVisibilityConverter"/>
  <conv:InvertBoolToVisibilityConverter  x:Key="InvertBoolToVisibilityConverter"/>
  <conv:NotNullToVisibilityConverter     x:Key="NotNullToVisibilityConverter"/>
  <conv:NullToVisibilityConverter        x:Key="NullToVisibilityConverter"/>
  <conv:NullToWidthConverter             x:Key="NullToWidthConverter"/>
  <conv:BoolToPlayTextConverter          x:Key="BoolToPlayTextConverter"/>

</ResourceDictionary>
