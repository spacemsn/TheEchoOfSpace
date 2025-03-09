using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private float MusicValue;
    private float EffectValue;
    private bool onMusicToogle;
    private bool onEffectToogle;

    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderEffect;

    [SerializeField] private Toggle onMusicBackground;
    [SerializeField] private Toggle onMusicEffect;
    

    private void Awake()
    {
        MusicController.instance.BackgroundSource.volume = sliderMusic.value;
        //for (int i = 0; i < MusicController.instance.EffectSours.Length; i++)
        //{
        //    MusicController.instance.EffectSours[i].volume = sliderEffect.value;
        //}
        MusicController.instance.effectMixer.SetFloat("EffectGroup", sliderEffect.value);
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void ChangeValueMusic(float value)
    {
        MusicController.instance.BackgroundSource.volume = value;
    }

    public void ChangeValueEffect(float value)
    {
        //for (int i = 0; i < MusicController.instance.EffectSours.Length; i++)
        //{
        //    MusicController.instance.EffectSours[i].volume = value;
        //}

        MusicController.instance.effectMixer.SetFloat("EffectGroup", value);  
    }

    public void MuteMusic(bool  mute)
    {
        MusicController.instance.BackgroundSource.mute = mute;
    }

    public void MuteEffect(bool mute)
    {
        for (int i = 0; i < MusicController.instance.EffectSours.Length; i++)
        {
            MusicController.instance.EffectSours[i].volume = sliderEffect.value;
        }
    }

    public void PlaySoundEffect()
    {
        MusicController.instance.EffectSours[0].Play();
    }
}
