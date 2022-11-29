using _Game.Scripts.DragAndDrop;
using UnityEngine;

namespace _Game.Scripts.Objects {
    public class Flower : MonoBehaviour {
        [SerializeField] private DragComponent _dragComponent;

        [SerializeField] private string _type;
        public string Type => _type;

        public void SpawnDragged(Drag drag) {
            _dragComponent.SpawnDragged(drag);
        }
    }
}