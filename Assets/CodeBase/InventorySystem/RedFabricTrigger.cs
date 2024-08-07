using System.Collections.Generic;
using System.Linq;
using Blocks;
using Blocks.Spawners;
using HeroSpace;
using Storage.Items;
using UnityEngine;

namespace InventorySystem {
    public class RedFabricTrigger : InventoryPickUp {
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
                Collider currentCollider = GetComponent<Collider>();
                if (currentCollider != null) {
                    if (player.holdPlayer.inventory.items.Count >= 10) {
                        return;
                    }

                    item = _inventoryHold.inventory.items;
                    player.PickBlocks(currentCollider);
                }
            }
        }
    }
}