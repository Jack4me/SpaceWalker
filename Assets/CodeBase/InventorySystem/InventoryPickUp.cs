using System;
using System.Collections.Generic;
using Storage.Items;
using UnityEngine;

namespace InventorySystem {
    public abstract class InventoryPickUp : MonoBehaviour {
      

        private void OnTriggerEnter(Collider other){
            ProcessGiveBlock(other);
        }

        private void OnTriggerExit(Collider other) {
            StopProcessGiveBlock(other);
        }

       

        protected abstract void ProcessGiveBlock(Collider other);
        protected abstract void StopProcessGiveBlock(Collider other);

        
    }
}