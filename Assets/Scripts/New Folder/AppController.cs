using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class AppController : MonoBehaviour
{
    public GameObject[] spawnPrefabs = new GameObject[5];
    static int myIndex = 0;
    static List<ARRaycastHit> Hits;
    private ARRaycastManager mRaycastManager;
    AudioControl myAudioController;

    public float holdTime = 2.0f;  //定义长按的时间阈值

    private bool isHolding = false;  //标记用户是否正在长按屏幕
    private float timer = 0f;  //计时器，记录用户按住屏幕的时间


    private GameObject[] spawnedObject = new GameObject[5];
    private bool[] isSettled = new bool[5] { false, false, false, false, false };
    private void Start()
    {
        Hits = new List<ARRaycastHit>();
        mRaycastManager = GetComponent<ARRaycastManager>();
        myAudioController = GameObject.Find("Controller").GetComponent<AudioControl>();
    }

    void Update()
    {

        if (Input.touchCount == 0)
            return;
        var touch = Input.GetTouch(0);
        if (mRaycastManager.Raycast(touch.position, Hits, TrackableType.PlaneWithinPolygon | TrackableType.PlaneWithinBounds))
        {
           
            var hitPose = Hits[0].pose;

            int i = myIndex;
            if (spawnedObject[i] == null)
            {
                spawnedObject[i] = Instantiate(spawnPrefabs[i], hitPose.position, hitPose.rotation);
            }
            else
            {
                if(!isSettled[i])
                spawnedObject[i].transform.position = hitPose.position;
            }
        }

        if (touch.phase == TouchPhase.Began)
        {
            isHolding = true;  //用户按下屏幕，标记为正在长按
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            isHolding = false;  //用户松开屏幕，标记为不再长按
            timer = 0f;  //重置计时器
        }

        if (isHolding)
        {
            timer += Time.deltaTime;  //更新计时器
            if (timer >= holdTime)
            {
                //用户长按屏幕超时，调用settle函数
                Settle(myIndex);
                isHolding = false;  //标记为不再长按
                timer = 0f;  //重置计时器
            }
        }

    }

    static public void ChangePrefab(int index)
    {
        myIndex = index;
    }

    public void Reset()
    {
        for (int i = 0; i < spawnedObject.Length; i++)
        {
            if (spawnedObject[i] != null)
            {
                Destroy(spawnedObject[i]);
            }
            spawnedObject[i] = null;
            isSettled[i] = false;
        }

        myAudioController.ResetAudio();
    }

    public void  Settle(int i)
    {
        isSettled[i] = true;
    }
}
