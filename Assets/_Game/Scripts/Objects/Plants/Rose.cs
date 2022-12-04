using UnityEngine;

namespace _Game.Scripts.Objects.Plants {
    public class Rose : Flower {
        [SerializeField] private GameObject _thorns;

        public override bool Ready => !_thorns.activeSelf;

        public override void ApplyThornRemover() {
            _thorns.SetActive(false);
        }
    }
}