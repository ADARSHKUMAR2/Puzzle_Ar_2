using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class VbScript : MonoBehaviour 
{
    private bool isdouble = false;
    private float doubleClickTimeLimit = 0.25f;
    public GameObject Object_to_rotate;

   

    public void OnMouseDrag()
    {
      
            float rotationX = Input.GetAxis("Mouse X") * 200f * Mathf.Deg2Rad;
            Object_to_rotate.transform.Rotate(Vector3.up, -rotationX); 
    }

}
