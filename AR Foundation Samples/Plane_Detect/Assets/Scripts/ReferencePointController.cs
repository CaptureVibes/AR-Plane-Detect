using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]

public class ReferencePointController : MonoBehaviour
{
    public Camera myCamera;
    public GameObject spawnPrefab;
    public GameObject anchorParent;
    private GameObject spawnObject=null;
    private ARAnchorManager  myAnchorManager;


    private float distance = 0.5f;

    void Start()
    {
        myAnchorManager= GetComponent<ARAnchorManager>();
    }

    void Update()
    {
        
        if(Input.touchCount == 0){
            return;
        }

        Touch touch = Input.GetTouch(0);

        
        if(spawnObject == null){
            Vector3 myMenu = myCamera.transform.forward.normalized * distance;
            Pose myPose = new Pose(myCamera.transform.position + myMenu, myCamera.transform.rotation);
            //ARAnchor myAnchor = myAnchorManager.AddAnchor(myPose);
            GameObject myAnchorParent = Instantiate(anchorParent, myPose.position, myPose.rotation);
            ARAnchor myAnchor = anchorParent.AddComponent<ARAnchor>();
            spawnObject = Instantiate(spawnPrefab, myCamera.transform.position + myMenu, myCamera.transform.rotation,myAnchor.gameObject.transform);
        }
    }
}  
