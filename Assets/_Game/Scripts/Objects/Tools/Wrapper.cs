using System.Linq;
using _Game.Scripts.DragAndDrop;
using _Game.Scripts.Objects.Plants;
using UnityEngine;

namespace _Game.Scripts.Objects.Tools {
    public class Wrapper : MonoBehaviour {
        [SerializeField] private Wrapping _wrappingPrefab;
        [SerializeField] private DragComponent _dragComponent;

        private void TryWrap() {
            var bouquet = _dragComponent.GetDraggedOver<Bouquet>().FirstOrDefault();
            if (bouquet == null || bouquet.Wrapping != null) {
                return;
            }

            var wrapping = Instantiate(_wrappingPrefab);
            bouquet.Wrap(wrapping);
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