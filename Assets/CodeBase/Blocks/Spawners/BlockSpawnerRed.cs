using System.Collections.Generic;
using InventorySystem;
using Storage.Items;
using UnityEditor;
using UnityEngine;

namespace Blocks.Spawners {
    public class BlockSpawnerRed : BlockSpawner {
        protected Inventory inventory;

        private float timer;

        private void Start() {
            inventory = GetComponent<InventoryHold>().inventory;
        }

        public  void Update() {
            Spawner();
        }

        public override void Spawner() {
            timer += Time.deltaTime;
            if (inventory.items.Count < inventory.Capacity)
                if (timer > spawnBlockTime) {
                    var itemBlock = _itemFactory.CreateItemBlock(_blocktype);
                    inventory.AddItem(itemBlock);
                    timer = 0;
                    BlockSortPositions.PositionBlocks(itemBlock.gameObject, spawnPoint.transform, 1.0f);
                }
        }
    }
}