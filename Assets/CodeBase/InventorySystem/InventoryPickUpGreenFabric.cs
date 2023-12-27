using System.Linq;
using Blocks;
using UnityEngine;

namespace InventorySystem {
    public class InventoryPickUpGreenFabric : InventoryPickUp {
        protected override void ProcessPickUp(Collider other){
            if (other.TryGetComponent(out Player player))
                if (player.TryGetComponent(out InventoryHold inventoryHold)){
                    var redBlockItems = inventoryHold.inventory.items
                        .Where(item => item.GetComponent<RedBlock>() != null)
                        .ToList();
                    var blueBlockItems = inventoryHold.inventory.items
                        .Where(item => item.GetComponent<BlueBlock>() != null)
                        .ToList();
                    blueBlockPickUpFromPlayer.AddRange(blueBlockItems);
                    blueBlockItems.ForEach(item => inventoryHold.inventory.items.Remove(item));
                    redBlockPickUpFromPlayer.AddRange(redBlockItems);
                    redBlockItems.ForEach(item => inventoryHold.inventory.items.Remove(item));
                    DestoyGameObject(redBlockItems);
                    DestoyGameObject(blueBlockItems);
                }
        }
    }
}