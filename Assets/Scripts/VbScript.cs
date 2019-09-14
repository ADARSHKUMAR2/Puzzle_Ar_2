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

    protected void Start()
    {
        StartCoroutine(InputListener());
    }

    // Update is called once per frame
    private IEnumerator InputListener()
    {
        while (enabled)
        { //Run as long as this is activ

            if (Input.GetMouseButtonDown(0))
                yield return ClickEvent();

            yield return null;
        }
    }

    private IEnumerator ClickEvent()
    {
        //pause a frame so you don't pick up the same mouse down event.
        yield return new WaitForEndOfFrame();

        float count = 0f;
        while (count < doubleClickTimeLimit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DoubleClick();
                yield break;
            }
            count += Time.deltaTime;// increment counter by change in time between frames
            yield return null; // wait for the next frame
        }
        SingleClick();
    }


    private void SingleClick()
    {
        isdouble = false;
        Debug.Log("Single Click");
    }

    private void DoubleClick()
    {
        isdouble = true;
        Debug.Log("Double Click");
    }




    public void OnMouseDrag()
    {
      
            float rotationX = Input.GetAxis("Mouse X") * 200f * Mathf.Deg2Rad;
            transform.Rotate(Vector3.up, -rotationX);
       
        
    }

}
