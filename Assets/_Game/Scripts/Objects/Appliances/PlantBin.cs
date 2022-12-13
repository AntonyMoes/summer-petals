using System;
using _Game.Scripts.Data;
using _Game.Scripts.DragAndDrop;
using _Game.Scripts.Objects.Plants;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts.Objects.Appliances {
    public class PlantBin : MonoBehaviour {
        [FormerlySerializedAs("_flowerPrefab")] [SerializeField] private Plant _plantPrefab;

        private Action _stopDrag;

        private void OnMouseDown() {
            var plant = Instantiate(_plantPrefab, Layers.Instance.ObjectLayer);

            var drag = new Drag(() => DragComponent.MouseWorldPoint, out _stopDrag);
            plant.SpawnDragged(drag);
        }

        private void OnMouseUp() {
            _stopDrag();
            _stopDrag = null;
        }
    }
}