using UnityEngine;

namespace Storage {
    public enum Blocktype {
        Red = 0,
        Blue = 1,
        Green = 2
    }

    public abstract class StorageBase : MonoBehaviour {
        //   [SerializeField] protected Blocktype _blocktype;

        protected abstract void ProcessPickUp(Collider other);
    }
}