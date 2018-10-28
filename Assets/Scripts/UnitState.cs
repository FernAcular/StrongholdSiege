using UnityEngine;

public class UnitState : MonoBehaviour {

    private GameObject source;

    public void SetSource(GameObject source) {
        this.source = source;
    }

    public GameObject GetSource() {
        return source;
    }
}
