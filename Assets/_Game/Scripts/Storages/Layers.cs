using GeneralUtils;
using UnityEngine;

namespace _Game.Scripts {
    public class Layers : SingletonBehaviour<Layers> {
        [SerializeField] private Transform _objectLayer;
        public Transform ObjectLayer => _objectLayer;

        [SerializeField] private Transform _usedToolsLayer;
        public Transform UsedToolsLayer => _usedToolsLayer;

        [SerializeField] private Transform _dragLayer;
        public Transform DragLayer => _dragLayer;
    }
}
