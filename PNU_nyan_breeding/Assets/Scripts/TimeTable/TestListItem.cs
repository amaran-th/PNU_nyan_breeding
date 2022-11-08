using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestListItem : MonoBehaviour
{
    public TMP_Text text;

    public void Init(int id, string ico_name){
        text.text=ico_name;
    }
}
