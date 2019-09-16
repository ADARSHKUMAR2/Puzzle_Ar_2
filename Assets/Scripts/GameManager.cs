﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vuforia
{
    
    public class GameManager : MonoBehaviour
    {
        public GameObject Position_detector;
        public GameObject Collision_Detector;
        public GameObject centre_model;
        Vector3 pos_object;
        bool on_pos = false;
        public Transform Parent_Model;
        public List<Transform> child_pieces;
        public GameObject Main_GameObject;
        private int all_pieces_set;
        private VbScript vbScript;
        public Transform child_object_parent;

        void Start()
        {
            pos_object = transform.position;
            all_pieces_set = 0;
            vbScript = GetComponent<VbScript>();
        }

        void OnMouseDrag()
        {
            //Vector3 pos_mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
            //transform.position = new Vector3(pos_mouse.x, pos_mouse.y, transform.position.z);
            //if(!on_pos)
            //{
                Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f);
                Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                transform.position = objPosition;
            //}
        }


        void Update()
        {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();
            foreach (TrackableBehaviour tb in tbs)
            {

                Main_GameObject.gameObject.SetActive(true);
            }
            if (on_pos)
            {
                //transform.localPosition = centre_model.transform.position;
                transform.localRotation = Quaternion.identity;
            }

            if(all_pieces_set==5)
            {
                vbScript.Object_to_rotate.SetActive(false);
            }
        }

        public void OnMouseUp()
        {
            if (on_pos)
            {
                all_pieces_set++;
                transform.position = Position_detector.transform.position;
                //Debug.Log("Placed at correct pos");
                transform.rotation = Quaternion.Euler(child_object_parent.transform.eulerAngles.x, child_object_parent.transform.eulerAngles.y, child_object_parent.transform.eulerAngles.z);
                transform.parent = Parent_Model.transform;
                gameObject.GetComponent<Rotate>().enabled = false;
            }

            else
            {
                transform.position = pos_object;
            }
        }

        public void OnTriggerStay(Collider obj)
        {
            if (obj.gameObject == Collision_Detector)
            {
                on_pos = true;
            }
        }

        public void OnTriggerExit(Collider obj)
        {
            if (obj.gameObject == Collision_Detector)
            {
                on_pos = false;
            }
        }

    }
}