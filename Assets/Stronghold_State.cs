using UnityEngine;

public class Stronghold_State : MonoBehaviour {

    //Player color and name Properties
    public Player player;

    //Stronghold magnitude
    public int magnitude = 0;

    //Rendering Component contains Material Color
    public Renderer rend;

    void Start() {

        //Get Rendering Component
        rend = GetComponent<Renderer>();

        //Instantiate Color and Magnitude
        if (player != null)
        {
            Debug.Log("Changing Color");
            rend.material.color = player.color;
        }
        else
        {
            Debug.Log("Player doesnt exist");
        }

    }

}
