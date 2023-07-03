using UnityEngine;
using TMPro;

public class DoubleTap : MonoBehaviour
{
    public TextMeshProUGUI myText;
    public float doubleTapTime = 0.3f; // 双击时间阈值
    private float lastTapTime = 0f; // 上一次点击时间
    private GameObject lastTappedObject = null; // 上一次点击的物体
    AudioControl myAudioController;

    private void Start()
    {
        myAudioController = gameObject.GetComponent<AudioControl>();
    }
    void Update()
    {
        
        // 检测触摸事件
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hitInfo))
            {
                GameObject tappedObject = hitInfo.collider.gameObject;

                if (tappedObject == lastTappedObject && Time.time - lastTapTime < doubleTapTime)
                {
                    // 双击事件
                    OnDoubleTap(tappedObject);
                }
                else
                {
                    // 单击事件
                    lastTappedObject = tappedObject;
                    lastTapTime = Time.time;
                
                }
            }
        }
    }

    void OnDoubleTap(GameObject tappedObject)
    {
        // 在这里编写处理双击事件的代码
        Debug.Log("Double Tapped Object: " + tappedObject.name);
        string line = "Hello World";

        switch (tappedObject.name)
        {
            case "pipa":
                myAudioController.PlayerStatus[0] = !myAudioController.PlayerStatus[0];
               
                if (myAudioController.PlayerStatus[0]) line = "Pipa Playing";
              
                break;
            case "dagu":
                myAudioController.PlayerStatus[1] = !myAudioController.PlayerStatus[1];
                if (myAudioController.PlayerStatus[1]) line = "Dagu Playing";
                else if (!myAudioController.PlayerStatus[1]) line = "Dagu Stoped";
                break;
            case "guqin":
                myAudioController.PlayerStatus[2] = !myAudioController.PlayerStatus[2];
                line = "Guqin tapped";
                break;
            case "guzheng":
                myAudioController.PlayerStatus[3] = !myAudioController.PlayerStatus[3];
                Debug.Log("Guzheng tapped");
                break;
            case "suona":
                myAudioController.PlayerStatus[4] = !myAudioController.PlayerStatus[4];
                Debug.Log("Suona tapped");
                break;
            default:
                Debug.Log("Unknown object tapped");
                break;
        }
        myText.text = line;
    }
}