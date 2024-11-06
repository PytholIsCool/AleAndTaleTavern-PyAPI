using ButtonAPI.Uni;
using MelonLoader;
using PyAPI.ButtonAPI.Uni.Main;

namespace PyAPI.Main {
    internal class MainMenus {
        private static Page Pg;
        public static void Init() {
            Pg = new Page();

            var QOL = Pg.AddTab("QOL");
            QOL.AddToggle("ERP-Mode", (val) => {

            });
            QOL.AddToggle("Yes!!!!!", (val) => {

            });
            QOL.AddSlider("Freak Meter", (val) => {

            }, 10f);
            QOL.AddSelector("Freak Select").AddSetting("Freaky 1", () => {

            }).AddSetting("Freaky 2", () => {

            }).AddSetting("Freaky 3", () => {

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