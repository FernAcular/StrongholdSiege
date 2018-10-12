using UnityEngine;

public class ObjectOwnerState : MonoBehaviour {

    public Player player;
    private int magnitude;

    // Rendering Component contains Material Color
    private Renderer rend;

    void Start() {
        // Get Rendering Component
        rend = GetComponent<Renderer>();
        UpdateColor();
    }

    public void UpdateColor() {
        if (player != null) {
            rend.material.color = player.color;
        }
    }

    public int GetMagnitude() {
        return magnitude;
    }

    public void SetMagnitude(int magnitude) {
        this.magnitude = magnitude;
    }

    public Renderer GetRenderComponent(){
      return rend;
    }
}
