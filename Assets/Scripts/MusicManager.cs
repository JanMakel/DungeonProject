using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioClip[] backgroundMusics;
    public AudioClip[] soundEffects;

    public AudioSource backgroundMusicSource;
    private AudioSource soundEffectSource;

    private int currentBackgroundMusicIndex = 0;

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

    public void PlayBackgroundMusic(int index)
    {
        if (index < 0 || index >= backgroundMusics.Length)
            return;

        currentBackgroundMusicIndex = index;
        backgroundMusicSource.clip = backgroundMusics[index];
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlayNextBackgroundMusic()
    {
        currentBackgroundMusicIndex = (currentBackgroundMusicIndex + 1) % backgroundMusics.Length;
        PlayBackgroundMusic(currentBackgroundMusicIndex);
    }

    public void PlaySoundEffect(int index)
    {
        if (index < 0 || index >= soundEffects.Length)
            return;

        soundEffectSource.PlayOneShot(soundEffects[index]);
    }
}
