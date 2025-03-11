using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private float MusicValue;
    private float EffectValue;
    private bool onMusicToogle;
    private bool onEffectToogle;

    [SerializeField] private Slider sliderVolume;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderEffect;

    [SerializeField] private Toggle onMusicBackground;
    [SerializeField] private Toggle onMusicEffect;
    MusicController musicController;

    private void Awake()
    {
        musicController = MusicController.instance;

        //MusicController.instance.effectMixer.SetFloat("EffectGroup", sliderVolume.value);
        //MusicController.instance.BackgroundSource.volume = sliderMusic.value;
        //for (int i = 0; i < MusicController.instance.EffectSours.Length; i++)
        //{
        //    MusicController.instance.EffectSours[i].volume = sliderEffect.value;
        //}
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void ChangeVolume(float value)
    {
        musicController.MusicMixer.SetFloat("Master", value);

    }

    public void ChangeValueMusic(float value)
    {
        musicController.MusicMixer.SetFloat("Background", value);
    }

    public void ChangeValueEffect(float value)
    {
        //for (int i = 0; i < musicController.EffectSours.Length; i++)
        //{
        //    musicController.EffectSours[i].volume = value;
        //}
        musicController.MusicMixer.SetFloat("Effect", value);
    }

    public void MuteMusic(bool  mute)
    {
        musicController.BackgroundSource.mute = mute;
    }

    public void MuteEffect(bool mute)
    {
        for (int i = 0; i < musicController.EffectSours.Length; i++)
        {
            musicController.EffectSours[i].mute = mute;
        }
    }

    public void PlaySoundEffect()
    {
        musicController.EffectSours[0].Play();
    }

    public void ClearFloat()
    {
        musicController.MusicMixer.ClearFloat("Master");
    }
}
