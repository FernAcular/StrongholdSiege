using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 20f;

    private Transform target;

	void Start () {
        if (target == null) {
            target = transform;
        }
    }
	
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void SetTarget(Transform target) {
        this.target = target;
    }
}
