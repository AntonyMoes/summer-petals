using System.Linq;
using _Game.Scripts.Objects.Plants;
using GeneralUtils;
using UnityEngine;

namespace _Game.Scripts.Data {
    public class Bouquets : SingletonBehaviour<Bouquets> {
        [SerializeField] private Bouquet[] _bouquets;
        [SerializeField] private GameObject _shitBouquet;

        public GameObject InstantiateBouquet(Plant[] plants) {
            if (plants.Length < 2) {
                return null;
            }

            var plantDict = plants
                .GroupBy(flower => flower.Type)
                .ToDictionary(g => g.Key, g => g.Count());

            var prefab = _shitBouquet; 
            foreach (var bouquet in _bouquets) { 
                if (bouquet.Recipe.Value.CanBeMadeFrom(plants)) {
                    prefab = bouquet.gameObject;
                    break;
                }
            }

            foreach (var plant in plants) {
                Destroy(plant.gameObject);
            }

            return Instantiate(prefab, Layers.Instance.ObjectLayer);
        }
    }
}