<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net8.0-windows</TargetFramework>
    <UseWPF>true</UseWPF>
    <AssemblyName>ElstractLauncher</AssemblyName>
    <RootNamespace>ElstractLauncher</RootNamespace>
    <ApplicationManifest>app.manifest</ApplicationManifest>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
    <Version>1.0.0</Version>
    <AssemblyVersion>1.0.0.0</AssemblyVersion>
    <FileVersion>1.0.0.0</FileVersion>
    <Company>Elstract Community</Company>
    <Product>Elstract Launcher</Product>
    <Description>Open-source game launcher with Steam integration</Description>
    <Copyright>© 2025 Elstract Community. MIT License.</Copyright>
    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
  </PropertyGroup>

  <ItemGroup>
    <!-- NuGet Packages -->
    <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
    <PackageReference Include="DiscordRichPresence" Version="1.2.1.24" />
    <PackageReference Include="Microsoft.Web.WebView2" Version="1.0.2277.86" />
    <PackageReference Include="Octokit" Version="13.0.1" />
    <PackageReference Include="MaterialDesignThemes" Version="5.0.0" />
    <PackageReference Include="MaterialDesignColors" Version="3.0.0" />
  </ItemGroup>

  <ItemGroup>
    <Resource Include="Assets\**\*" />
  </ItemGroup>

</Project>
