using System;
using System.Collections;
using System.Collections.Generic;
using Blocks;
using InventorySystem;
using UnityEngine;

public class PositionBlockUptade : MonoBehaviour
{
    private InventoryHold holder;

    private void Awake() {
        holder = GetComponent<InventoryHold>();
    }

    private void Update() {
       // BlockSortPositions.PositionBlocks();
    }
}
