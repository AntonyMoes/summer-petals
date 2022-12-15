using System;
using _Game.Scripts.UI.Base;
using UnityEngine;

namespace _Game.Scripts.UI {
    public class MainMenu : UIElement {
        [SerializeField] private SimpleButton _startButton;
        [SerializeField] private SimpleButton _quitButton;
        
        private Action _onStart;
        private Action _onQuit;

        protected override void Init() {
            _startButton.OnClick.Subscribe(OnStart);
            _quitButton.OnClick.Subscribe(OnQuit);
        }

        public void Load(Action onStart, Action onQuit) {
            _onStart = onStart;
            _onQuit = onQuit;
        }

        private void OnStart(SimpleButton _) {
            _onStart?.Invoke();
        }

        private void OnQuit(SimpleButton _) {
            _onQuit?.Invoke();
        }

        public override void Clear() {
            _onStart = null;
            _onQuit = null;
        }
    }
}