using System;
using System.Collections.Generic;
using System.Linq;
using Blocks;
using Blocks.Spawners;
using HeroSpace;
using Storage.Items;
using UnityEngine;

namespace InventorySystem {
    public class InventoryPickUpBlueFabric : InventoryPickUp {
        public List<Item> item = new List<Item>();
        private BlockSpawnerBlue blockSpawnerBlue;
        private InventoryHold _inventoryHold;

        private void Awake() {
            blockSpawnerBlue = GetComponent<BlockSpawnerBlue>();
            _inventoryHold = GetComponent<InventoryHold>();
        }

        protected override void ProcessPickUp(Collider other) {
            if (other.TryGetComponent(out HeroPickUp player))
                if (player.TryGetComponent(out InventoryHold inventoryHero)) {
                    List<Item> redBlockItems = inventoryHero.inventory.items
                        .Where(item => item.GetComponent<RedBlock>() != null)
                        .ToList();
                    // Фильтрация по наличию RedBlock
                    // Добавляем все найденные предметы с RedBlock в список redBlockPickUpFromPlayer

                    _inventoryHold.redBlockPickUpFromPlayer.AddRange(redBlockItems);
                    foreach (Item itemToRemove in redBlockItems) {
                        inventoryHero.inventory.items.Remove(itemToRemove);
                        Destroy(itemToRemove.gameObject);
                    }
                    blockSpawnerBlue.StartSpawning();
                }
        }
    }
}