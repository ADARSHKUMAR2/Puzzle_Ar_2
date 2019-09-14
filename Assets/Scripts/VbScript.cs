using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class VbScript : MonoBehaviour
{

    private Touch touch;
    private Vector2 touchPosition;

    

    int TapCount;
    public float MaxDubbleTapTime;
    float NewTime;

    void Start()
    {
        TapCount = 0;
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                TapCount += 1;
            }

            if (TapCount == 1)
            {

                NewTime = Time.time + MaxDubbleTapTime;
            }
            else if (TapCount == 2 && Time.time <= NewTime)
            {

                //Whatever you want after a dubble tap    
                //print("Dubble tap");
                float rotationX = Input.GetAxis("Mouse X") * 200f * Mathf.Deg2Rad;
                transform.Rotate(Vector3.up, -rotationX);

                TapCount = 0;
            }

        }
        if (Time.time > NewTime)
        {
            TapCount = 0;
        }
    }


    public void OnMouseDrag()
    {
        
    }

}
