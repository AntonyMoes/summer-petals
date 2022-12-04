using System;
using _Game.Scripts.DragAndDrop;
using GeneralUtils;
using UnityEngine;

namespace _Game.Scripts.Objects.Appliances {
    public class OrderTable : MonoBehaviour {
        [SerializeField] private DropComponent _dropComponent;

        public readonly Action<Bouquet> _onDropBouquet;
        public readonly Event<Bouquet> OnDropBouquet;
        public OrderTable() {
            OnDropBouquet = new Event<Bouquet>(out _onDropBouquet);
        }

        private void Awake() {
            _dropComponent.OnDrop.Subscribe(OnDrop);
        }

        private void OnDrop(DragComponent dragComponent, DropComponent _) {
            if (!dragComponent.gameObject.TryGetComponent(out Bouquet bouquet)) {
                return;
            }

            _onDropBouquet?.Invoke(bouquet);
        }
    }
}