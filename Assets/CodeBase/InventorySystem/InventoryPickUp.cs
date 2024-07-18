using System.Collections.Generic;
using Storage.Items;
using UnityEngine;

namespace InventorySystem {
    public abstract class InventoryPickUp : MonoBehaviour {
      

        private void OnTriggerStay(Collider other){
            ProcessPickUp(other);
        }

        protected abstract void ProcessPickUp(Collider other);

        
    }
}