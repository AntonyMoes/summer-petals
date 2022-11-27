using GeneralUtils;
using UnityEngine;

namespace _Game.Scripts {
    public class App : SingletonBehaviour<App> {
        [SerializeField] private Transform _objectLayer;
        public Transform ObjectLayer => _objectLayer;
    }
}
