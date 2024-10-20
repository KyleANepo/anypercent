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
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayMusic(int scene)
    {
        Debug.Log(musicScores[scene]);
        if (musicPlayer.clip != musicScores[scene])
        {
            musicPlayer.clip = musicScores[scene];
            musicPlayer.Play();
        }
    }
}
