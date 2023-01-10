using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mail : MonoBehaviour
{
    // public TextMeshProUGUI mailTitle;
    // public TextMeshProUGUI mailSender;
    // public TextMeshProUGUI mailSendtime;
    // public string mailTitle;
    // public string mailSender;
    // public string mailSendtime;
    public TextMeshProUGUI mailTitle;
    public TextMeshProUGUI mailSender;
    public TextMeshProUGUI mailSendtime;
    public string title;
    public string sender;
    public string sendtime;

    // Start is called before the first frame update
    void Start()
    {
        mailSender.text = string.Empty;
        mailTitle.text = string.Empty;
        mailSendtime.text = string.Empty;
        SetMailContents();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetMailContents()
    {
        mailSender.text = sender;
        mailTitle.text = title;
        mailSendtime.text = sendtime;
        
    }
}
