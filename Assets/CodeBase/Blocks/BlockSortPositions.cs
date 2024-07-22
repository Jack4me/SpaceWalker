using System.Collections.Generic;
using Storage.Items;
using UnityEngine;

namespace Blocks {
    public static class BlockSortPositions {
        public const float DefaultBlockHeight = 1.0f;


        public static void SortPlayerBLocks(List<Item> itemsPlayerList) {
            
        }
        
        
        
        public static void PositionBlocks(GameObject item, Transform spawnPoint, float blockHeight = DefaultBlockHeight) {
            Vector3 newPosition = GetNewBlockPosition(spawnPoint, blockHeight);
            item.transform.position = newPosition;
            ChangeParentObject(item, spawnPoint);
            AlignBlocks(spawnPoint);
        }

        private static Vector3 GetNewBlockPosition(Transform spawnPoint, float blockHeight) {
            if (spawnPoint.childCount == 0) {
                return spawnPoint.position;
            } else {
                Transform lastBlock = GetLastActiveBlock(spawnPoint);
                return lastBlock != null ? lastBlock.position + Vector3.up * blockHeight : spawnPoint.position;
            }
        }

        public static void AlignBlocks(Transform spawnPoint, float blockHeight = DefaultBlockHeight) {
            List<Transform> existingBlocks = new List<Transform>();

            foreach (Transform child in spawnPoint) {
                if (child != null && child.gameObject.activeSelf) {
                    existingBlocks.Add(child);
                }
            }

            for (int i = 0; i < existingBlocks.Count; i++) {
                existingBlocks[i].position = spawnPoint.position + Vector3.up * i * blockHeight;
            }
        }

        private static Transform GetLastActiveBlock(Transform spawnPoint) {
            for (int i = spawnPoint.childCount - 1; i >= 0; i--) {
                if (spawnPoint.GetChild(i).gameObject.activeSelf) {
                    return spawnPoint.GetChild(i);
                }
            }
            return null;
        }

        private static void ChangeParentObject(GameObject item, Transform spawnPoint) {
            item.transform.SetParent(spawnPoint);
        }
    }
}
