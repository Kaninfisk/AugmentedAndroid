using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public GameObject slider;
    public Stopwatch localStopwatch;
    public float elapsedSeconds;
    public bool started;
    // Use this for initialization
    void Start()
    {
        localStopwatch = new Stopwatch();

    }

    public void RunStop()
    {
        if (localStopwatch.IsRunning)
        {
            localStopwatch.Stop();
        }
        else
        {
            localStopwatch.Start();
        }

        if (!started)
        {
            GetComponent<RandomPokemon>().audio.PlayOneShot(GetComponent<RandomPokemon>().who);
            started = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        elapsedSeconds = (float)localStopwatch.ElapsedMilliseconds / 1000;
        slider.GetComponent<Slider>().value = elapsedSeconds;
    }
}
