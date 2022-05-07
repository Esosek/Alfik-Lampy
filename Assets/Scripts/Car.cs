using UnityEngine;

public class Car : MonoBehaviour
{
    public Sound carSound;

    public void SoundOn()
    {
        AudioManager.instance.Play(carSound);
    }

    public void SoundOff()
    {
        AudioManager.instance.Stop(carSound);
        this.gameObject.SetActive(false);
    }
}
