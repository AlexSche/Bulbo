using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    void Start()
    {
        setMusic();
        setSFX();
    }

    public void setMusic()
    {
        float musicVolume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log(musicVolume) * 20);
    }

    public void setSFX()
    {
        float sfxVolume = sfxSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log(sfxVolume) * 20);
    }
}
