using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip _shootingClip;
    [SerializeField] [Range(0f, 1f)] float _shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip _damageClip;
    [SerializeField] [Range(0f, 1f)] float _damageVolume = 1f;

    [Header("Singleton")]
    private static AudioPlayer _instance;

    
    void Awake()
    {
        GetInstance();
    }
    public static AudioPlayer GetInstance()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<AudioPlayer>();
        }
        return _instance;
    }
    public void PlayShootingClip()
    {
        PlayClip(_shootingClip, _shootingVolume);
    }
    public void PlayDamageClip()
    {
        PlayClip(_damageClip, _damageVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);        
        }
    }
}
