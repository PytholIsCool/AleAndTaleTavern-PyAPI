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
        private static Transform currentHome;
        private static Transform currentParent;
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
            (Back.onClick = new Button.ButtonClickedEvent()).AddListener(new UnityEngine.Events.UnityAction(() => OnBack()));

            Tabs = new List<Tab>();
        }
        public void OpenMenu() {
            this.gameObject.SetActive(true);
            currentHome.gameObject.SetActive(false);
            FmodManager.Instance.Play(SoundEvent.Page);
        }
        private void OnBack() {
            this.gameObject.SetActive(false);
            currentHome.gameObject.SetActive(true);
            FmodManager.Instance.Play(SoundEvent.UIButton);
        }
        public Tab AddTab(string text) => new Tab(this, text);
        private static Transform RefSetMain() {
            currentParent = MainMenuAPIBase.MainMenu;
            currentHome = MainMenuAPIBase.Home;
            return MainMenuAPIBase.Settings;
        }
        private static Transform RefSetGame() {
            currentParent = GameAPIBase.Settings.parent;
            currentHome = GameAPIBase.Home;
            return GameAPIBase.Settings;
        }
    }
}
