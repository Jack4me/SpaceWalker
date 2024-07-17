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
        private const int MaxBlocks = 10; // Максимальное количество блоков
        private void Awake() {
            hold = GetComponent<InventoryHold>();
        }

        

        public void PickBlocks(Collider other) {
            if (other.TryGetComponent(out InventoryHold inventoryFabricHold)) {
                List<Item> itemsToTransfer = new List<Item>(inventoryFabricHold.inventory.items);

                // Очищаем инвентарь фабрики сразу
                inventoryFabricHold.inventory.Clear();

                // Запускаем корутину для добавления блоков с задержкой
                StartCoroutine(AddBlocksWithDelay(itemsToTransfer));
            }
        }

        private IEnumerator AddBlocksWithDelay(List<Item> itemsToTransfer) {
            foreach (Item item in itemsToTransfer) {
                if (hold.inventory.items.Count >= MaxBlocks) {
                    Debug.Log("Player can't carry more than " + MaxBlocks + " blocks.");
                    yield break;
                }
                hold.inventory.items.Add(item);
                _items = hold.inventory.items;

                BlockSortPositions.PositionBlocks(item.gameObject, spawnPoint.transform, 1.0f);

                // Ждем одну секунду перед добавлением следующего блока
                yield return new WaitForSeconds(0.5f);
            }

            // Перепозиционируем существующие блоки после добавления всех новых блоков
            BlockSortPositions.RepositionExistingBlocks(spawnPoint.transform);
        }
    }
}