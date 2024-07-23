using System.Collections;
using InventorySystem;
using UnityEngine;

namespace Blocks.Spawners {
    public class BlockSpawnerRed : BlockSpawner {
        protected Inventory inventory;
        private float timer;
        private bool isSpawning; 

        private void Awake() {
            inventory = GetComponent<InventoryHold>().inventory;
        }

        private void Update() {
            if (!isSpawning && inventory.items.Count < inventory.Capacity) {
                StartCoroutine(SpawnerCoroutine());
            }
        }

        private IEnumerator SpawnerCoroutine() {
            yield return new WaitForSeconds(0.01f);
            isSpawning = true; 
            while (inventory.items.Count < inventory.Capacity) {
                timer += Time.deltaTime;
                if (timer > spawnBlockTime) {
                    var itemBlock = _itemFactory.CreateItemBlock(_blocktype);
                    inventory.AddItem(itemBlock);
                    BlockSortPositions.PositionBlocks(itemBlock.gameObject, spawnPoint.transform, 1.0f);
                    timer = 0;
                }

                yield return null;
            }

            isSpawning = false; 
        }

        public override void StartSpawning() {
           
        }
    }
}