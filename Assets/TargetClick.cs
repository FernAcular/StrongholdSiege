using UnityEngine;

public class TargetClick : MonoBehaviour {
    
    void OnMouseDown() {
        FindObjectOfType<GameEngine>().RegisterStrongholdClick(transform);
    }
}
