using UnityEngine;

public class ObjectOwnerState : MonoBehaviour {

    public Player player;
    private int magnitude;

    private Transform childText;
    // Rendering Component contains Material Color
    private Renderer rend;

    void Start() {
        // Get Rendering Component
        rend = GetComponent<Renderer>();
        childText = transform.GetChild(0);
        UpdateColor();
    }

    public void UpdateColor() {
        if (player != null) {
            rend.material.color = player.color;
        }
    }

    public void SetMagnitude(int magnitude) {
        this.magnitude = magnitude;
        try {
            childText.GetComponent<DisplayMagnitude>().UpdateText();
        } catch(System.Exception e) {
            Debug.Log(e.Message);
        }
    }

    public int GetMagnitude() {
        return magnitude;
    }

    public Renderer GetRenderComponent() {
      return rend;
    }
}
