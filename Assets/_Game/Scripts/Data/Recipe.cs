using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Objects.Plants;
using GeneralUtils;

namespace _Game.Scripts.Data {
    public class Recipe {
        private readonly Dictionary<string, int> _anyPlants;
        private readonly Dictionary<FullType, int> _concretePlants;
        public Recipe(IList<RecipeItem> recipe) {
            _anyPlants = recipe
                .Where(IsAnyPlant)
                .GroupBy(item => item.type)
                .ToDictionary(group => group.Key, group => group.Sum(item => item.count));
            _concretePlants = recipe
                .Where(item => !IsAnyPlant(item))
                .GroupBy(item => new FullType(item))
                .ToDictionary(group => group.Key, group => group.Sum(item => item.count));
        }

        public bool CanBeMadeFrom(IEnumerable<Plant> plants) {
            var anyPlants = _anyPlants.Copy();
            var concretePlants = _concretePlants.Copy();

            foreach (var plant in plants) {
                var fullType = new FullType(plant);
                if (concretePlants.GetValue(fullType, 0) > 0) {
                    concretePlants[fullType]--;
                    continue;
                }

                if (anyPlants.GetValue(plant.Type, 0) > 0) {
                    anyPlants[plant.Type]--;
                    continue;
                }

                return false;
            }

            return anyPlants.Values.Sum() + concretePlants.Values.Sum() == 0;
        }

        private static bool IsAnyPlant(RecipeItem item) => string.IsNullOrEmpty(item.subtype);

        private struct FullType {
            public readonly string Type;
            public readonly string SubType;

            public FullType(RecipeItem item) {
                Type = item.type;
                SubType = item.subtype;
            }

            public FullType(Plant plant) {
                Type = plant.Type;
                SubType = plant.SubType;
            }
        }
    }
}