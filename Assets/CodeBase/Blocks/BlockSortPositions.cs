using System.Collections.Generic;
using Storage.Items;
using UnityEngine;

namespace Blocks {
    public static class BlockSortPositions {
        public const float DefaultBlockHeight = 1.0f;
        private static int offset = 1;


        public static void PositionBlocks(GameObject item, Transform spawnPoint,
            float blockHeight = DefaultBlockHeight) {
            // int siblingIndex = spawnPoint.childCount;
            //
            // if (siblingIndex == 0) {
            //     // Если spawnPoint пуст, позиционируем первый блок на позицию spawnPoint
            //     item.transform.position = spawnPoint.position;
            // } else {
            //     // Иначе, позиционируем блок на блок выше предыдущего
            //     Transform lastBlock = spawnPoint.GetChild(siblingIndex - 1);
            //     Vector3 newPosition = lastBlock.position + Vector3.up * blockHeight;
            //     item.transform.position = newPosition;
            // }
            // // Устанавливаем родительский объект для текущего блока
            // ChangeParentObject(item, spawnPoint);
            // RepositionExistingBlocks(spawnPoint);
            Vector3 newPosition;
            if (spawnPoint.childCount == 0) {
                // Если spawnPoint пуст, позиционируем первый блок на позицию spawnPoint
                newPosition = spawnPoint.position;
            }
            else {
                // Иначе, позиционируем блок на блок выше предыдущего
                Transform lastBlock = GetLastActiveBlock(spawnPoint);
                newPosition = lastBlock != null ? lastBlock.position + Vector3.up * blockHeight : spawnPoint.position;
            }

            item.transform.position = newPosition;
            ChangeParentObject(item, spawnPoint);
           // Debug.Log($"Positioned block at {newPosition}");
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

        public static void RepositionExistingBlocks(Transform spawnPoint, float blockHeight = DefaultBlockHeight) {
            List<Transform> existingBlocks = new List<Transform>();

            foreach (Transform child in spawnPoint) {
                if (child != null && child.gameObject.activeSelf) {
                    existingBlocks.Add(child);
                }
            }

            for (int i = 0; i < existingBlocks.Count; i++) {
                existingBlocks[i].position = spawnPoint.position + Vector3.up * i * blockHeight;
                Debug.Log($"Repositioned block to {existingBlocks[i].position}");
            }
        }

        // public static void RepositionExistingBlocks(Transform spawnPoint) {
        //     List<Transform> existingBlocks = new List<Transform>();
        //     foreach (Transform child in spawnPoint.transform) {
        //         if (child != null && child.gameObject.activeSelf) {
        //             existingBlocks.Add(child);
        //         }
        //     }
        //
        //     for (int i = 0; i < existingBlocks.Count; i++) {
        //         existingBlocks[i].position = spawnPoint.transform.position +
        //                                      Vector3.up * i * BlockSortPositions.DefaultBlockHeight;
        //     }
        // }
    }
}