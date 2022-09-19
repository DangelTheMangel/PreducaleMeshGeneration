using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 10;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yRotation =(transform.rotation.eulerAngles.y + rotationSpeed * Input.GetAxisRaw("Horizontal"));
        transform.rotation = Quaternion.AngleAxis(yRotation, Vector3.up);
        transform.Translate(Vector3.forward * Input.GetAxisRaw("Vertical")* speed);
    }
}
