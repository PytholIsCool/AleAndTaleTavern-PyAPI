using ButtonAPI.Uni;
using MelonLoader;
using PyAPI.ButtonAPI.Uni.Main;

namespace PyAPI.Main {
    internal class MainMenus {
        private static Page Pg;
        public static void Init() {
            Pg = new Page();

            var QOL = Pg.AddTab("QOL");
            QOL.AddToggle("Toggle 1", (val) => {

            });
            QOL.AddToggle("Toggle 2", (val) => {

            });
            QOL.AddSlider("Slider Control", (val) => {

            }, 10f);
            QOL.AddSelector("Selector Control").AddSetting("Setting 1", () => {

            }).AddSetting("Setting 2", () => {

            }).AddSetting("Setting 3", () => {

            });
            QOL.AddButton("TestButton", "Test", () => {
                Popup.StandardPrompt("Test", () => {
                    MelonLogger.Msg("Applied");
                });
            });
            QOL.AddButton("TestButton2", "Test", () => {
                Popup.TextPrompt("TestText", (val) => {
                    MelonLogger.Msg("Input: " + val);
                });
            }).AddButton("Sup", () => {
                MelonLogger.Msg("Sup Test");
            });

            var Misc = Pg.AddTab("Misc");
            Misc.AddToggle("This is a toggle ong", (val) => {

            });
            Misc.AddSlider("This is a slider ong", (val) => {

            });

            var Ran = Pg.AddTab("Random");
            var RanSel = Ran.AddSelector("My setting is gone :(").AddSetting("Die", () => {

            });
            RanSel.RemoveSetting("Die");

            new PanelButton("ModMan", () => {
                Pg.OpenMenu();
            });
        }
    }
}