using ButtonAPI;
using ButtonAPI.GameAPI;
using ButtonAPI.MainMenuAPI;
using ButtonAPI.Types;
using ButtonAPI.Uni;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace PyAPI.ButtonAPI.Uni.Main {
    public class Page : PyPage {
        public static Page Instance;

        private static Transform currentHome;
        private static Transform currentParent;
        public Tab CurrentTab { get; set; }
        //private GameMenu.State GamePageState { get; set; }
        //private MainMenu.State MainPageState { get; set; }
        public int OpenCount { get; private set; }
        public Page() {
            Transform currentRef = SceneManager.GetActiveScene().name == "MM3" ? RefSetMain() : RefSetGame();

            (transform = (gameObject = Object.Instantiate(currentRef, currentParent).gameObject).transform).name = $"PyPage_{Guid.NewGuid()}";

            Contents = transform.Find("BG");
            transform.DestroyChildrenExcept(Contents);
            (TabParent = Contents.Find("Tab_Panel")).DestroyChildren();

            Contents.DestroyChildrenExcept(new List<Transform> {
                Contents.Find("gpHints_Info"),
                //Contents.Find("Button Apply"),
                Contents.Find("Button Back"),
                Contents.Find("Tab_Panel"),
                Contents.Find("Tab_Line"),
                Contents.Find("gp")
            });
            Contents.Find("gpHints_Info").gameObject.SetActive(false);
            Contents.Find("gp").gameObject.SetActive(false);

            (Back = Contents.Find("Button Back").GetComponent<Button>()).onClick.RemoveAllListeners();
            (Back.onClick = new Button.ButtonClickedEvent()).AddListener(delegate { OnBack(); });

            Tabs = new List<Tab>();
        }
        public void OpenMenu() {
            OpenCount = 0;
            this.gameObject.SetActive(true);
            currentHome.gameObject.SetActive(false);
            FmodManager.Instance.Play(SoundEvent.Page);
            if (Tabs.Count != -1 && OpenCount == 0) {
                Tabs[0].OpenContents(true);
                OpenCount++;
            }
            Instance = this;

            if (SceneManager.GetActiveScene().name == "MM3")
                MainMenuAPIBase.MainMenuCompnt.SetState(MainMenu.State.Settings);
            else
                GameAPIBase.GameMenuCompnt.SetState(GameMenu.State.MenuSettings);
        }
        public void OnBack(bool silent = false) {
            this.gameObject.SetActive(false);
            currentHome.gameObject.SetActive(true);
            if (silent == false)
                FmodManager.Instance.Play(SoundEvent.UIButton);
            Instance = null;

            if (SceneManager.GetActiveScene().name == "MM3")
                MainMenuAPIBase.MainMenuCompnt.SetState(MainMenu.State.Home);
            else
                GameAPIBase.GameMenuCompnt.ShowMenuHome();
        }
        public Tab AddTab(string text) => new Tab(this, text);
        private Transform RefSetMain() {
            currentParent = MainMenuAPIBase.MainMenu;
            currentHome = MainMenuAPIBase.Home;
            return MainMenuAPIBase.Settings;
        }
        private Transform RefSetGame() {
            currentParent = GameAPIBase.Settings.parent;
            currentHome = GameAPIBase.Home;
            return GameAPIBase.Settings;
        }
        /// <summary>
        /// PLACE THIS IN YOUR MOD'S ONUPDATE OVERRIDE
        /// </summary>
        public static void PageOnEscapeHandler() {
            if (Input.GetKeyDown(KeyCode.Escape) && Instance != null) {
                Instance.OnBack(true);
            }
        }
    }
}