using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {  get; private set; }

    [SerializeField] private AudioHolder[] audioHolders;

    private Dictionary<string, AudioHolder> _audioDic;
    private void Awake()
    {
        Instance = this;

        _audioDic = new Dictionary<string, AudioHolder>();
        for (int i = 0; i < audioHolders.Length; i++)
        {
            _audioDic.Add(audioHolders[i].AudioName, audioHolders[i]);
        }
    }

    public void PlayAudio(string name) 
    {
        var audioHolder = _audioDic[name];
        var audioName = audioHolder.AudioName;
        var clip = audioHolder.GetAudioClip();
        var loop = audioHolder.Loop;
        var volume = audioHolder.Volume;
        var specialBlend = audioHolder.SpecialBlend;
        var audioMixer = audioHolder.AudioMixer;

        var audioObject = new GameObject("Audio" + audioName);
        var audioSource = audioObject.AddComponent<AudioSource>();

        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.volume = volume;
        audioSource.spatialBlend = specialBlend;
        audioSource.outputAudioMixerGroup = audioMixer;

        if (!loop)
            Destroy(audioObject, clip.length);

        audioSource.Play();
    }

    [System.Serializable]
    private class AudioHolder 
    {
        public string AudioName;
        public AudioClip[] AudioClips;
        public bool Loop;
        [Range(0, 1)] public float Volume = 1;
        [Range(0, 1)] public float SpecialBlend;
        public AudioMixerGroup AudioMixer;

        public AudioClip GetAudioClip() 
        {
            var randomIndex = Random.Range(0, AudioClips.Length);
            return AudioClips[randomIndex];
        }
    }
}
