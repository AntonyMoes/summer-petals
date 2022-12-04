using System.Linq;
using _Game.Scripts.DragAndDrop;
using UnityEngine;

namespace _Game.Scripts.Objects.Tools {
    public class Clippers : MonoBehaviour {
        [SerializeField] private DragComponent _dragComponent;

        private void TryClipStem() {
            var clippable = _dragComponent.GetDraggedOver<IClippable>().FirstOrDefault();
            clippable?.ApplyClippers();
        }

        private void Update() {
            if (!_dragComponent.Dragging.Value) {
                return;
            }

            if (Input.GetMouseButtonDown(1)) {
                TryClipStem();
            }
        }
    }
}