using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

    public float tumble;

    void Start() {
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
