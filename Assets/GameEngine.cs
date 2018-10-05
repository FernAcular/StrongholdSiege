using UnityEngine;

public class GameEngine : MonoBehaviour {

    public GameObject unitPrefab;
    private Transform source;

	public void RegisterStrongholdClick(Transform selected) {

        ObjectOwnerState selectedInfo = selected.GetComponent<ObjectOwnerState>();

        if (source == null && selectedInfo.player!=null) {
            // If source is not yet selected, selected stronghold is the source
            source = selected;

            //Turn Source StrongHold Green
            selectedInfo.rend.material.shader = Shader.Find("Outlined/UltimateOutline");
            selectedInfo.rend.material.SetColor("_FirstOutlineColor", Color.green);
            selectedInfo.rend.material.SetColor("_SecondOutlineColor", Color.green);

        } else if(source){

            ObjectOwnerState sourceInfo = source.GetComponent<ObjectOwnerState>();

            //Turn Selected StrongHold Red
            selectedInfo.rend.material.shader = Shader.Find("Outlined/UltimateOutline");
            selectedInfo.rend.material.SetColor("_FirstOutlineColor", Color.red);
            selectedInfo.rend.material.SetColor("_SecondOutlineColor", Color.red);

            // If source is owned by a player, and not the same as target, send unit
            if (sourceInfo.player != null && source != selected) {
                SendUnit(sourceInfo, selected);
            }

            //Turn Source Back to Neutral
            sourceInfo.rend.material.shader = Shader.Find("Standard");
            
            source = null;
        }
    }

    private void SendUnit(ObjectOwnerState sourceInfo, Transform selected) {
        // Create unit at source stronghold
        GameObject unit = Instantiate(unitPrefab, source.position, Quaternion.identity);

        int strongholdMagnitude = sourceInfo.magnitude;
        int unitMagnitude = strongholdMagnitude / 2;

        // Only send unit if it has a magnitude
        if (unitMagnitude > 0) {
            ObjectOwnerState unitInfo = unit.GetComponent<ObjectOwnerState>();

            unitInfo.magnitude = unitMagnitude;
            unitInfo.player = sourceInfo.player;
            unit.GetComponent<UnitState>().SetSource(source.gameObject);
            unit.GetComponent<Movement>().SetTarget(selected);

            sourceInfo.magnitude -= unitMagnitude;
        }
    }
}
