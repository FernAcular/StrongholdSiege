using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Transform target;

    public float speed = 1f;

	// Use this for initialization
	void Start () {
        if (target == null) target = transform;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(target.position);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
