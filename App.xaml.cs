<!--
  ╔══════════════════════════════════════════════════════════╗
  ║  Elstract Launcher — App.xaml                           ║
  ║  Global application resources, styles, theme colors     ║
  ╚══════════════════════════════════════════════════════════╝
-->
<Application x:Class="ElstractLauncher.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             StartupUri="Views/MainWindow.xaml">

  <Application.Resources>
    <ResourceDictionary>
      <ResourceDictionary.MergedDictionaries>
        <ResourceDictionary Source="Themes/ElstractTheme.xaml"/>
        <ResourceDictionary Source="Themes/ControlStyles.xaml"/>
        <ResourceDictionary Source="Themes/Converters.xaml"/>
      </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
  </Application.Resources>

</Application>
