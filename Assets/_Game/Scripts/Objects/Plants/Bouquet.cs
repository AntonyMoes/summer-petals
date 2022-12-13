using System;
using System.Linq;
using _Game.Scripts.Data;
using _Game.Scripts.Objects.Tools;
using GeneralUtils;
using UnityEngine;

namespace _Game.Scripts.Objects.Plants {
    public class Bouquet : MonoBehaviour, IClippable {
        [SerializeField] private Transform _wrappingPosition;
        [SerializeField] private string _type;
        [SerializeField] private RecipeItem[] _recipe;

        public string Type => _type;
        public readonly Lazy<Recipe> Recipe;

        public Bouquet() {
            Recipe = new Lazy<Recipe>(() => new Recipe(_recipe));
        }

        public Wrapping Wrapping { get; private set; }

        public void Wrap(Wrapping wrapping) {
            if (_wrappingPosition == null) {
                Destroy(wrapping.gameObject);
                return;
            }

            if (Wrapping != null) {
                Destroy(Wrapping.gameObject);
            }

            wrapping.transform.SetParent(_wrappingPosition, false);
            Wrapping = wrapping;
        }

        public void ApplyClippers() {
            GetComponentsInChildren<Flower>().ForEach(f => f.ClipStem());
        }

        private void Awake() {
            var rb = GetComponent<Rigidbody2D>();
            GetComponentsInChildren<Rigidbody2D>().Where(crb => crb != rb).ForEach(Destroy);
        }

        private Recipe GetRecipe() => new Recipe(_recipe);
    }
}