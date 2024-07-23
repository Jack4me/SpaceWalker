﻿using System;
using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using Storage.Items;
using UnityEngine;

namespace Blocks.Spawners {
    public class BlockSpawnerBlue : BlockSpawner {
        //     [SerializeField] private InventoryPickUp _inventoryPickUp;
        //     private Inventory inventory;
        //     private float timer = 0;
        //     private List<Item> redBlockPickUpFromPlayer;
        //     private bool isSpawning
        //         ;
        //
        //     private void Awake() {
        //         //если делаю в awake, то вылетает нулл
        //         inventory = GetComponent<InventoryHold>().inventory;
        //          redBlockPickUpFromPlayer = GetComponent<InventoryHold>().redBlockPickUpFromPlayer;
        //     }
        //
        //
        //     public void StartSpawning() {
        //         if (!isSpawning && redBlockPickUpFromPlayer.Count > 0) {
        //             StartCoroutine(SpawnerCoroutine());
        //         }
        //     }
        //     
        //     
        //
        //     private IEnumerator SpawnerCoroutine() {
        //       
        //         isSpawning = true; // Устанавливаем флаг в true, чтобы предотвратить повторный запуск
        //
        //         while (redBlockPickUpFromPlayer.Count > 0) {
        //             yield return new WaitForSeconds(0.5f); 
        //             Spawner();
        //         }
        //
        //         isSpawning = false; // Сбрасываем флаг после завершения спаунинга
        //     }
        //
        //     public override void Spawner() {
        //         if (redBlockPickUpFromPlayer.Count > 0) {
        //            
        //             
        //                 Item itemBlock = _itemFactory.CreateItemBlock(_blocktype);
        //                 inventory.AddItem(itemBlock); 
        //                 BlockSortPositions.PositionBlocks(itemBlock.gameObject, spawnPoint.transform, 1.0f);
        //                 int lastIndex = redBlockPickUpFromPlayer.Count - 1;
        //                 redBlockPickUpFromPlayer.RemoveAt(lastIndex);
        //         }
        //
        //     }
        // }
        protected InventoryHold holder;
        private float timer;
        private bool isSpawning;

        private void Awake() {
            holder = GetComponent<InventoryHold>();
        }

        private void Update() {

        }


        private IEnumerator SpawnerCoroutine() {
            yield return new WaitForSeconds(0.01f);
            isSpawning = true;
            while (holder.redBlockHolder.Count < holder.inventory.Capacity) {

                var itemBlock = _itemFactory.CreateItemBlock(_blocktype);
                holder.inventory.AddItem(itemBlock);
                BlockSortPositions.PositionBlocks(itemBlock.gameObject, spawnPoint.transform, 1.0f);
                yield return null;
            }

            isSpawning = false;
        }





        public override void StartSpawning() {
            if (!isSpawning && holder.inventory.items.Count < holder.inventory.items.Capacity) {
                StartCoroutine(SpawnerCoroutine());
            }
        }
    }
}