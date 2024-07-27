using System;
using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using Storage.Items;
using UnityEngine;

namespace Blocks.Spawners {
    public class BlockSpawnerGreen : BlockSpawner {
        private Inventory inventory;
        private float timer = 0;
        public List<Item> redBlockPickUpFromPlayer;
        public List<Item> blueBlockPickUpFromPlayer;
        private bool isSpawning;

        private void Awake() {
            //если делаю в awake, то вылетает нулл
            inventory = GetComponent<InventoryHold>().inventory;
            redBlockPickUpFromPlayer = GetComponent<InventoryHold>().redBlockHolder;
            blueBlockPickUpFromPlayer = GetComponent<InventoryHold>().blueBlockHolder;
        }

        private IEnumerator SpawnerCoroutine() {
            isSpawning = true;
            while (redBlockPickUpFromPlayer.Count > 0 && blueBlockPickUpFromPlayer.Count > 0) {
                yield return new WaitForSeconds(0.1f);

                Item itemBlock = _itemFactory.CreateItemBlock(_blocktype);
                inventory.AddItem(itemBlock);
                BlockSortPositions.PositionBlocks(itemBlock.gameObject, spawnPoint.transform, 1.0f);
                int lastIndexRed = redBlockPickUpFromPlayer.Count - 1;
                int lastIndexBlue = blueBlockPickUpFromPlayer.Count - 1;
                redBlockPickUpFromPlayer.RemoveAt(lastIndexRed);
                blueBlockPickUpFromPlayer.RemoveAt(lastIndexBlue);
                Debug.Log("yayayayaya");
            }

            isSpawning = false;
        }


        public override void StartSpawning() {
            if (!isSpawning && redBlockPickUpFromPlayer.Count > 0 && blueBlockPickUpFromPlayer.Count > 0) {
                StartCoroutine(SpawnerCoroutine());
            }


            // _inventoryPickUp.redBlockPickUpFromPlayer.Clear(); // Очищаем весь список предметов
        }
    }
}