using _Game.Scripts.DragAndDrop;
using _Game.Scripts.Objects.Plants;
using UnityEngine;

namespace _Game.Scripts.Objects.Appliances {
    public class TrashBin : MonoBehaviour {
        [SerializeField] private DropComponent _dropComponent;

        private void Awake() {
            _dropComponent.OnDrop.Subscribe(OnDrop);
        }

        private void OnDrop(DragComponent dragComponent, DropComponent _) {
            if (dragComponent.gameObject.TryGetComponent(out Flower _) || dragComponent.gameObject.TryGetComponent(out Bouquet _)) {
                Destroy(dragComponent.gameObject);
            }
        }
    }
}