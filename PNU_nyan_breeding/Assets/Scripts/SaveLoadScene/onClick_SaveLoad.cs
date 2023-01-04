using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class onClick_SaveLoad : MonoBehaviour
{
    public GameObject SettingPage;
    public GameObject SaveLoadPage;
 
    public void saveLoad_btn_clicked()
    {
        SettingPage.SetActive(false);
        SaveLoadPage.SetActive(true);
    }
}