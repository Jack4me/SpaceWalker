using System.Linq;
using Blocks;
using UnityEngine;

namespace InventorySystem {
    public class InventoryPickUpBlueFabric : InventoryPickUp {
        protected override void ProcessPickUp(Collider other){
            // Проверяем, есть ли компонент Player у объекта, с которым взаимодействуем
            if (other.TryGetComponent(out Player player))
                // Если есть Player, проверяем наличие компонента InventoryHold у него
                if (player.TryGetComponent(out InventoryHold inventoryHold)){
                    // Создаем список для хранения предметов с компонентом RedBlock
                    var redBlockItems = inventoryHold.inventory.items
                        .Where(item => item.GetComponent<RedBlock>() != null)
                        .ToList();
                    // Фильтрация по наличию RedBlock
                    // Добавляем все найденные предметы с RedBlock в список redBlockPickUpFromPlayer
                    redBlockPickUpFromPlayer.AddRange(redBlockItems);
                    // Удаляем найденные предметы с RedBlock из инвентаря 
                    redBlockItems.ForEach(item => inventoryHold.inventory.items.Remove(item));
                    DestoyGameObject(redBlockItems);
                }
        }
    }
}