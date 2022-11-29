using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace _Game.Scripts.Objects {
    public class Bouquet : MonoBehaviour {
        [SerializeField] private RecipeItem[] _recipe;
        public Dictionary<string, int> Recipe => _recipe
            .GroupBy(item => item.type)
            .ToDictionary(g => g.Key, g => g.Sum(item => item.count));

        [Serializable]
        public struct RecipeItem {
            public string type;
            public int count;
        }
    }
}