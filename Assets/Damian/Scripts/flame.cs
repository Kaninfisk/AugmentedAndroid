using UnityEngine;
using System.Collections;

public class flame : MonoBehaviour
{
    int counter;

    // Use this for initialization
    void Start()
    {
        counter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter < 5)
        {
            this.light.intensity = (float)1;
        }
        else if (counter > 5)
        {
            this.light.intensity = (float)1.1;

            if (counter >= 10)
            {
                counter = 0;
            }
        }
        counter++;

    }
}
