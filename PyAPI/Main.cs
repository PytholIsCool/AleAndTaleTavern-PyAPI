using ButtonAPI.GameAPI;
using ButtonAPI.MainMenuAPI;
using MelonLoader;
using PyAPI.ButtonAPI.Uni.Main;
using PyAPI.Main;

namespace PyAPI
{
    public static class BuildInfo {
        public const string Name = "A&T_PyAPI";
        public const string Description = "Button API for Ale & Tale";
        public const string Author = "Pythol";
        public const string Company = null;
        public const string Version = "1.0.0";
        public const string DownloadLink = null;
    }

    public class PyAPIExample : MelonMod {
        public override void OnInitializeMelon() {
            
        }

        //public override void OnLateInitializeMelon() {
            
        //}

        public override void OnSceneWasLoaded(int buildindex, string sceneName) {
            MelonLogger.Msg("OnSceneWasLoaded: " + buildindex.ToString() + " | " + sceneName);
        }

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

        public override void OnSceneWasUnloaded(int buildIndex, string sceneName) {
            MelonLogger.Msg("OnSceneWasUnloaded: " + buildIndex.ToString() + " | " + sceneName);
        }

        public override void OnUpdate() {
            Page.PageOnEscapeHandler();
        }

        //public override void OnFixedUpdate() {

        //}

        //public override void OnLateUpdate() {

        //}

        //public override void OnGUI() {

        //}

        //public override void OnApplicationQuit() {

        //}

        //public override void OnPreferencesSaved() {

        //}

        //public override void OnPreferencesLoaded() {

        //}
    }
}