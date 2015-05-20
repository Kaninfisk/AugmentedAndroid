using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RandomPokemon : MonoBehaviour
{

    public bool getPkmn;
    public int pkmn;
    private int[] chosenPkmn = new int[4];
    public Text btn1, btn2, btn3, btn4;

    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < 4; i++)
        {
            chosenPkmn[i] =33;
        }
        pkmn = 33;


    }

    // Update is called once per frame
    void Update()
    {

        if (getPkmn)
        {
            for (int i = 0; i < 4; i++)
            {
                while (pkmn == chosenPkmn[0] || pkmn == chosenPkmn[1] || pkmn == chosenPkmn[2] || pkmn == chosenPkmn[3])
                {
                    pkmn = (int)Random.Range(0, 11);
                }

                chosenPkmn[i] = pkmn;
            }

            btn1.text = chosenPkmn[0].ToString();
            btn2.text = chosenPkmn[1].ToString();
            btn3.text = chosenPkmn[2].ToString();
            btn4.text = chosenPkmn[3].ToString();



            getPkmn = false;
        }

    }
}
