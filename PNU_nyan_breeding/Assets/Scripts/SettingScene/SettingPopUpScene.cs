using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingPopUpScene : MonoBehaviour
{
    public GameObject SettingBtn;
    public GameObject SoundBtn;
    public GameObject InfoBtn;
    public GameObject TitleBtn;

    public GameObject SettingPopUp;
    public GameObject SoundPopUp;
    public GameObject InfoPopUp;
    
    public AudioMixer BGMSource;
    public Slider BGMSourceSlider;
    public Slider EffectSlider;
    
    public void BGMSourceControl()
    {
        float BGMVal = BGMSourceSlider.value;
        BGMSource.SetFloat("BGMSourceParam", Mathf.Log10(BGMVal)*20);
    }

    public void TitleYesClicked()
    {
        SceneManager.LoadScene("TitleScene");
        
    }



}