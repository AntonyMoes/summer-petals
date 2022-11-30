using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Game.Scripts.Objects {
    public class Bouquet : MonoBehaviour {
        [SerializeField] private Transform _wrappingPosition;
        [SerializeField] private RecipeItem[] _recipe;
        public IDictionary<string, int> Recipe => _recipe
            .GroupBy(item => item.type)
            .ToDictionary(g => g.Key, g => g.Sum(item => item.count));

        private GameObject _wrapping;
        public bool HasWrapping => _wrapping != null;

        public void Wrap(GameObject wrapping) {
            if (HasWrapping) {
                return;
            }
            
            wrapping.transform.SetParent(_wrappingPosition, false);
            _wrapping = wrapping;
        }

        [Serializable]
        public struct RecipeItem {
            public string type;
            public int count;
        }
    }
}