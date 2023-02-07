using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtcButton : MonoBehaviour
{
    public GameObject modal;
    
    public void OnClickEtcButton(){
        modal.SetActive(true);
    }
    
    public void OnClickCancelButton(){
        modal.SetActive(false);
    }
}
