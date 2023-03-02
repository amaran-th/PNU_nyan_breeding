using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShowDate : MonoBehaviour
{
    public TMP_Text date;

    void Start()
    {
        date.text = DateTime.Now.ToString(("yyyy"))+".03.02";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
