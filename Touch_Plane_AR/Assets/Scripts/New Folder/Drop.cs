using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Drop : MonoBehaviour
{
    public int myModel = 0;

    public TMP_Dropdown  dropdown;


    public void OnDropdownValueChanged()
    {
        int index = dropdown.value;
        switch (index)
        {
            case 0:
                myModel = 0;
                break;

            case 1:
                myModel = 1;
                break;

            case 2:
                myModel = 2;
                break;

            case 3:
                myModel = 3;
                break;

            case 4:
                myModel = 4;
                break;

            default:
               
                break;
        }
        AppController.ChangePrefab(myModel);
    }
}