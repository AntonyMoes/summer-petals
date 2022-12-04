using System;
using _Game.Scripts.Data;
using _Game.Scripts.DragAndDrop;
using _Game.Scripts.Objects.Plants;
using UnityEngine;

namespace _Game.Scripts.Objects.Appliances {
    public class FlowerBin : MonoBehaviour {
        [SerializeField] private Flower _flowerPrefab;

        private Action _stopDrag;

        private void OnMouseDown() {
            var flower = Instantiate(_flowerPrefab, Layers.Instance.ObjectLayer);

            var drag = new Drag(() => DragComponent.MouseWorldPoint, out _stopDrag);
            flower.SpawnDragged(drag);
        }

        private void OnMouseUp() {
            _stopDrag();
            _stopDrag = null;
        }
    }
}