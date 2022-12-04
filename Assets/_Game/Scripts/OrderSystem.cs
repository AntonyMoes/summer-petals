using _Game.Scripts.Data;
using _Game.Scripts.Objects;
using _Game.Scripts.Objects.Appliances;
using TMPro;
using UnityEngine;

namespace _Game.Scripts {
    public class OrderSystem : MonoBehaviour {
        [SerializeField] private OrderTable _orderTable;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private TextMeshProUGUI _result;

        private Order _currentOrder;
        private int _currentOrderIndex;

        private void Start() {
            _result.text = "";
            StartNextOrder();
        }

        private void StartNextOrder() {
            _currentOrder = DataStorage.Instance.Orders[_currentOrderIndex];
            _description.text = _currentOrder.Description;

            _orderTable.OnDropBouquet.Subscribe(CompleteOrder);
        }

        private void CompleteOrder(Bouquet bouquet) {
            _orderTable.OnDropBouquet.Unsubscribe(CompleteOrder);

            _result.text = CheckBouquet(_currentOrder, bouquet) ? "Правильно!" : "НЕПРАВИЛЬНО!";
            Destroy(bouquet.gameObject);

            _currentOrderIndex = (_currentOrderIndex + 1) % DataStorage.Instance.Orders.Length;
            StartNextOrder();
        }

        private static bool CheckBouquet(Order order, Bouquet bouquet) {
            return order.Type == bouquet.Type && (bouquet.Wrapping == null
                ? order.Wrapping == null
                : order.Wrapping == bouquet.Wrapping.Type);
        } 
    }
}