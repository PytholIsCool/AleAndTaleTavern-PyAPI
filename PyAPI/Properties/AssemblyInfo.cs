using System;
using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(PyAPI.BuildInfo.Description)]
[assembly: AssemblyDescription(PyAPI.BuildInfo.Description)]
[assembly: AssemblyCompany(PyAPI.BuildInfo.Company)]
[assembly: AssemblyProduct(PyAPI.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + PyAPI.BuildInfo.Author)]
[assembly: AssemblyTrademark(PyAPI.BuildInfo.Company)]
[assembly: AssemblyVersion(PyAPI.BuildInfo.Version)]
[assembly: AssemblyFileVersion(PyAPI.BuildInfo.Version)]
[assembly: MelonInfo(typeof(PyAPI.PyAPIExample), PyAPI.BuildInfo.Name, PyAPI.BuildInfo.Version, PyAPI.BuildInfo.Author, PyAPI.BuildInfo.DownloadLink)]
[assembly: MelonColor(255, 129, 80, 199)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("ScienartGames", "Ale and Tale Tavern")]