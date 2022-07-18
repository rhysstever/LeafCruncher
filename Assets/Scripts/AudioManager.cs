using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton Code
    // A public reference to this script
    public static AudioManager instance = null;

    // Awake is called even before start 
    // (I think its at the very beginning of runtime)
    private void Awake()
    {
        // If the reference for this script is null, assign it this script
        if(instance == null)
            instance = this;
        // If the reference is to something else (it already exists)
        // than this is not needed, thus destroy it
        else if(instance != this)
            Destroy(gameObject);
    }
    #endregion
    
    [SerializeField]
    private AudioSource audioSource;

    private AudioClip[] audioClips;

    // Start is called before the first frame update
    void Start()
    {
        audioClips = Resources.LoadAll<AudioClip>("Audio/Clips");
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Plays a given clip
    /// </summary>
    /// <param name="audioClip">The audio clip to be played</param>
    public void PlayClip(AudioClip audioClip)
	{
        audioSource.PlayOneShot(audioClip);
    }

    /// <summary>
    /// Plays a random audio clip
    /// </summary>
    public void PlayRandomClip()
	{
        // Get a random clip
        int randNum = Random.Range(0, audioClips.Length);
        AudioClip randClip = audioClips[randNum];
        
        PlayClip(randClip);
    }
}
