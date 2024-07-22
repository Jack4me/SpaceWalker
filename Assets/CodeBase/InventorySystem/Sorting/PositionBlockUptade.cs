using UnityEngine;

namespace InventorySystem.Sorting {
    public class PositionBlockUptade : MonoBehaviour
    {
        private InventoryHold holder;

        private void Awake() {
            holder = GetComponent<InventoryHold>();
        }

        private void Update() {
            // BlockSortPositions.PositionBlocks();
        }
    }
}
