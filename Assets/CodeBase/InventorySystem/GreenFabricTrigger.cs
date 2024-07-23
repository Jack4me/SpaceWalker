using System;
using System.Collections.Generic;
using System.Linq;
using Blocks;
using HeroSpace;
using Storage.Items;
using UnityEngine;

namespace InventorySystem {
    public class GreenFabricTrigger : InventoryPickUp {
        private InventoryHold _inventoryHold;

        private void Awake() {
            _inventoryHold = GetComponent<InventoryHold>();

        }

        protected override void ProcessSwapBlock(Collider other) {
            if (other.TryGetComponent(out HeroSpace.HeroTrigger player))
                if (player.TryGetComponent(out InventoryHold inventoryHero)) {
                    List<Item> redBlockItems = inventoryHero.inventory.items
                        .Where(item => item.GetComponent<RedBlock>() != null)
                        .ToList();
                    List<Item> blueBlockItems = inventoryHero.inventory.items
                        .Where(item => item.GetComponent<BlueBlock>() != null)
                        .ToList();
                    
                    _inventoryHold.blueBlockPickUpFromPlayer.AddRange(blueBlockItems);
                    _inventoryHold.redBlockHolder.AddRange(redBlockItems);
                    
                    
                    redBlockItems.ForEach(itemToRemove =>
                    {
                        inventoryHero.inventory.items.Remove(itemToRemove);
                        Destroy(itemToRemove.gameObject);
                    });
                    blueBlockItems.ForEach(itemToRemove =>
                    {
                        inventoryHero.inventory.items.Remove(itemToRemove);
                        Destroy(itemToRemove.gameObject);
                    });
                }
        }

        protected override void StopProcessGiveBlock(Collider other) {
            if (other.TryGetComponent(out HeroPickUp player)) {
                player.canTake = false;
            }
        }

        // protected override void ProcessPickUp(Collider other) {
        //     if (other.TryGetComponent(out HeroTrigger player))
        //         if (player.TryGetComponent(out InventoryHold inventoryHero)) {
        //             List<Item> redBlockItems = inventoryHero.inventory.items
        //                 .Where(item => item.GetComponent<RedBlock>() != null)
        //                 .ToList();
        //            
        //             _inventoryHold.redBlockPickUpFromPlayer.AddRange(redBlockItems);
        //           
        //           
        //             foreach (Item itemToRemove in redBlockItems) {
        //                 inventoryHero.inventory.items.Remove(itemToRemove);
        //                 Destroy(itemToRemove.gameObject);
        //                 
        //             }
        //             
        //         }
        // }
    }
}