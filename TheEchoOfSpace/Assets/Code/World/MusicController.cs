using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundSource;
    [SerializeField] private AudioSource[] effectSours;

    public AudioSource BackgroundSource { get { return backgroundSource; } }
    public AudioSource[] EffectSours { get { return effectSours; } }
    public AudioMixer MusicMixer;

    public static MusicController instance;

    private void Awake()
    {
        instance = this;
    }
}