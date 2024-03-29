using UnityEngine;
using UnityEngine.Audio;

public class RandomMusic : MonoBehaviour
{
    public AudioClip[] _tracks;
    private AudioSource _randomTrack;

    void Start()
    {
        _randomTrack = FindObjectOfType<AudioSource>();

        PlayRandomMusic();
        _randomTrack.loop = true;
    }

    void PlayRandomMusic()
    {
        _randomTrack.clip = _tracks[Random.Range(0, _tracks.Length)];
        _randomTrack.Play();
    }
}