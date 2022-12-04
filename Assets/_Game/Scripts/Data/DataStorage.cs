using System;
using GeneralUtils;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace _Game.Scripts.Data {
    public class DataStorage : SingletonBehaviour<DataStorage> {
        [SerializeField] private TextAsset _orders;

        public Order[] Orders { get; private set; }

        private void Awake() {
            Orders = LoadRecords<Order>(_orders);
        }

        private static T[] LoadRecords<T>(TextAsset asset) {
            return JsonConvert.DeserializeObject<Records<T>>(asset.text)!.records;
        }

        [Serializable]
        private class Records<T> {
            public T[] records;
        }
    }
}