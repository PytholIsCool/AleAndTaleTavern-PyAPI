using ButtonAPI.Uni.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyAPI.Main.NestedPagesTest {
    public class Game {
        public static Page Pg;
        public static void Init() {
            Pg = new Page();
            var Pg2 = new Page();

            var tab = Pg.AddTab("Test");
            tab.AddButton("NestedPage2", "open", () => {
                Pg2.OpenMenu();
            });

            var tab2 = Pg2.AddTab("Test");
            tab2.AddButton("wtf", "this finally works", () => {

            });
        }
    }
}
