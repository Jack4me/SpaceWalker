using System.Collections.Generic;
using Storage.Items;
using Unity.VisualScripting.Dependencies.NCalc;

namespace InventorySystem {
    public class Inventory {
        public int Capacity{ get; }

        public List<Item> items{ get; }

        public Inventory(int capacity){
            Capacity = capacity;
            items = new List<Item>();
        }

        public bool AddItem(Item item){
            if (items.Count < Capacity){
                items.Add(item);
                
                return true;
            }
            return false;
        }

        public void Clear(){
            items.Clear();
        }

        public void RemoveItem(Item item){
            items.Remove(item);
        }
    }
}