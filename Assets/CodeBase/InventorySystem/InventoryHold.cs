using System;
using System.Collections.Generic;
using HeroSpace;
using Storage;
using Storage.Items;
using UnityEngine;
using UnityEngine.Assertions;

namespace InventorySystem {
    public class InventoryHold : StorageBase {
        private const int OffsetBlocks = 1;
        private const int shiftBetweenBlocks = 3;
        [SerializeField] private GameObject spawnPoint;
        private HeroTrigger _hero;
        private Vector3 nextItemPosition;
        public Inventory inventory { get; private set; }
        public List<Item> redBlockPickUpFromPlayer;
        public List<Item> blueBlockPickUpFromPlayer;
        public List<Item> greenBlockPickUpFromPlayer;
        private void Awake() {
            inventory = new Inventory(10);
        }
        
        public void AddItemToStorage(Item item) {
            Assert.IsNotNull(item);
            inventory.AddItem(item);
            item.transform.SetParent(spawnPoint.transform);
        }

    }
}