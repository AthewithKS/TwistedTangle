using UnityEngine;
using UnityEngine.UI;

public class UISoundController : MonoBehaviour
{
    public Slider _musicController, _sfxController;

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }
    public void ToggleSfx()
    {
        AudioManager.Instance.ToggleSfx();
    }
    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicController.value);
    }
    public void SfxVolume()
    {
        AudioManager.Instance.SFXvolume(_sfxController.value);
    }
}
