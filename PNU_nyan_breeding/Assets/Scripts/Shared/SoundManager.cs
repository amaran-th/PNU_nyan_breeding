using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    #region singleton
    static public SoundManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);
    }
    #endregion singleton

    public Sound[] effectSounds;
    public Sound[] bgmSounds;

    public AudioSource[] audioSourceBFM;
    public AudioSource[] audioSourceEffects;

    public string[] playSoundName;

    void start()
    {
        playSoundName = new string[audioSourceEffects.Length];
    }

    public void PlaySE(string _name)
    {
        for(int i=0; i<effectSounds.Length; i++)
        {
            if(_name==effectSounds[i].name)
            {
                for(int j=0; j<audioSourceEffects.Length; j++)
                {
                    if(!audioSourceEffects[j].isPlaying)
                    {
                        audioSourceEffects[j].clip = effectSounds[i].clip;
                        audioSourceEffects[j].Play();
                        playSoundName[j] = effectSounds[i].name;
                        return;
                    }
                }
                Debug.Log(_name + "모든 가용 AudioSource가 사용 중입니다.");
                return;
            }
        }
        Debug.Log(_name+"사운드가 SoundManager에 등록되지 않았습니다.");
    }

    public void StopAllSE()
    {
        for(int i=0; i<audioSourceEffects.Length; i++)
        {
            audioSourceEffects[i].Stop();
        }
    }

    public void StopSE(string _name)
    {
        for(int i=0; i<audioSourceEffects.Length; i++)
        {
            if(playSoundName[i] == _name)
            {
                audioSourceEffects[i].Stop();
                break;
            }
        }
        Debug.Log("재생 중인"+_name+"사운드가 없습니다.");
    }
}