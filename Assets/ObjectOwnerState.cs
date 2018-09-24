using UnityEngine;

public class ObjectOwnerState : MonoBehaviour {

    public int magnitude = 0;
    public Player player;

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
}
