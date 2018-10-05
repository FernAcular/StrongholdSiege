﻿using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {

    public int startingMagnitude = 100;
    public GameObject unitPrefab;
    public List<ObjectOwnerState> startingStrongholds;

    private Transform source;

    void Start() {
        foreach (ObjectOwnerState strongholdInfo in startingStrongholds) {
            strongholdInfo.SetMagnitude(startingMagnitude);
        }
    }

    public void RegisterStrongholdClick(Transform selected) {
        if (source == null) {
            // If source is not yet selected, selected stronghold is the source
            source = selected;
        } else {
            ObjectOwnerState sourceInfo = source.GetComponent<ObjectOwnerState>();

            // If source is owned by a player, and not the same as target, send unit
            if (sourceInfo.player != null && source != selected) {
                SendUnit(sourceInfo, selected);
            }

            source = null;
        }
    }

    private void SendUnit(ObjectOwnerState sourceInfo, Transform selected) {
        // Create unit at source stronghold
        GameObject unit = Instantiate(unitPrefab, source.position, Quaternion.identity);

        int strongholdMagnitude = sourceInfo.GetMagnitude();
        int unitMagnitude = strongholdMagnitude / 2;

        // Only send unit if it has a magnitude
        if (unitMagnitude > 0) {
            ObjectOwnerState unitInfo = unit.GetComponent<ObjectOwnerState>();

            unitInfo.SetMagnitude(unitMagnitude);
            unitInfo.player = sourceInfo.player;
            unit.GetComponent<UnitState>().SetSource(source.gameObject);
            unit.GetComponent<Movement>().SetTarget(selected);

            sourceInfo.SetMagnitude(strongholdMagnitude - unitMagnitude);
        }
    }
}
