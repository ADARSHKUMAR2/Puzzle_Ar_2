using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class VbScript : MonoBehaviour 
{
    
    public List<GameObject> Object_to_rotate;
    
    public void OnMouseDrag()
    {      
        float rotationX = Input.GetAxis("Mouse X") * 200f * Mathf.Deg2Rad;
        foreach(var listofgameobjects in Object_to_rotate)
        {
            //Object_to_rotate.transform.Rotate(Vector3.up, -rotationX);
            listofgameobjects.transform.Rotate(Vector3.up, -rotationX);
        }
    }

}
