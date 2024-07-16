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

        private void Update() {
            // for (var i = 0; i < inventory.items.Count; i++) {
            //     var position = spawnPoint.transform.position;
            //     inventory.items[i].transform.position = new Vector3(position.x,
            //         position.y + i * shiftBetweenBlocks, position.z);
            // }

            //сделать событие вмето постоянного обновления
            // UpdateItemPositions();
        }

        // private void OnTriggerEnter(Collider other) {
        //     ProcessPickUp(other);
        // }

        public void AddItemToStorage(Item item) {
            Assert.IsNotNull(item);
            inventory.AddItem(item);
            item.transform.SetParent(spawnPoint.transform);
        }

        private void UpdateItemPositions() {
            for (int i = 0; i < inventory.items.Count; i++) {
                Vector3 position = spawnPoint.transform.position;
                inventory.items[i].transform.position =
                    new Vector3(position.x, i * OffsetBlocks, position.z);
            }
        }

        // protected override void ProcessPickUp(Collider other) {
        //     if (_hero is null)
        //         if (other.TryGetComponent(out Hero player))
        //             _hero ??= player;
        //     if (_hero is null)
        //         return;
        //     if (_hero.TryGetComponent(out InventoryHold storageP))
        //         for (var i = 0; i < inventory.items.Count; i++) {
        //             storageP.AddItemToStorage(inventory.items[i]);
        //
        //         }
        //     print("PLayer");
        //     inventory.Clear();
        //     // не обновляет никакую позицию, проверь почему и удали нахуй если нужна
        //     UpdateItemPositions();
        // }
    }
}