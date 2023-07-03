using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MultiImageTracking : MonoBehaviour
{
    ARTrackedImageManager imgTrackedManager;
    private Dictionary<string, GameObject> mPrefabs = new Dictionary<string, GameObject>();
    
    private void Awake() {
        imgTrackedManager = GetComponent<ARTrackedImageManager>();
    }

    private void Start() {
        mPrefabs.Add("La Muerte. Art by Carlota Santos", Resources.Load("Prefabs/Cube") as GameObject);
        mPrefabs.Add("El Sacerdote. Art by Carlota San", Resources.Load("Prefabs/Sphere") as GameObject);
    }

    private void OnEnable() {
        imgTrackedManager.trackedImagesChanged += OnTrackedImagesChanged;
    }
    private void OnDisable() {
        imgTrackedManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs){
        foreach(var trackedImage in eventArgs.added){
            OnImagesChanged(trackedImage);
        }
    }
    
    private void OnImagesChanged(ARTrackedImage referenceImage){
        Debug.Log("Image name: " + referenceImage.referenceImage.name);
        Instantiate(mPrefabs[referenceImage.referenceImage.name], referenceImage.transform);
    }
}
