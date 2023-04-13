using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @class  : SoundManager
    @date   : 2022-09-01
    @author : 탁준석
    @brief  : 
    @warning: 
 */

public class SoundManager
{
    AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.Count];
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    public void Initialize()
    {
        GameObject root = GameObject.Find("@Sound");
        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
            Object.DontDestroyOnLoad(root);

            string[] names = System.Enum.GetNames(typeof(Define.Sound));
            for (int i = 0; i < names.Length - 1; ++i)
            {
                GameObject go =  new GameObject { name = names[i] };
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }

            _audioSources[(int)Define.Sound.BGM].loop = true;
        }
    }

    public void Play(string path, Define.Sound sound = Define.Sound.Effect, float pitch = 1.0f)
    {
        AudioClip audioClip = GetOrAddAudioClip(path, sound);
        Play(audioClip, sound, pitch);
    }

    public void Play(AudioClip audioClip, Define.Sound sound = Define.Sound.Effect, float pitch = 1.0f)
    {
        if (audioClip == null)
        {
            return;
        }

        if (sound == Define.Sound.BGM)
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.Effect];
            if (audioSource.isPlaying == true)
            {
                audioSource.Stop();
            }

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

    public void Clear()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        _audioClips.Clear();
    }

    AudioClip GetOrAddAudioClip(string path, Define.Sound sound = Define.Sound.Effect)
    {
        if (path.Contains("Sounds/") == false)
        {
            path = $"Sounds/{ path }";
        }

        AudioClip audioClip = null;

        if (sound == Define.Sound.BGM)
        {
            audioClip = Managers.GetResourceManager.Load<AudioClip>(path);
        }
        else
        {
            if (_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = Managers.GetResourceManager.Load<AudioClip>(path);
                _audioClips.Add(path, audioClip);
            }
        }

        if (audioClip == null)
        {
            Debug.Log($"[SoundManager.cs] { path } 오디오 클립이 없습니다.");
        }
        return audioClip;
    }
}
