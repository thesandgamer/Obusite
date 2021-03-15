using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Scr_ButtonActions : MonoBehaviour
{

    public void ShowHideCapaPannel(GameObject pannel)
    {

        if (!pannel.activeSelf)
        {
            pannel.SetActive(true);
        }
        else if (pannel.activeSelf)
        {
            pannel.SetActive(false);
        }
        

    }
    public void HidePannel(GameObject pannel)
    {
       

    }


}
