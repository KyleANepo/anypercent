using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager _instance;

    public static SFXManager Instance { get { return _instance; } }

    [SerializeField] private AudioSource soundFXObject;
    [SerializeField] AudioClip[] musicScores;
    private AudioSource musicPlayer;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource asshole = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        asshole.clip = audioClip;
        asshole.volume = volume;
        asshole.Play();
        float clipLength = asshole.clip.length;

        Destroy(asshole.gameObject, clipLength);
    }

    public void PlayMusic(int scene)
    {
        // Debug.Log(musicScores[scene]);
        if (musicPlayer.clip != musicScores[scene])
        {
            musicPlayer.clip = musicScores[scene];
            musicPlayer.Play();
        }
    }

    public void MuteMusic(bool muted)
    {
        musicPlayer.mute = muted;
    }
}
