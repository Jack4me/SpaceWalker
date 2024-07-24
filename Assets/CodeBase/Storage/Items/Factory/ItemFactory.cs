using System.Collections.Generic;
using System.Linq;
using Blocks;
using UnityEngine;

namespace Storage.Items.Factory {
    public class ItemFactory : MonoBehaviour {
        [SerializeField] private List<BlockData> _blockHolders;

        public Item CreateItemBlock(Blocktype blockType){
            IEnumerable<BlockData> blockHolders = _blockHolders.Where(holder => holder.Blocktype == blockType);
            IEnumerable<GameObject> gameObjects = blockHolders.Select(holder => holder.Block);
            GameObject block = gameObjects.First();
            return Instantiate(block).GetComponent<Item>();
        }
    }
}