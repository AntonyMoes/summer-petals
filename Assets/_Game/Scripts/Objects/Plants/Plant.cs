using _Game.Scripts.DragAndDrop;
using UnityEngine;

namespace _Game.Scripts.Objects.Plants {
    public class Plant  : MonoBehaviour {
        [SerializeField] private DragComponent _dragComponent;
        [SerializeField] private string _type;
        [SerializeField] private string _subType;

        public string Type => _type;
        public string SubType => _subType;
        public virtual bool Ready => true;

        public void SpawnDragged(Drag drag) {
            _dragComponent.SpawnDragged(drag);
        }
    }
}