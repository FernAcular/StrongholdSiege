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

        if (strongholdInfo.player == unitInfo.player) {
            // Reinforcements arrived!
            strongholdInfo.magnitude += unitInfo.magnitude;
        } else {
            // Stronghold is being attacked!
            strongholdInfo.magnitude -= unitInfo.magnitude;

            // This stronghold is lost to the other player
            if (strongholdInfo.magnitude < 0) {
                strongholdInfo.player = unitInfo.player;
                strongholdInfo.magnitude *= -1;
                strongholdInfo.UpdateColor();
            }
        }

        //Remove Target Outline Color
        strongholdInfo.rend.material.shader = Shader.Find("Standard");

        // Remove unit from scene
        Destroy(unit.gameObject);
    }
}
