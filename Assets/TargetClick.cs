using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetClick : MonoBehaviour {
    
    void OnMouseDown()
    {
        FindObjectOfType<GameEngine>().MoveSoldierToTarget(transform);
    }
}
