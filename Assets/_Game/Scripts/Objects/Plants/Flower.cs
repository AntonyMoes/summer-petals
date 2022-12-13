using UnityEngine;

namespace _Game.Scripts.Objects.Plants {
    public class Flower : Plant {
        [SerializeField] private GameObject _additionalStem;

        public void ClipStem() {
            if (_additionalStem != null) {
                Destroy(_additionalStem);
            }
        }
    }
}