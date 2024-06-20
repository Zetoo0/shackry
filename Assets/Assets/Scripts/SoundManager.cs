using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Object = UnityEngine.Object;

public class SoundManager : MonoBehaviour
{
    public enum  Sound
    {
        p_Shoot,
        p_Reload,
        p_Walk,
        p_Jump,
        p_Hurt,
        p_Swish,
        e_Walk,
        e_Chase,
        e_Attack,
        e_Hurt,
        b_music
    }

    [SerializeField] public SoundAudio[] soundAudioArray;
    [SerializeField] public static AudioClip[] audioArray;
    private Dictionary<Sound, float> soundTimeDict;

    [System.Serializable]
    public class SoundAudio
    {
        public Sound sound;
        public AudioClip clip;
    }

    private void Start()
    {
        soundTimeDict = new Dictionary<Sound, float>();
        soundTimeDict[Sound.p_Walk] = 0f;
        soundTimeDict[Sound.e_Attack] = 0f;
        soundTimeDict[Sound.e_Chase] = 0f;
        soundTimeDict[Sound.p_Walk] = 0f;
    }

    public void PlayAudioAt(Sound sound, Vector3 pos, bool is3D)
    {
        if (IsSoundCanPlay(sound))
        {
            GameObject s_sound = new GameObject("ASound");
            AudioSource clip = s_sound.AddComponent<AudioSource>();
            clip.spatialBlend = 1.0f;
            clip.rolloffMode = AudioRolloffMode.Logarithmic;
            clip.maxDistance = 0.1f;
            clip.dopplerLevel = 0f;
            s_sound.transform.position = pos;
            if (sound.Equals(Sound.e_Hurt))
            {
                clip.volume = 0.2f;
            }
            else
            {
                clip.volume = 0.01f;

            }
            clip.clip = GetAudio(sound);
            clip.Play();
           Destroy(s_sound,clip.clip.length);
           // SetSoundObjectInactive(s_sound, clip.clip.length);
        }
        
    }

    private IEnumerator SetSoundObjectInactive(GameObject obj, float dur)
    {
        yield return new WaitForSecondsRealtime(dur);
        obj.SetActive(false);
    }

    public bool IsSoundCanPlay(Sound sound)
    {
        switch (sound)
        {
            case Sound.p_Walk:
                if (soundTimeDict.ContainsKey(sound))
                {
                    
                    float lastTimePlayed = soundTimeDict[sound];
                    float maxTime = 0.5f;
                    if (lastTimePlayed + maxTime < Time.time)
                    {
                        soundTimeDict[Sound.p_Walk] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
                break;
            case Sound.e_Walk:
                if (soundTimeDict.ContainsKey(sound))
                {
                    
                    float lastTimePlayed = soundTimeDict[sound];
                    float maxTime = 0.5f;
                    if (lastTimePlayed + maxTime < Time.time)
                    {
                        soundTimeDict[Sound.e_Walk] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
                break;
            case Sound.e_Chase:
                if (soundTimeDict.ContainsKey(sound))
                {
                    
                    float lastTimePlayed = soundTimeDict[sound];
                    float maxTime = 0.5f;
                    if (lastTimePlayed + maxTime < Time.time)
                    {
                        soundTimeDict[Sound.e_Chase] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
                break;
            case Sound.e_Attack:
                if (soundTimeDict.ContainsKey(sound))
                {
                    
                    float lastTimePlayed = soundTimeDict[sound];
                    float maxTime = 0.5f;
                    if (lastTimePlayed + maxTime < Time.time)
                    {
                        soundTimeDict[Sound.e_Attack] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
                break;
            default:
                return true;

        }

        return false;
    }

    private AudioClip GetAudio(Sound sound)
    {
        foreach (SoundAudio soundElem in soundAudioArray)
        {
            if (soundElem.sound == sound)
            {
                return soundElem.clip;
            }
        }
        return null;
    }

  /* public static void PlayAudio(string name)
   {
       foreach (AudioClip clip in SoundManager.audioArray)
       {
           if (clip.name.Equals(name))
           {
                   
           }
       }
   }*/
    
}
