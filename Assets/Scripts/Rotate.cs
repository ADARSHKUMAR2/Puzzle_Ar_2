using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 10;

    public GameObject centre_model;
    // Update is called once per frame

    private void Start()
    {
   
    }
    
    void Update()
    {
        if(gameObject.tag=="GameController")
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
    }

    private void OnMouseDrag()
    {
        float rotZ = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
        transform.Rotate(Vector3.down, rotZ);
    }

   
}
