using _Game.Scripts.DragAndDrop;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts.Objects {
    public class TrashBin : MonoBehaviour {
        [FormerlySerializedAs("_drop")] [SerializeField] private DropComponent _dropComponent;

        private void Awake() {
            _dropComponent.OnDrop.Subscribe(OnDrop);
        }

        private void OnDrop(DragComponent dragComponent, DropComponent _) {
            Destroy(dragComponent.gameObject);
        }
    }
}