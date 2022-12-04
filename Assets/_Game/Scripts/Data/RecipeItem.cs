using System;
using System.Collections.Generic;
using System.Linq;

namespace _Game.Scripts.Data {
    [Serializable]
    public struct RecipeItem {
        public string type;
        public int count;
    }

    public static class RecipeItemHelper {
        public static IDictionary<string, int> ToRecipe(this IEnumerable<RecipeItem> recipe) => recipe
            .GroupBy(item => item.type)
            .ToDictionary(g => g.Key, g => g.Sum(item => item.count));
    }
}