using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Objects;
using GeneralUtils;
using UnityEngine;

namespace _Game.Scripts {
    public class Bouquets : SingletonBehaviour<Bouquets> {
        [SerializeField] private Bouquet[] _bouquets;
        [SerializeField] private GameObject _shitBouquet;

        public GameObject InstantiateBouquet(Flower[] flowers) {
            if (flowers.Length < 2) {
                return null;
            }

            var flowerDict = flowers
                .GroupBy(flower => flower.Type)
                .ToDictionary(g => g.Key, g => g.Count());

            var prefab = _shitBouquet;
            foreach (var bouquet in _bouquets) {
                var correctRecipe = bouquet.Recipe.OrderBy(kvp => kvp.Key)
                    .SequenceEqual(flowerDict.OrderBy(kvp => kvp.Key));

                if (flowerDict.DictEqual(bouquet.Recipe)) {
                    prefab = bouquet.gameObject;
                    break;
                }
            }

            foreach (var flower in flowers) {
                Destroy(flower.gameObject);
            }

            return Instantiate(prefab, Layers.Instance.ObjectLayer);
        }
    }
}