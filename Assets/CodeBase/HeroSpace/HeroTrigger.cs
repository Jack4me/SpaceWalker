using UnityEngine;

namespace HeroSpace {
    public class HeroTrigger : MonoBehaviour {
        private void OnTriggerEnter(Collider other){
            Debug.Log(other.name);
        }
    }
}