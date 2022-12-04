using _Game.Scripts.Objects.Tools;
using UnityEngine;

namespace _Game.Scripts.Objects.Plants {
    public class Rose : Flower, IThornRemovable {
        [SerializeField] private GameObject _thorns;

        public override bool Ready => !_thorns.activeSelf;

        public void ApplyThornRemover() {
            _thorns.SetActive(false);
        }
    }
}