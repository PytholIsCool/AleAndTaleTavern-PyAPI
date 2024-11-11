using ButtonAPI.Uni;
using MelonLoader;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace ButtonAPI.GameAPI {
    public class GameAPIBase {
        public static GameMenu GameMenuCompnt;

        public static Transform GameMenu, Home, Settings;

        public static Transform PanelButtonTemplate, TabTemplate, SelectorTemplate, SliderTemplate, ToggleTemplate, ButtonTemplate;
        public static bool IsReady() {
            if (SceneManager.GetActiveScene().name != "Playtest")
                return false;

            if ((GameMenu = (GameMenuCompnt = Object.FindObjectOfType<GameMenu>()).transform) == null) MelonLogger.Msg("PyAPI Fatal Error: \"GameMenu\" reference is null \nClass: GameAPIBase");
            if ((Home = GameMenu?.Find("Menu Home Screen")) == null) MelonLogger.Msg("PyAPI Error: \"Home\" reference is null \nClass: GameAPIBase");
            if ((Settings = GameMenu?.Find("AppSettingsMenu")) == null) MelonLogger.Msg("PyAPI Error: \"Settings\" reference is null \nClass: GameAPIBase");
            //Controls
            if ((PanelButtonTemplate = Home?.Find("Panel/Button Settings")) == null) MelonLogger.Msg("PyAPI Error: \"HomeButtonTemplate\" reference is null \nClass: GameAPIBase");
            if ((TabTemplate = Settings?.Find("BG/Tab_Panel/Button Video")) == null) MelonLogger.Msg("PyAPI Error: \"TabTemplate\" reference is null \nClass: GameAPIBase");
            if ((SelectorTemplate = Settings?.Find("BG/Video/Res")) == null) MelonLogger.Msg("PyAPI Error: \"SelectorTemplate\" reference is null \nClass: GameAPIBase");
            if ((SliderTemplate = Settings?.Find("BG/Video/FOV")) == null) MelonLogger.Msg("PyAPI Error: \"SliderTemplate\" reference is null \nClass: GameAPIBase");
            if ((ToggleTemplate = Settings?.Find("BG/Video/VSync")) == null) MelonLogger.Msg("PyAPI Error: \"ToggleTemplate\" reference is null \nClass: GameAPIBase");


            return true;
        }
        /// <summary>
        /// Checks to make sure all references are available.
        /// </summary>
        /// <returns></returns>
        public static IEnumerator Primer(Action onComplete = null) {
            while (!IsReady())
                yield return null;
            if (!Patches.arePatchesApplied)
                Patches.InitializePatches();

            onComplete?.Invoke();
        }
    }
}