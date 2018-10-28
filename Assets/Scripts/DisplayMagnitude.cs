using UnityEngine;
using TMPro;

public class DisplayMagnitude : MonoBehaviour{
    private TextMeshPro displayMagnitude;
    private ObjectOwnerState objectState;

    public void Start() {
        displayMagnitude = gameObject.GetComponent<TextMeshPro>();
        objectState = transform.parent.gameObject.GetComponent<ObjectOwnerState>();
        UpdateText();
    }

    public void UpdateText() {
        try {
            displayMagnitude.text = objectState.GetMagnitude().ToString();
        } catch (System.Exception e) {
            Debug.Log(e.Message);
        }
    }

}
