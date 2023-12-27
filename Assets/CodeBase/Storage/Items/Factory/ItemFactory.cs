using System.Collections.Generic;
using System.Linq;
using Blocks;
using UnityEngine;

namespace Storage.Items.Factory {
    public class ItemFactory : MonoBehaviour {
        [SerializeField] private List<BlockHolder> _blockHolders;

        public Item CreateItemBlock(Blocktype blockType){
            var blockHolders = _blockHolders.Where(holder => holder.Blocktype == blockType);
            var gameObjects = blockHolders.Select(holder => holder.Block);
            var block = gameObjects.First();
            return Instantiate(block).GetComponent<Item>();
        }
    }
}