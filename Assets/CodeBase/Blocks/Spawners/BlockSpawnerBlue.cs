using System.Collections;
using InventorySystem;
using UnityEngine;

namespace Blocks.Spawners {
    public class BlockSpawnerBlue : BlockSpawner {
        [SerializeField] private InventoryPickUp _inventoryPickUp;
        private Inventory inventory;
        private float timer = 0;

        private void Start(){
            //если делаю в awake, то вылетает нулл
            inventory = GetComponent<InventoryHold>().inventory;
        }

        public override void Update(){
            StartCoroutine(SpawnerCoroutine());
        }

        private IEnumerator SpawnerCoroutine(){
            while (_inventoryPickUp.redBlockPickUpFromPlayer.Count > 0){
                yield return new WaitForSeconds(3f); // Ждем 3 секунды перед следующим вызовом
                Spawner(); // Вызываем ваш метод Spawner
            }
        }

        public override void Spawner(){
            if (_inventoryPickUp.redBlockPickUpFromPlayer.Count > 0){
                // Проверяем, есть ли элементы в списке
                foreach (var item in _inventoryPickUp.redBlockPickUpFromPlayer){
                    // Создаем блок для каждого предмета в списке
                    var itemBlock = _itemFactory.CreateItemBlock(_blocktype);
                    inventory.AddItem(itemBlock); // Добавляем блок в инвентарь
                }
                _inventoryPickUp.redBlockPickUpFromPlayer.Clear(); // Очищаем весь список предметов
            }
        }
    }
}