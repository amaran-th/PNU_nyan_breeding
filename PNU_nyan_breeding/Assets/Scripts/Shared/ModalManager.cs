using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class ModalManager : MonoBehaviour
{
    public static ModalManager instance;
    public delegate void Callback();
    private Callback callbackOK = null;
    private Callback callbackYES = null;
    private Callback callbackNO = null;
    
    // Define
    public enum ModalResponse { OK, YES, NO }
    
    public GameObject Modal;
    public GameObject MessageBox;
    public GameObject OneButton;
    public GameObject YesOrNoButton;
    
    private Button OKButton;
    private Button YesButton;
    private Button NoButton;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        OKButton = OneButton.GetComponent<Button>();
        YesButton = YesOrNoButton.transform.Find("YesButton").gameObject.GetComponent<Button>();
        NoButton = YesOrNoButton.transform.Find("NoButton").gameObject.GetComponent<Button>();
        
        OKButton.onClick.AddListener(CloseModal);
        YesButton.onClick.AddListener(CloseModal);
        NoButton.onClick.AddListener(CloseModal);

        if(instance == null){
            instance = this;
        }

        ModalInit();
    }

    private void ModalInit() // 초기화
    {
        Modal.SetActive(false);
        YesOrNoButton.SetActive(false);
        OneButton.SetActive(false);
    }
    
    public void OpenModal(string message)
    {
        ModalInit();
        Modal.SetActive(true);
        OneButton.SetActive(true);
        MessageBox.GetComponent<TextMeshProUGUI>().text = message;

        SetCallback(null, ModalResponse.OK);
    }

    public void OpenModal(string message, Callback Function)
    {
        ModalInit();
        Modal.SetActive(true);
        OneButton.SetActive(true);
        MessageBox.GetComponent<TextMeshProUGUI>().text = message;
        
        SetCallback(Function, ModalResponse.OK);
    }

    public void YesOrNoOpenModal(string message, Callback yesButtonFuncion, Callback noButtonFuntion)
    {
        ModalInit();
        Modal.SetActive(true);
        YesOrNoButton.SetActive(true);
        MessageBox.GetComponent<TextMeshProUGUI>().text = message;

        SetCallback(yesButtonFuncion, ModalResponse.YES);
        SetCallback(noButtonFuntion, ModalResponse.NO);
    }

    public void CloseModal()
    {
        ModalInit();
        
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "OKButton":
                callbackOK?.Invoke();
                callbackOK = null;
                break;
                
            case "YesButton":
                callbackYES?.Invoke();
                callbackYES = null;
                break;

            case "NoButton":
                callbackNO?.Invoke();
                callbackYES = null;
                break;

            default:
                break;
        }
    }

    // Callback 관련
    public void SetCallback(Callback call, ModalResponse buttontype)
    {
        switch (buttontype)
        {
            case ModalResponse.OK:
                callbackOK = call;
                break;

            case ModalResponse.YES:
                callbackYES = call;
                break;

            case ModalResponse.NO:
                callbackNO = call;
                break;

            default:
                callbackOK = call;
                callbackYES = call;
                callbackNO = call;
                break;
        }
    }
}