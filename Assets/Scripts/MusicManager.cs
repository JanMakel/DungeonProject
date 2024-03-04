using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //Variable Region Start
    public static MusicManager Instance;

    public AudioClip[] backgroundMusics;
    public AudioClip[] soundEffects;

    public AudioSource backgroundMusicSource;
    private AudioSource soundEffectSource;

    private int currentBackgroundMusicIndex = 0;

    //Variable Region End
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           
        }
        else
        {
            Destroy(gameObject);
        }

        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        soundEffectSource = gameObject.AddComponent<AudioSource>();

        backgroundMusicSource.volume = 0.1f;
        soundEffectSource.volume = 0.2f;
    }

    private void Start()
    {
        PlayBackgroundMusic(currentBackgroundMusicIndex);
    }


    /// <summary>
    /// This function Start the backgroun Music that you indicate by an index
    /// </summary>
    /// <param name="index"></param>
    public void PlayBackgroundMusic(int index)
    {
        if (index < 0 || index >= backgroundMusics.Length)
            return;

        currentBackgroundMusicIndex = index;
        backgroundMusicSource.clip = backgroundMusics[index];
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    /// <summary>
    /// This Function plays the netx background Music in the array, if it was the last resets to the first one on the array
    /// </summary>
    public void PlayNextBackgroundMusic()
    {
        currentBackgroundMusicIndex = (currentBackgroundMusicIndex + 1) % backgroundMusics.Length;
        PlayBackgroundMusic(currentBackgroundMusicIndex);
    }

    /// <summary>
    /// This Function plays the Sound Effect you indicate with an index
    /// </summary>
    /// <param name="index"></param>
    public void PlaySoundEffect(int index)
    {
        if (index < 0 || index >= soundEffects.Length)
            return;

        soundEffectSource.PlayOneShot(soundEffects[index]);
    }
}
