using System.Collections.Generic;
using Blocks;
using InventorySystem;
using Storage.Items;
using UnityEngine;

namespace HeroSpace {
    public class HeroPickUp : MonoBehaviour {
        public List<Item> _items;
        public GameObject spawnPoint;
        private InventoryHold hold;

        private void Awake() {
            hold = GetComponent<InventoryHold>();
        }
             
        private void OnTriggerEnter(Collider other) {
            PickBlocks(other);
        }

        public void PickBlocks(Collider other) {
            if (other.TryGetComponent(out InventoryHold inventoryFabricHold)) {
                List<Item> itemsToTransfer = new List<Item>(inventoryFabricHold.inventory.items);

                foreach (Item item in itemsToTransfer) {
                    hold.inventory.items.Add(item);
                    _items = hold.inventory.items;
                    BlockSortPositions.PositionBlocks(item.gameObject, spawnPoint.transform, 1.0f);
                }

                inventoryFabricHold.inventory.Clear();
                BlockSortPositions.RepositionExistingBlocks(spawnPoint.transform);
            }
        }

        
    }
}

