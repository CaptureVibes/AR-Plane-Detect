using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using TMPro;

public class ImageTracking : MonoBehaviour
{
    public TMP_Text m_ToggleImageTrackingText;
    ARTrackedImageManager m_ARTrackedImageManager;

    void Awake()
    {
        m_ARTrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    public void ToggleImageTracking(){
        m_ARTrackedImageManager.enabled = !m_ARTrackedImageManager.enabled;

        string ImageTrackingMessage = " ";

        if(m_ARTrackedImageManager.enabled){
            ImageTrackingMessage = "Disable Image Tracking and hide existing";
            SetAllImagesActive(true);
        }
        else{
            ImageTrackingMessage = "Enable Image Tracking and Show existing";
            SetAllImagesActive(false);  
        }

        if(m_ToggleImageTrackingText != null){
            m_ToggleImageTrackingText.text = ImageTrackingMessage;
        }
    }

    void SetAllImagesActive(bool value){
        foreach(var img in m_ARTrackedImageManager.trackables){
            img.gameObject.SetActive(value);
        }
    }
}