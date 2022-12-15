using System;
using _Game.Scripts.Data;
using _Game.Scripts.Objects.Appliances;
using _Game.Scripts.Objects.Plants;
using TMPro;
using UnityEngine;

namespace _Game.Scripts {
    public class LevelController : MonoBehaviour {
        [SerializeField] private OrderTable _orderTable;
        // TODO: move to levelUI
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private TextMeshProUGUI _result;

        private Order[] _orders;
        private int _currentOrderIndex;
        private Action _onLevelEnd;

        public void StartLevel(Order[] orders, Action onLevelEnd) {
            gameObject.SetActive(true);

            _orders = orders;
            _onLevelEnd = onLevelEnd;
            _result.text = "";
            _currentOrderIndex = 0;

            StartNextOrder();
        }

        private void EndLevel() {
            gameObject.SetActive(false);

            _onLevelEnd?.Invoke();
        }

        private void StartNextOrder() {
            if (_currentOrderIndex >= _orders.Length) {
                EndLevel();
                return;
            }

            _description.text = _orders[_currentOrderIndex].Description;

            _orderTable.OnDropBouquet.Subscribe(CompleteOrder);
        }

        private void CompleteOrder(Bouquet bouquet) {
            _orderTable.OnDropBouquet.Unsubscribe(CompleteOrder);

            _result.text = CheckBouquet(_orders[_currentOrderIndex], bouquet) ? "Правильно!" : "НЕПРАВИЛЬНО!";
            Destroy(bouquet.gameObject);

            _currentOrderIndex++;
            StartNextOrder();
        }

        private static bool CheckBouquet(Order order, Bouquet bouquet) {
            return order.Type == bouquet.Type && (bouquet.Wrapping == null
                ? order.Wrapping == null
                : order.Wrapping == bouquet.Wrapping.Type);
        } 
    }
}