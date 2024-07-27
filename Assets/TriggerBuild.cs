using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Blocks;
using Blocks.Spawners;
using HeroSpace;
using InventorySystem;
using Storage.Items;
using UnityEngine;

public class TriggerBuild : MonoBehaviour {
    public List<Item> item = new List<Item>();
    private InventoryHold _inventoryHold;
    [SerializeField] private int needToBuyBlocks;
    private List<Item> countBlock = new List<Item>();
    private void Awake() {
        _inventoryHold = GetComponent<InventoryHold>();
    }


    protected void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out HeroPickUp player)) {
            SelectedRedBlocks(player);
        }
    }
    public void SelectedRedBlocks(HeroPickUp player)
    {
        if (player.TryGetComponent(out InventoryHold inventoryHero))
        {
            List<Item> redBlockItems = new List<Item>(inventoryHero.inventory.items)
                .Where(item => item.GetComponent<RedBlock>() != null)
                .ToList();

            // Проверяем, сколько блоков уже есть в countBlock
            int currentBlockCount = countBlock.Count;
            int blocksNeeded = 10 - currentBlockCount;

            // Если уже есть 10 или более блоков, метод не должен выполнять ничего
            if (blocksNeeded <= 0)
            {
                Debug.Log("Already have 10 or more blocks");
                return;
            }

            // Перемещаем блоки из инвентаря игрока, но не больше, чем нужно
            foreach (var item in redBlockItems)
            {
                if (currentBlockCount >= 10)
                {
                    break;
                }

                countBlock.Add(item);
                inventoryHero.inventory.items.Remove(item);
                Destroy(item.gameObject);
                currentBlockCount++;
                Debug.Log(currentBlockCount + " count");
            }
        }
    }
    // public void SelectedRedBlocks(HeroPickUp player) {
    //     if (player.TryGetComponent(out InventoryHold inventoryHero)) {
    //         List<Item> redBlockItems = new List<Item>(inventoryHero.inventory.items)
    //             .Where(item => item.GetComponent<RedBlock>() != null)
    //             .ToList();
    //         int count = 0;
    //        
    //             foreach (var item in redBlockItems) {
    //                 countBlock.Add(item);
    //                 inventoryHero.inventory.items.Remove(item);
    //                 Destroy(item.gameObject);
    //                 Debug.Log(count + "count");
    //                 
    //             }
    //     }
    // }
}