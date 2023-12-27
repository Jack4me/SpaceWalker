using System.Collections.Generic;
using Storage;
using Storage.Items;
using UnityEngine;
using UnityEngine.Assertions;

namespace InventorySystem {
    public class InventoryHold : StorageBase {
        private const int OffsetBlocks = 1;
        private const int shiftBetweenBlocks = 3;
        [SerializeField] private GameObject spawnPoint;
        [SerializeField] private List<Item> _items;
        private Player _player;
        private Vector3 nextItemPosition;
        public Inventory inventory{ get; set; } = new Inventory(10);
        
        private void Update(){
            for (var i = 0; i < inventory.items.Count; i++){
                var position = spawnPoint.transform.position;
                inventory.items[i].transform.position = new Vector3(position.x,
                    position.y + i * shiftBetweenBlocks, position.z);
            }
            //сделать событие вмето постоянного обновления
        }

        private void OnTriggerEnter(Collider other){
            ProcessPickUp(other);
        }

        public void AddItemToStorage(Item item){
            Assert.IsNotNull(item);
            inventory.AddItem(item);
        }

        private void UpdateItemPositions(){
            for (var i = 0; i < inventory.items.Count; i++){
                var position = spawnPoint.transform.position;
                inventory.items[i].transform.position =
                    new Vector3(position.x, i * OffsetBlocks, position.z);
            }
        }

        protected override void ProcessPickUp(Collider other){
            if (_player is null)
                if (other.TryGetComponent(out Player player))
                    _player ??= player;
            if (_player is null)
                return;
            if (_player.TryGetComponent(out InventoryHold storageP))
                for (var i = 0; i < inventory.items.Count; i++)
                    storageP.AddItemToStorage(inventory.items[i]);
            print("PLayer");
            inventory.Clear();
            // не обновляет никакую позицию, проверь почему и удали нахуй если нужна
            UpdateItemPositions();
        }
    }
}