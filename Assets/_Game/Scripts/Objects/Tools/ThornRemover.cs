using System.Linq;
using _Game.Scripts.DragAndDrop;
using UnityEngine;

namespace _Game.Scripts.Objects.Tools {
    public class ThornRemover : MonoBehaviour {
        [SerializeField] private DragComponent _dragComponent;

        private void TryRemoveThorns() {
            var flower = _dragComponent.GetDraggedOver<IThornRemovable>().FirstOrDefault();
            flower?.ApplyThornRemover();
        }

        private void Update() {
            if (!_dragComponent.Dragging.Value) {
                return;
            }

            if (Input.GetMouseButtonDown(1)) {
                TryRemoveThorns();
            }
        }
    }
}