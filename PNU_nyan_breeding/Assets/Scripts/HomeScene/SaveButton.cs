using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    public GameObject SaveSlotPage;

    public void SaveBtnClicked()
    {
        SaveSlotPage.SetActive(true);
    }
}
