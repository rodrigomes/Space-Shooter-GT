using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;

	void Start() 
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * speed;

    }
}
