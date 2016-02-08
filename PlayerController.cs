using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary 
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
	public SimpleTouchPad touchPad;

    public float fireRate;
    private float nextFire;

	private Quaternion calibrationQuaternion;

	void Start(){
		CalibrateAccelerometer ();
	}

    void Update() {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //GameObject clone = 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            AudioSource audi = GetComponent<AudioSource>();
            audi.Play();
        }
        
    }

	void FixedUpdate () 
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Vector3 accelerationRaw = Input.acceleration;
		//Vector3 acceleration = FixAcceleration (accelerationRaw);
		//Vector3 movement = new Vector3(acceleration.x, 0.0f, acceleration.y); 

		Vector2 direction = touchPad.GetDirection ();
		Vector3 movement = new Vector3(direction.x, 0.0f, direction.y); 
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.velocity = movement*speed;

        rigid.position = new Vector3
        (
            Mathf.Clamp(rigid.position.x, boundary.xMin, boundary.xMax),
            0.0f, 
            Mathf.Clamp(rigid.position.z, boundary.zMin, boundary.zMax)
        );

        rigid.rotation = Quaternion.Euler(0.0f, 0.0f, rigid.velocity.x * -tilt);
	}

	void CalibrateAccelerometer(){
		Vector3 accelerationSnapshot = Input.acceleration;
		Quaternion rotateQuaternion = Quaternion.FromToRotation (new Vector3 (0.0f, 0.0f, -1.0f), accelerationSnapshot);
		calibrationQuaternion = Quaternion.Inverse (rotateQuaternion);
	}

	Vector3 FixAcceleration(Vector3 acceleration){
		Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
		return fixedAcceleration;
	}
}
