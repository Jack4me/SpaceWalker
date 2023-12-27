using Storage;
using Storage.Items.Factory;
using UnityEngine;

namespace Blocks.Spawners {
    public abstract class BlockSpawner : MonoBehaviour {
        [SerializeField] protected ItemFactory _itemFactory;
        [SerializeField] protected Blocktype _blocktype;
        [SerializeField] protected float spawnBlockTime = 10f;

        public abstract void Update();

        public abstract void Spawner();
    }
}