using UnityEngine;

namespace Storage.Items {
    [CreateAssetMenu(fileName = "ItemData", menuName = "Item Data")]
    public class ItemPrototypeSO : ScriptableObject {
        public Transform prefab;
    }
}