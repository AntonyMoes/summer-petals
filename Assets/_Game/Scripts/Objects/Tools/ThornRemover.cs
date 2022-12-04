using System.Linq;
using _Game.Scripts.DragAndDrop;
using _Game.Scripts.Objects.Plants;
using UnityEngine;

namespace _Game.Scripts.Objects.Tools {
    public class ThornRemover : MonoBehaviour {
        [SerializeField] private DragComponent _dragComponent;

        private void TryWrap() {
            var flower = _dragComponent.GetDraggedOver<Flower>().FirstOrDefault();
            if (flower != null) {
                flower.ApplyThornRemover();
            }
        }

        private void Update() {
            if (!_dragComponent.Dragging.Value) {
                return;
            }

            if (Input.GetMouseButtonDown(1)) {
                TryWrap();
            }
        }
    }
}