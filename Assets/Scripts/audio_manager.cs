using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_manager : MonoBehaviour
{
    public AudioSource death;
    public AudioSource theme;
    public AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        theme.Play();
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void playShatterSound()
    {
        death.Play();
    }

    public void playClickSound()
    {
        click.Play();
    }

    public void pauseTheme()
    {
        theme.Pause();
    }

    public void unpauseTheme()
    {
        theme.UnPause();
    }
}
