using _Game.Scripts.Data;
using _Game.Scripts.UI;
using UnityEngine;

namespace _Game.Scripts {
    public class App : MonoBehaviour {
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private LevelController _levelController;

        private void Start() {
            ShowMainMenu();
        }

        private void ShowMainMenu() {
            _mainMenu.Load(StartLevel, Quit);
            _mainMenu.Show();
        }

        private void StartLevel() {
            _mainMenu.Hide(() => {
                _levelController.StartLevel(DataStorage.Instance.Orders, ShowMainMenu);
            });
        }

        private void Quit() {
            Application.Quit();
        }
    }
}