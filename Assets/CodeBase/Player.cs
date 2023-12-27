using UnityEngine;

public class Player : MonoBehaviour {
    private void OnTriggerEnter(Collider other){
        Debug.Log(other.name);
    }
}