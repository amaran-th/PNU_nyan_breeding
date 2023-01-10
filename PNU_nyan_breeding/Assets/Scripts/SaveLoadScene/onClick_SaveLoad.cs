using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 
// 일단은 슬롯을 총 3개로 가정
 
public class onClick_SaveLoad : MonoBehaviour
{
    public GameObject SavePopUp;

    void Start()
    {
        
    }

    public void LoadSlot(int number)
    {
        DataManage.instance.slotNumber = number;

        //if(isSaveFileExists[number])
        //{
            DataManage.instance.LoadData();
        //}
    }

    public void SaveSlot(int number)
    {
        DataManage.instance.slotNumber = number;
        DataManage.instance.SaveData();
    }

    public void GoGame()
    {

    }
}