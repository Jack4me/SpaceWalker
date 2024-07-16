using System.Collections.Generic;
using Storage.Items;
using UnityEngine;

namespace InventorySystem {
    public abstract class InventoryPickUp : MonoBehaviour {
        // public List<Item> redBlockPickUpFromPlayer;
        // public List<Item> blueBlockPickUpFromPlayer;
        // public List<Item> greenBlockPickUpFromPlayer;

        private void OnTriggerEnter(Collider other){
            ProcessPickUp(other);
        }

        protected abstract void ProcessPickUp(Collider other);

        
    }
}