using System;
using System.Linq;
using GeneralUtils;
using UnityEngine;

namespace _Game.Scripts.Objects {
    public class TapePiece : MonoBehaviour {
        public Vector3 Position {
            get => transform.position;
            set => UpdatePosition(value);
        }

        private readonly RaycastHit2D[] _hits = new RaycastHit2D[50];
        private Vector3 _initialPosition;

        public void SetInitialPosition(Vector3 position) {
            _initialPosition = position;
            UpdatePosition(position);
        }

        private void UpdatePosition(Vector3 position) {
            var vector = position - _initialPosition;
            var distance = vector.magnitude;
            var angle = Vector3.SignedAngle(Vector3.up, vector, Vector3.forward);
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            var t = transform;
            t.localScale = t.localScale.With(y: distance);
            t.position = (position + _initialPosition) / 2;
            t.rotation = rotation;
        }

        public Flower[] GetCoveredFlowers() {
            var hitCount = Physics2D.BoxCastNonAlloc(Position, transform.localScale, transform.rotation.eulerAngles.z, Vector2.zero, _hits);
            return _hits
                .Take(hitCount)
                .Where(h => h.transform.TryGetComponent<Flower>(out _))
                .Select(h => h.transform.GetComponent<Flower>())
                .ToArray();
        }
    }
}