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
    public GameObject EndgameBtn;

    public GameObject SettingPopUp;
    public GameObject SoundPopUp;
    public GameObject InfoPopUp;
    public GameObject TitlePopUp;
    public GameObject EndPopUp;
    
    public AudioMixer BGMSource;
    public AudioMixer EffectSource;
    public Slider BGMSourceSlider;
    public Slider EffectSlider;

    static public SettingPopUpScene instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void BGMSourceControl()
    {
        float BGMVal = BGMSourceSlider.value;
        BGMSource.SetFloat("BGMSourceParam", Mathf.Log10(BGMVal)*20);
    }

    public void EffectSourceControl()
    {
        float EffectVal = EffectSlider.value;
        EffectSource.SetFloat("EffectSourceParam", Mathf.Log10(EffectVal)*20);
    }



    public void TitleYesClicked()
    {
        SceneManager.LoadScene("TitleScene");
        TitlePopUp.SetActive(false);
        SettingPopUp.SetActive(false);

        
    }

    public void EndgameYesClicked()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //에디터 종료
    #else
        Application.Quit(); // 어플리케이션 종료
    #endif
        
    }



}