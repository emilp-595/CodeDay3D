using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float rotateSpeed;

    Quaternion rotation;
    void Awake()
    {
        rotation = transform.rotation;
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Translate(0f, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        //add what is there for Vertical to the other ones to move it those ways

        if (Input.GetKeyDown("A")|| Input.GetKeyDown("left"))
        {
            transform.Rotate(Vector3.left*Time.deltaTime, Space.World);
        }

        if (Input.GetKeyDown("D")|| Input.GetKeyDown("right"))
        {
            transform.Rotate(Vector3.right * Time.deltaTime, Space.World);
        }

        /*if (e.KeyCode == "A")
        {
            transform.Rotate(0, 2, 0);
        }
        if (e.KeyCode == "D")
        {
            transform.Rotate(0, -2, 0);
        }*/

    }

}

