using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

AudioClip audioClip1;
AudioClip audioClip2;

AudioSource audio = GetComponent<AudioSource>();
audio.PlayOneShot(audioClip1);
audio.PlayOneShot(audioClip2);
float lifeTime = Mathf.Max(audioClip1.length, audioClip2.length);
GameObject.Destroy(GameObject, lifeTime);

public enum SoundBackBtnClicked
{
    Bgm,
    Effect,
    MaxCount,
}

public class SoundManager
{
    AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();
}

public void init()
{
    
    GameObject root = GameObject.Find(@Sound);
    if (root = null)
    {
        root = new GameObject {name = "@Sound"};
        Object.DontDestroyOnLoad(root);

        string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));
        for(int i =0; i<soundNames.Length-1; i++)
        {
            GameObject go = new GameObject { name = soundNames[i] };
            _audioSources[i] = go.AddComponent<AudioSource>();
            go.transform.parent = root.transform;
        }

        _audioSources[(int)Define.Sound.Bgm].loop = true;
    }
}

public void Clear()
{
    foreach (AudioSource audioSource in _audioSources)
    {
        audioSource.Clip = null;
        audioSource.Stop();
    }
    _audioClips.Clear();
}

public void Play(AudioClip audioClip, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
{
    if (audioClip = null)
        return;

        if(type = Define.Sound.Bgm)
        {
            AudioSource audioSource = _audioSourced[(int)Define.Sound.Bgm];
            if(audioSource.isPlaying)
                audioSource.Stop();

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        else
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.Effect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }
}

public void Play(string path, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
{
    AudioClip audioClip = GetOrAddAudioClip(patj, type);
    Play(audioClip, type, pitch);
}

AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.Effect)
{
    if(path.Contains("Sounds/")=false)
        path = $"Sounds/{path}";

    AudioClip audioClip = null;

    if(type == Define.Sound.Bgm)
}