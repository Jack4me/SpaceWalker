using System.Collections;
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
        private const int MaxBlocks = 10; 
        private void Awake() {
            hold = GetComponent<InventoryHold>();
        }

        

        public void PickBlocks(Collider other) {
            if (other.TryGetComponent(out InventoryHold inventoryFabricHold)) {
                List<Item> itemsToTransfer = new List<Item>(inventoryFabricHold.inventory.items);
                if (hold.inventory.items.Count >= MaxBlocks) {
                    Debug.Log("Player can't carry more than " + MaxBlocks + " blocks.");
                    return;
                }
                inventoryFabricHold.inventory.Clear();

                StartCoroutine(AddBlocksWithDelay(itemsToTransfer));
            }
        }

        private IEnumerator AddBlocksWithDelay(List<Item> itemsToTransfer) {
            // if (hold.inventory.items.Count >= MaxBlocks) {
            //     Debug.Log("Player can't carry more than " + MaxBlocks +  "hold.inventory.items.Count" + hold.inventory.items.Count);
            //     yield break;
            // }
            foreach (Item item in itemsToTransfer) {
                

                hold.inventory.items.Add(item);
                _items = hold.inventory.items;

                BlockSortPositions.PositionBlocks(item.gameObject, spawnPoint.transform, 1.0f);

                yield return new WaitForSeconds(0.5f);
            }

            BlockSortPositions.RepositionExistingBlocks(spawnPoint.transform);
        }
    }
}