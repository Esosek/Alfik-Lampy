using UnityEngine;
using UnityEngine.SceneManagement;

public class LampManager : MonoBehaviour
{
    public int switchesTillBreak = 6;
    public GameObject doubleLampBulb1, doubleLampBulb2, highLampBulb, flatLampBulb, brokenLampBulb, moon, car;
    public GameObject doubleLampLight1, doubleLampLight2, highLampLight, flatLampLight;
    public GameObject rainObject, rainDropsObject;
    public Material whiteLight, yellowLight, glass, basic;
    public KeyCode doubleLampKey, highLampKey, flatLampKey, rainKey, switchAllKey, moonKey, carKey;
    public Sound breakLampSound, rainSound;

    int doubleLampSwitched = 0;
    bool rainActive = true;
    bool doubleLampActive = true;
    bool highLampActive = true;
    bool flatLampActive = true;
    bool moonActive = true;

    private void Start()
    {
        AudioManager.instance.Play(rainSound);
    }

    private void Update()
    {
        if (Input.GetKeyUp(doubleLampKey))
        {
            SwitchDoubleLamp();
        }
        else if (Input.GetKeyUp(highLampKey))
        {
            SwitchHighLamp();
        }
        else if (Input.GetKeyUp(flatLampKey))
        {
            SwitchFlatLamp();
        }
        else if (Input.GetKeyUp(rainKey))
        {
            SwitchRain();
        }
        else if (Input.GetKeyUp(switchAllKey))
        {
            SwitchDoubleLamp();
            SwitchHighLamp();
            SwitchFlatLamp();
        }
        else if (Input.GetKeyUp(moonKey))
        {
            SwitchMoon();
        }
        else if (Input.GetKeyUp(carKey))
        {
            car.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SwitchDoubleLamp()
    {
        doubleLampSwitched++;

        if (doubleLampSwitched == switchesTillBreak) // break the lamp
        {
            doubleLampBulb2.SetActive(false);
            doubleLampLight2.SetActive(false);
            brokenLampBulb.SetActive(true);
            AudioManager.instance.Play(breakLampSound);
        }

        if (doubleLampActive)
        {
            // zhasni
            doubleLampActive = false;
            doubleLampLight1.SetActive(false);
            doubleLampBulb1.GetComponent<Renderer>().sharedMaterial = glass;

            if (doubleLampSwitched >= switchesTillBreak) return;

            doubleLampLight2.SetActive(false);
            doubleLampBulb2.GetComponent<Renderer>().sharedMaterial = glass;
        }

        else
        {
            // rozsvit
            doubleLampActive = true;
            doubleLampLight1.SetActive(true);
            doubleLampBulb1.GetComponent<Renderer>().sharedMaterial = yellowLight;

            if (doubleLampSwitched >= switchesTillBreak) return;

            doubleLampLight2.SetActive(true);
            doubleLampBulb2.GetComponent<Renderer>().sharedMaterial = yellowLight;
        }

        

        

    }

    void SwitchHighLamp()
    {
        if (highLampActive)
        {
            // zhasni
            highLampActive = false;
            highLampLight.SetActive(false);
            var mats = highLampBulb.GetComponent<Renderer>().materials;
            mats[1] = glass;
            highLampBulb.GetComponent<Renderer>().materials = mats;
        }

        else {
            // rozsvit
            highLampActive = true;
            highLampLight.SetActive(true);
            var mats = highLampBulb.GetComponent<Renderer>().materials;
            mats[1] = whiteLight;
            highLampBulb.GetComponent<Renderer>().materials = mats;
        }
    }

    void SwitchFlatLamp()
    {
        if (flatLampActive)
        {
            // zhasni
            flatLampActive = false;
            flatLampLight.SetActive(false);
            var mats = flatLampBulb.GetComponent<Renderer>().materials;
            mats[1] = glass;
            flatLampBulb.GetComponent<Renderer>().materials = mats;
        }

        else
        {
            // rozsvit
            flatLampActive = true;
            flatLampLight.SetActive(true);
            var mats = flatLampBulb.GetComponent<Renderer>().materials;
            mats[1] = yellowLight;
            flatLampBulb.GetComponent<Renderer>().materials = mats;
        }
    }

    void SwitchRain()
    {
        if (rainActive)
        {
            rainActive = false;
            AudioManager.instance.Stop(rainSound);
            rainObject.GetComponent<ParticleSystem>().Stop();
            rainDropsObject.GetComponent<ParticleSystem>().Stop();
        }
        else
        {
            rainActive = true;
            AudioManager.instance.Play(rainSound);
            rainObject.GetComponent<ParticleSystem>().Play();
            rainDropsObject.GetComponent<ParticleSystem>().Play();
        }
    }

    void SwitchMoon()
    {
        if (moonActive)
        {
            moonActive = false;
            moon.GetComponent<Renderer>().sharedMaterial = basic;
        }
        else
        {
            moonActive = true;
            moon.GetComponent<Renderer>().sharedMaterial = yellowLight;
        }
    }
}
