using System.Linq;
using _Game.Scripts.Data;
using _Game.Scripts.DragAndDrop;
using UnityEngine;

namespace _Game.Scripts.Objects.Tools {
    public class Tape : MonoBehaviour {
        [SerializeField] private TapePiece _tapePiecePrefab;
        [SerializeField] private DragComponent _dragComponent;

        private TapePiece _tapePiece;

        private void OnDragging(bool dragging) {
            if (!dragging && _tapePiece != null) {
                EndPiece();
            }
        }

        private void BeginPiece(Vector3 position) {
            _tapePiece = Instantiate(_tapePiecePrefab, Layers.Instance.UsedToolsLayer);
            _tapePiece.SetInitialPosition(position);
        }

        private void UpdatePiece(Vector3 position) {
            _tapePiece.Position = position;
        }

        private void EndPiece() {
            var plants = _tapePiece.GetCoveredPlants();
            Debug.Log(string.Join(", ", plants.Select(f => f.Type)));

            if (plants.All(f => f.Ready)) {
                var bouquet = Bouquets.Instance.InstantiateBouquet(plants);
                if (bouquet != null) {
                    bouquet.transform.position = _tapePiece.Position;
                }
            }

            Destroy(_tapePiece.gameObject);
            _tapePiece = null;
        }

        private void Awake() {
            _dragComponent.Dragging.Subscribe(OnDragging);
        }

        private void Update() {
            if (_tapePiece != null) {
                UpdatePiece(transform.position);
            }

            if (!_dragComponent.Dragging.Value) {
                return;
            }

            if (Input.GetMouseButtonDown(1)) {
                BeginPiece(transform.position);
            }

            if (Input.GetMouseButtonUp(1)) {
                EndPiece();
            }
        }
    }
}