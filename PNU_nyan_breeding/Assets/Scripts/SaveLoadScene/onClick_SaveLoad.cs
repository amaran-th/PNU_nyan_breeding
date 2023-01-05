using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class onClick_SaveLoad : MonoBehaviour
{
    public GameObject Page;
    public GameObject SaveLoadPage;
 
    public void saveLoad_btn_clicked()
    {
        Page.SetActive(false);
        SaveLoadPage.SetActive(true);
    }
}