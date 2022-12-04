using _Game.Scripts.DragAndDrop;
using UnityEngine;

namespace _Game.Scripts.Objects.Plants {
    public class Flower : MonoBehaviour {
        [SerializeField] private DragComponent _dragComponent;
        [SerializeField] private GameObject _additionalStem;
        [SerializeField] private string _type;

        public string Type => _type;
        public virtual bool Ready => true;

        public void SpawnDragged(Drag drag) {
            _dragComponent.SpawnDragged(drag);
        }

        public void ClipStem() {
            if (_additionalStem != null) {
                Destroy(_additionalStem);
            }
        }
    }
}