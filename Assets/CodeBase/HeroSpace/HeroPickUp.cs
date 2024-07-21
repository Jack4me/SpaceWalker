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
        private bool canTake = true;
        public InventoryHold holdPlayer { get; private set; }
        public InventoryHold inventoryFabricHold { get; private set; }
        private const int MaxBlocks = 10;

        private void Awake() {
            holdPlayer = GetComponent<InventoryHold>();
        }


        public void PickBlocks(Collider other) {
            if (other.TryGetComponent(out InventoryHold FabricHold)) {
                List<Item> itemsToTransfer = new List<Item>(FabricHold.inventory.items);
                canTake = true;

                if(canTake)
                StartCoroutine(AddBlocksWithDelay( FabricHold));
            }
        }

        private IEnumerator AddBlocksWithDelay( InventoryHold inventoryHold) {
            List<Item> itemsToRemove = new List<Item>(inventoryHold.inventory.items);
            foreach (Item item in itemsToRemove) {
                if (holdPlayer.inventory.items.Count <= 10) {
                    holdPlayer.inventory.items.Add(item);
                    item.transform.SetParent(spawnPoint.transform);
                    inventoryHold.inventory.items.Remove(item);
                }

              
                // _items = holdPlayer.inventory.items;

               // BlockSortPositions.PositionBlocks(item.gameObject, spawnPoint.transform, 1.0f);

                yield return new WaitForSeconds(0.5f);
            }
            //inventoryHold.inventory.Clear();
            canTake = false;
            Debug.Log("СПИСОК ОЧИСТИЛ");
         //   BlockSortPositions.RepositionExistingBlocks(spawnPoint.transform);
        }
    }
}