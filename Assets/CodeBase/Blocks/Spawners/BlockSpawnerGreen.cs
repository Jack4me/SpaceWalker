using InventorySystem;
using UnityEngine;

namespace Blocks.Spawners {
    public class BlockSpawnerGreen : BlockSpawner {
        [SerializeField] private InventoryPickUp _inventoryPickUp;
        private Inventory _inventory;
        private float timer = 0;

        private void Start(){
            //если делаю в awake, то вылетает нулл
            _inventory = GetComponent<InventoryHold>().inventory;
        }

        public override void Update(){
            Spawner();
        }

        public override void Spawner(){
            {
                while (_inventoryPickUp.redBlockPickUpFromPlayer.Count > 0 &&
                       _inventoryPickUp.blueBlockPickUpFromPlayer.Count > 0){
                    Debug.Log("CJPLFK <KJR");
                    _inventoryPickUp.redBlockPickUpFromPlayer.RemoveAt(0);
                    _inventoryPickUp.blueBlockPickUpFromPlayer.RemoveAt(0);
                    var itemBlock = _itemFactory.CreateItemBlock(_blocktype);
                    _inventory.AddItem(itemBlock);
                }
            }
        }
    }

    // public override void Spawner(){
    // if (_inventoryPickUp.redBlockPickUpFromPlayer.Count > 0) {
    //     // Проверяем, есть ли элементы в списке
    //     foreach (Item item in _inventoryPickUp.redBlockPickUpFromPlayer) {
    //         // Создаем блок для каждого предмета в списке
    //         Item itemBlock = _itemFactory.CreateItemBlock(_blocktype);
    //         inventory.AddItem(itemBlock); // Добавляем блок в инвентарь
    //
    //         // Запускаем таймер для следующего спауна блока
    //     }
    //     timer = 0;
    //
    //     _inventoryPickUp.redBlockPickUpFromPlayer.Clear(); // Очищаем весь список предметов
    // }
    //
    //  }
}