using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickMainSetting : MonoBehaviour
{
    public GameObject MainSetting;
    public GameObject SoundOption;
    public GameObject ProducerInfoOption;
    public GameObject SoundCreditOption;    
    public GameObject HomeOption;

    public void SoundBtnClicked()
    {
        MainSetting.SetActive(false);
        SoundOption.SetActive(true);
    }

    public void CreditOpensourceBtnClicked()
    {
        SoundOption.SetActive(false);
        SoundCreditOption.SetActive(true);
    }

    public void SoundCreditBackBtnClicked()
    {
        SoundCreditOption.SetActive(false);
        SoundOption.SetActive(true);
    }

    public void SoundBackBtnClicked()
    {
        SoundOption.SetActive(false);
        MainSetting.SetActive(true);
    }

    public void ProcucerInfoBtnClicked()
    {
        MainSetting.SetActive(false);
        ProducerInfoOption.SetActive(true);
    }

    public void ProducerInfoBackBtnClicked()
    {
        ProducerInfoOption.SetActive(false);
        MainSetting.SetActive(true);
    }

    public void HomeBtnClicked()
    {
        MainSetting.SetActive(false);
        HomeOption.SetActive(true);
    }

    public void HomeYesBtnClicked()
    {

    }

    public void HomeNoBtnClicked()
    {
        HomeOption.SetActive(false);
        MainSetting.SetActive(true);
    }


}