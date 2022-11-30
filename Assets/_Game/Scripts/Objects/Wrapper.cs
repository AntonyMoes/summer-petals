using System.Linq;
using _Game.Scripts.DragAndDrop;
using UnityEngine;

namespace _Game.Scripts.Objects {
    public class Wrapper : MonoBehaviour {
        [SerializeField] private GameObject _wrappingPrefab;
        [SerializeField] private DragComponent _dragComponent;

        private void TryWrap() {
            var bouquet = _dragComponent.GetDraggedOver<Bouquet>().FirstOrDefault();
            if (bouquet == null || bouquet.HasWrapping) {
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