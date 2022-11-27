using _Game.Scripts.DragAndDrop;
using UnityEngine;

namespace _Game.Scripts.Objects {
    public class Flower : MonoBehaviour {
        [SerializeField] private DragComponent _dragComponent;

        public void SpawnDragged(Drag drag) {
            _dragComponent.SpawnDragged(drag);
        }
    }
}