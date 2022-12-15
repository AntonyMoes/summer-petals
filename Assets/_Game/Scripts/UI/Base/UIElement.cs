using System;
using GeneralUtils;
using UnityEngine;
using Event = GeneralUtils.Event;

namespace _Game.Scripts.UI.Base {
    public class UIElement : MonoBehaviour {
        public EState State => _state.Value;
        private readonly UpdatedValue<EState> _state = new UpdatedValue<EState>(EState.Hided);

        protected virtual bool ClearOnHide => true;

        public readonly Event OnShowing;
        public readonly Event OnShown;
        public readonly Event OnHiding;
        public readonly Event OnHided;

        public UIElement() {
            OnShowing = new Event(out var onShowing);
            OnShown = new Event(out var onShown);
            OnHiding = new Event(out var onHiding);
            OnHided = new Event(out var onHided);

            _state.Subscribe(state => {
                if (state == EState.Showing) onShowing();
            });

            _state.Subscribe(state => {
                if (state == EState.Shown) onShown();
            });

            _state.Subscribe(state => {
                if (state == EState.Hiding) onHiding();
            });

            _state.Subscribe(state => {
                if (state == EState.Hided) onHided();
            });
        }

        private void Awake() {
            if (gameObject.activeSelf && _state.Value == EState.Hided) {
                _state.Value = EState.Shown;
            }

            Init();
        }

        protected virtual void Init() { }

        public void Show(Action onDone = null) {
            if (State == EState.Shown) {
                onDone?.Invoke();
                return;
            }

            if (State == EState.Showing) {
                _state.WaitFor(EState.Shown, onDone);
                return;
            }

            // TODO what to do if Hiding?

            _state.Value = EState.Showing;
            gameObject.SetActive(true);

            PerformShow(() => {
                _state.Value = EState.Shown;
                onDone?.Invoke();
            });
        }

        protected virtual void PerformShow(Action onDone = null) {
            onDone?.Invoke();
        }

        public void Hide(Action onDone = null) {
            if (State == EState.Hided) {
                onDone?.Invoke();
                return;
            }

            if (State == EState.Hiding) {
                _state.WaitFor(EState.Hided, onDone);
                return;
            }

            // TODO what to do if Showing?

            _state.Value = EState.Hiding;

            PerformHide(() => {
                gameObject.SetActive(false);
                _state.Value = EState.Hided;

                if (ClearOnHide) {
                    Clear();
                }

                onDone?.Invoke();
            });
        }

        protected virtual void PerformHide(Action onDone = null) {
            onDone?.Invoke();
        }

        public virtual void Clear() { }

        public enum EState {
            Showing,
            Shown,
            Hiding,
            Hided
        }
    }
}