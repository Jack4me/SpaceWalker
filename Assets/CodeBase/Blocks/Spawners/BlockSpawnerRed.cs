using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using Storage.Items;
using UnityEngine;

namespace Blocks.Spawners {
    public class BlockSpawnerRed : BlockSpawner {
        protected Inventory inventory;
        private float timer;
        private bool isSpawning; // Флаг для отслеживания состояния спауна

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
            isSpawning = true; // Устанавливаем флаг в true, чтобы начать спавн
            while (inventory.items.Count < inventory.Capacity) {
                timer += Time.deltaTime;
                if (timer > spawnBlockTime) {
                    var itemBlock = _itemFactory.CreateItemBlock(_blocktype);
                    inventory.AddItem(itemBlock);
                    BlockSortPositions.PositionBlocks(itemBlock.gameObject, spawnPoint.transform, 1.0f);
                    timer = 0;
                    Debug.Log(inventory.Capacity + "CAPACITY");
                }

                yield return null;
            }

            isSpawning = false; // Устанавливаем флаг в false после завершения спавна
        }

        public override void Spawner() {
            // Спавн теперь контролируется через корутину
        }
    }
}