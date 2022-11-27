using GeneralUtils;
using System;
using UnityEngine;

namespace _Game.Scripts.DragAndDrop {
    public class DragComponent : MonoBehaviour {
        private Drag _drag;
        private Action _stopDrag;
        private readonly RaycastHit2D[] _hits = new RaycastHit2D[5];

        private readonly Action<DragComponent, DropComponent> _onDrop;
        public readonly Event<DragComponent, DropComponent> OnDrop;

        public static Vector3 MouseWorldPoint => Camera.main.ScreenToWorldPoint(Input.mousePosition);

        public DragComponent() {
            OnDrop = new Event<DragComponent, DropComponent>(out _onDrop);
        }

        public void SpawnDragged(Drag drag) {
            RegisterDrag(drag);
        }

        private void RegisterDrag(Drag drag) {
            _drag = drag;
            _drag.SetPositionSetter(SetPosition);
            _drag.OnDrop.Subscribe(OnDragStop);
        }

        private void OnMouseDrag() {
            if (_drag == null) {
                RegisterDrag(new Drag(() => MouseWorldPoint, out _stopDrag));
            }

            _drag.ProcessFrame();
        }

        private void SetPosition(Vector3 worldPoint) {
            worldPoint.z = transform.position.z;
            transform.position = worldPoint;
        }
    
        private void OnMouseUp() {
            _stopDrag?.Invoke();
            _stopDrag = null;
            _drag = null;
        }

        private void OnDragStop() {
            var hitCount = Physics2D.RaycastNonAlloc(MouseWorldPoint, Vector2.zero, _hits);
            for (var i = 0; i < hitCount; i++) {
                if (_hits[i].transform.TryGetComponent(out DropComponent drop)) {
                    _onDrop(this, drop);
                    drop.OnDragEnd(this);
                    break;
                }
            }
        }
    }
}