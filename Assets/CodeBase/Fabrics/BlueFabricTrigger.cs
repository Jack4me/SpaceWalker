using System.Collections.Generic;
using System.Linq;
using Blocks;
using Blocks.Spawners;
using HeroSpace;
using InventorySystem;
using Storage.Items;
using UnityEngine;

namespace Fabrics {
    public class BlueFabricTrigger : InventoryPickUp {
        //     public List<Item> item = new List<Item>();
        //     private BlockSpawnerBlue blockSpawnerBlue;
        //     private InventoryHold _inventoryHold;
        //     
        //
        //     private void Awake() {
        //         blockSpawnerBlue = GetComponent<BlockSpawnerBlue>();
        //         _inventoryHold = GetComponent<InventoryHold>();
        //     }
        //
        //     protected override void ProcessGiveBlock(Collider other) {
        //         if (other.TryGetComponent(out HeroPickUp player)) {
        //             GetBlocks(player);
        //             PickupBlocks(player);
        //         }
        //     }
        //
        //     protected override void StopProcessGiveBlock(Collider other) {
        //         if (other.TryGetComponent(out HeroPickUp player)) {
        //             player.canTake = false;
        //         }
        //     }
        //
        //     private void PickupBlocks(HeroPickUp player) {
        //         Collider currentCollider = GetComponent<Collider>();
        //         if (currentCollider != null) {
        //             player.PickBlocks(currentCollider);
        //         }
        //     }
        //
        //     private void GetBlocks(HeroPickUp player) {
        //         if (player.TryGetComponent(out InventoryHold inventoryHero)) {
        //             List<Item> redBlockItems = new List<Item>(inventoryHero.inventory.items) 
        //                 .Where(item => item.GetComponent<RedBlock>() != null)
        //                 .ToList();
        //             // Фильтрация по наличию RedBlock
        //             // Добавляем все найденные предметы с RedBlock в список redBlockPickUpFromPlayer
        //
        //             _inventoryHold.redBlockPickUpFromPlayer.AddRange(redBlockItems);
        //             foreach (Item itemToRemove in redBlockItems) {
        //                 inventoryHero.inventory.items.Remove(itemToRemove);
        //                 Destroy(itemToRemove.gameObject);
        //             }
        //
        //             blockSpawnerBlue.StartSpawning();
        //         }
        //     }
        // }
                                                            
        public List<Item> item = new List<Item>();
        private BlockSpawnerBlue blockSpawnerBlue;
        private InventoryHold _inventoryHold;
        
        private void Awake() {
            blockSpawnerBlue = GetComponent<BlockSpawnerBlue>();
            _inventoryHold = GetComponent<InventoryHold>();
        }

        protected override void StopProcessGiveBlock(Collider other) {
            if (other.TryGetComponent(out HeroPickUp player)) {
                player.canTake = false;
            }
        }

        protected override void ProcessSwapBlock(Collider other) {
            if (other.TryGetComponent(out HeroPickUp player)) {
                SelectedRedBlocks(player);
                Collider currentFabricCollider = GetComponent<Collider>();
                PlayerPickBlocks(currentFabricCollider, player);
                
            blockSpawnerBlue.StartSpawning();
            }
        }

        public List<Item> SelectedRedBlocks(HeroPickUp player) {
            if (player.TryGetComponent(out InventoryHold inventoryHero)) {
                List<Item> redBlockItems = new List<Item>(inventoryHero.inventory.items)
                    .Where(item => item.GetComponent<RedBlock>() != null)
                    .ToList();
                foreach (var item in redBlockItems) {
                    _inventoryHold.redBlockHolder.Add(item);
                    inventoryHero.inventory.items.Remove(item);
                    Destroy(item.gameObject);
                                
                }
                return redBlockItems;
            }

            return null;
        }

        private void PlayerPickBlocks(Collider currentFabricCollider, HeroPickUp player) {
            if (currentFabricCollider != null) {
                if (player.holdPlayer.inventory.items.Count > 10) {
                    return;
                }

                item = _inventoryHold.inventory.items;
                player.PickBlocks(currentFabricCollider);
            }
        }
    }
}