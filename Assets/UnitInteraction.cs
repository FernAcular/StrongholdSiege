using System;
using UnityEngine;

public class UnitInteraction : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Unit") {
            GameObject unitSource = other.gameObject.GetComponent<UnitState>().GetSource();

            if (unitSource != gameObject) {
                ComputeResult(other);
            }
        }
    }

    private void ComputeResult(Collider unit) {
        ObjectOwnerState unitInfo = unit.gameObject.GetComponent<ObjectOwnerState>();
        ObjectOwnerState strongholdInfo = GetComponent<ObjectOwnerState>();

        int newMagnitude;
        int unitMagnitude = unitInfo.GetMagnitude();
        int strongholdMagnitude = strongholdInfo.GetMagnitude();

        if (strongholdInfo.player == unitInfo.player) {
            // Reinforcements arrived!
            newMagnitude = strongholdMagnitude + unitMagnitude;
        } else {
            // Stronghold is being attacked!
            newMagnitude = strongholdMagnitude - unitMagnitude;

            // If this stronghold is lost to the other player
            if (newMagnitude < 0) {
                strongholdInfo.player = unitInfo.player;
                strongholdInfo.UpdateColor();
            }
        }

        //New Magnitude
        strongholdInfo.SetMagnitude(Math.Abs(newMagnitude));
        
        //Remove Target Outline Color
        strongholdInfo.rend.material.shader = Shader.Find("Standard");


        // Remove unit from scene
        Destroy(unit.gameObject);
    }
}
