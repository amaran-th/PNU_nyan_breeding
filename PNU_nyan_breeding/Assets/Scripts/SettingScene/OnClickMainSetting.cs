using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OnClickMainSetting : MonoBehaviour
{
    public GameObject MainSetting;
    public GameObject SoundOption;
    public GameObject ProducerInfoOption;
    public GameObject SoundCreditOption;    
    public GameObject HomeOption;

    private AudioSource BGMAudioSource;
    private GameObject[] musics;
    public AudioMixer BGM;
    public Slider BGMSlider;

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



    public void BGMControl()
    {
        float BGMVal = BGMSlider.value;

        BGM.SetFloat("BGMParameters", Mathf.Log10(BGMVal)*20);
    }

}