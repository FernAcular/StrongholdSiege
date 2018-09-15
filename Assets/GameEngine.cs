using UnityEngine;

public class GameEngine : MonoBehaviour {

    public Movement unit;

	public void MoveSoldierToTarget(Transform target)
    {
        unit.SetTarget(target);
    }
}
