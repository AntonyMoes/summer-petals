using UnityEngine;

namespace _Game.Scripts.Objects.Tools {
    public class Wrapping : MonoBehaviour {
        [SerializeField] private string _type;
        public string Type => _type;
    }
}