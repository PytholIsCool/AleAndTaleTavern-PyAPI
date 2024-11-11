using ButtonAPI.GameAPI;
using ButtonAPI.MainMenuAPI;
using MelonLoader;
using PyAPI.Main;

namespace PyAPI
{
    public static class BuildInfo {
        public const string Name = "A&T_PyAPI";
        public const string Description = "Button API for Ale & Tale";
        public const string Author = "Pythol";
        public const string Company = null;
        public const string Version = "1.2.0";
        public const string DownloadLink = null;
    }

    public class PyAPIExample : MelonMod {
        public override void OnSceneWasInitialized(int buildindex, string sceneName) {
            MelonLogger.Msg("OnSceneWasInitialized: " + buildindex.ToString() + " | " + sceneName);
            if (sceneName == "MM3") {
                MelonLogger.Msg("Main Menu scene found. Creating menus...");
                MelonCoroutines.Start(MainMenuAPIBase.Primer(MainMenus.Init));
            }
            else if (sceneName == "Playtest") {
                MelonLogger.Msg("Game scene found. Creating menus...");
                MelonCoroutines.Start(GameAPIBase.Primer(GameMenus.Init));
            }
        }
    }
}