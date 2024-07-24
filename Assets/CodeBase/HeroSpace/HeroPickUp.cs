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
        public bool canTake = false;
        public InventoryHold holdPlayer { get; private set; }
        public InventoryHold inventoryFabricHold { get; private set; }
        private const int MaxBlocks = 10;
        private List<Item> itemsToTransfer = new List<Item>();
        private void Awake() {
            holdPlayer = GetComponent<InventoryHold>();
        }


        public void PickBlocks(Collider other) {
            if (other.TryGetComponent(out InventoryHold FabricHold)) {
               itemsToTransfer = new List<Item>(FabricHold.inventory.items);
               
                canTake = true;
               
                if (canTake) {
                    StartCoroutine(AddBlocksWithDelay(FabricHold));
                }
            }
        }

        private IEnumerator AddBlocksWithDelay(InventoryHold inventoryHold) {
            List<Item> itemsToRemove = new List<Item>(inventoryHold.inventory.items);
            foreach (Item item in itemsToRemove) {
                if (holdPlayer.inventory.items.Count < 10) {
                    if (holdPlayer.inventory.items.Contains(item)) {
                        yield break;
                    }
                    holdPlayer.inventory.items.Add(item);
                    item.transform.SetParent(spawnPoint.transform);
                    inventoryHold.inventory.items.Remove(item);
                    BlockSortPositions.PositionBlocks(item.gameObject, spawnPoint.transform, 1.0f);
                }

                _items = holdPlayer.inventory.items;


                yield return new WaitForSeconds(0.1f);
            }

            //inventoryHold.inventory.Clear();
            canTake = false;
            //   BlockSortPositions.RepositionExistingBlocks(spawnPoint.transform);
        }
    }
}