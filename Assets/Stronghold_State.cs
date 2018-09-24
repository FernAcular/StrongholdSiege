using UnityEngine;

public class Stronghold_State : MonoBehaviour {

    public int magnitude = 0;
    public Player player;

    //Rendering Component contains Material Color
    private Renderer rend;

    void Start() {
        //Get Rendering Component
        rend = GetComponent<Renderer>();

        //Instantiate Color
        if (player != null) {
            rend.material.color = player.color;
        }
    }

}
