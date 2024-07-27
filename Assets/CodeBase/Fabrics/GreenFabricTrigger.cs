using System.Collections.Generic;
using System.Linq;
using Blocks;
using Blocks.Spawners;
using HeroSpace;
using InventorySystem;
using Storage.Items;
using UnityEngine;

namespace Fabrics {
    public class GreenFabricTrigger : InventoryPickUp {
        //     private InventoryHold _inventoryHold;
        //
        //     private void Awake() {
        //         _inventoryHold = GetComponent<InventoryHold>();
        //
        //     }
        //
        //     protected override void ProcessSwapBlock(Collider other) {
        //         if (other.TryGetComponent(out HeroSpace.HeroTrigger player))
        //             if (player.TryGetComponent(out InventoryHold inventoryHero)) {
        //                 List<Item> redBlockItems = inventoryHero.inventory.items
        //                     .Where(item => item.GetComponent<RedBlock>() != null)
        //                     .ToList();
        //                 List<Item> blueBlockItems = inventoryHero.inventory.items
        //                     .Where(item => item.GetComponent<BlueBlock>() != null)
        //                     .ToList();
        //                 
        //                 _inventoryHold.blueBlockPickUpFromPlayer.AddRange(blueBlockItems);
        //                 _inventoryHold.redBlockHolder.AddRange(redBlockItems);
        //                 
        //                 
        //                 redBlockItems.ForEach(itemToRemove =>
        //                 {
        //                     inventoryHero.inventory.items.Remove(itemToRemove);
        //                     Destroy(itemToRemove.gameObject);
        //                 });
        //                 blueBlockItems.ForEach(itemToRemove =>
        //                 {
        //                     inventoryHero.inventory.items.Remove(itemToRemove);
        //                     Destroy(itemToRemove.gameObject);
        //                 });
        //             }
        //     }
        //
        //     protected override void StopProcessGiveBlock(Collider other) {
        //         if (other.TryGetComponent(out HeroPickUp player)) {
        //             player.canTake = false;
        //         }
        //     }
        //
        //     // protected override void ProcessPickUp(Collider other) {
        //     //     if (other.TryGetComponent(out HeroTrigger player))
        //     //         if (player.TryGetComponent(out InventoryHold inventoryHero)) {
        //     //             List<Item> redBlockItems = inventoryHero.inventory.items
        //     //                 .Where(item => item.GetComponent<RedBlock>() != null)
        //     //                 .ToList();
        //     //            
        //     //             _inventoryHold.redBlockPickUpFromPlayer.AddRange(redBlockItems);
        //     //           
        //     //           
        //     //             foreach (Item itemToRemove in redBlockItems) {
        //     //                 inventoryHero.inventory.items.Remove(itemToRemove);
        //     //                 Destroy(itemToRemove.gameObject);
        //     //                 
        //     //             }
        //     //             
        //     //         }
        //     // }
        // }
        //public List<Item> item = new List<Item>();
        private BlockSpawnerGreen blockSpawnerGreen;
        private InventoryHold _inventoryHold;

        private void Awake() {
            blockSpawnerGreen = GetComponent<BlockSpawnerGreen>();
            _inventoryHold = GetComponent<InventoryHold>();
        }

        protected override void StopProcessGiveBlock(Collider other) {
            if (other.TryGetComponent(out HeroPickUp player)) {
                player.canTake = false;
            }
        }

        protected override void ProcessSwapBlock(Collider other) {
            if (other.TryGetComponent(out HeroPickUp player)) {
                SelectedBlocks(player);
                Collider currentFabricCollider = GetComponent<Collider>();
                PlayerPickBlocks(currentFabricCollider, player);
                blockSpawnerGreen.StartSpawning();
            }
        }

        public void SelectedBlocks(HeroPickUp player) {
            if (player.TryGetComponent(out InventoryHold inventoryHero)) {
                ProcessBlocks<BlueBlock>(inventoryHero, _inventoryHold.blueBlockHolder);
                ProcessBlocks<RedBlock>(inventoryHero, _inventoryHold.redBlockHolder);
            }
        }

        private void ProcessBlocks<T>(InventoryHold inventoryHero, List<Item> blockHolder) where T : Component {
            List<Item> blockItems = new List<Item>(inventoryHero.inventory.items)
                .Where(item => item.GetComponent<T>() != null)
                .ToList();
            foreach (var item in blockItems) {
                blockHolder.Add(item);
                inventoryHero.inventory.items.Remove(item);
                Destroy(item.gameObject);
            }
        }
        private void PlayerPickBlocks(Collider currentFabricCollider, HeroPickUp player) {
            if (currentFabricCollider != null) {
                if (player.holdPlayer.inventory.items.Count > 10) {
                    return;
                }

                player.PickBlocks(currentFabricCollider);
            }
        }
    }
}