using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RandomPokemon : MonoBehaviour
{

    public bool getPkmn;
    public int pkmn;
    public List<GameObject> pokemon = new List<GameObject>();
    private int[] chosenPkmn = new int[4];
    private string theCorrectPokemon;
    private int tmp;
    public GameObject btn1, btn2, btn3, btn4, startBtn;
    private bool shown, done;

    public AudioClip wrong, correct, who;

    // Use this for initialization
    void Start()
    {
        startBtn.SetActive(false);

        Random.seed = (int)System.DateTime.Now.Ticks;
        tmp = 0;
        //Fills the list with pokemon
        foreach (Transform child in transform)
        {

            pokemon.Add(child.gameObject);
            tmp++;
        }

        //Fill the array with a random number other than 0-3
        for (int i = 0; i < 4; i++)
        {
            chosenPkmn[i] = 33;
        }
        //Setting pkmn to the same value to make the loop start
        pkmn = 33;
    }

    public void button1()
    {

        if (btn1.GetComponentInChildren<Text>().text == theCorrectPokemon)
        {

            foreach (Transform child in transform)
            {
                if (child.name == theCorrectPokemon)
                {
                    if (shown)
                    {
                        GetComponentInChildren<ChangeFromBlack>().guess = true;
                        GetComponentInChildren<ChangeFromBlack>().notSwitched = true;
                        child.gameObject.SetActive(false);
                        getPkmn = true;

                    }

                    if (!shown)
                    {
                        GetComponentInChildren<ChangeFromBlack>().guess = true;
                        GetComponentInChildren<ChangeFromBlack>().notSwitched = true;

                        audio.PlayOneShot(correct);
                        
                        shown = true;
                    }
                }

            }
            GetComponent<Timer>().RunStop();

        }
        else
        {
            audio.PlayOneShot(wrong);
            Handheld.Vibrate();
        }
    }
    public void button2()
    {
        if (btn2.GetComponentInChildren<Text>().text == theCorrectPokemon)
        {

            foreach (Transform child in transform)
            {
                if (child.name == theCorrectPokemon)
                {
                    if (shown)
                    {
                        GetComponentInChildren<ChangeFromBlack>().guess = true;
                        GetComponentInChildren<ChangeFromBlack>().notSwitched = true;
                        child.gameObject.SetActive(false);
                        getPkmn = true;
                    }

                    if (!shown)
                    {
                        GetComponentInChildren<ChangeFromBlack>().guess = true;
                        GetComponentInChildren<ChangeFromBlack>().notSwitched = true;

                        audio.PlayOneShot(correct);
                        
                        shown = true;
                    }
                }
            }
            GetComponent<Timer>().RunStop();
        }
        else
        {
            audio.PlayOneShot(wrong);
            Handheld.Vibrate();
        }
    }
    public void button3()
    {
        if (btn3.GetComponentInChildren<Text>().text == theCorrectPokemon)
        {

            foreach (Transform child in transform)
            {
                if (child.name == theCorrectPokemon)
                {
                    if (shown)
                    {
                        GetComponentInChildren<ChangeFromBlack>().guess = true;
                        GetComponentInChildren<ChangeFromBlack>().notSwitched = true;

                        child.gameObject.SetActive(false);
                        getPkmn = true;

                    }

                    if (!shown)
                    {
                        GetComponentInChildren<ChangeFromBlack>().guess = true;
                        GetComponentInChildren<ChangeFromBlack>().notSwitched = true;

                        audio.PlayOneShot(correct);
                        
                        shown = true;
                    }
                }



            }
            GetComponent<Timer>().RunStop();

        }
        else
        {
            audio.PlayOneShot(wrong);
            Handheld.Vibrate();
        }
    }
    public void button4()
    {
        if (btn4.GetComponentInChildren<Text>().text == theCorrectPokemon)
        {

            foreach (Transform child in transform)
            {
                if (child.name == theCorrectPokemon)
                {
                    if (shown)
                    {
                        GetComponentInChildren<ChangeFromBlack>().guess = true;
                        GetComponentInChildren<ChangeFromBlack>().notSwitched = true;
                        child.gameObject.SetActive(false);
                        getPkmn = true;
                    }

                    if (!shown)
                    {
                        GetComponentInChildren<ChangeFromBlack>().guess = true;
                        GetComponentInChildren<ChangeFromBlack>().notSwitched = true;

                        audio.PlayOneShot(correct);
                        
                        shown = true;
                    }
                }
            }
            GetComponent<Timer>().RunStop();
        }
        else
        {
            audio.PlayOneShot(wrong);
            Handheld.Vibrate();
        }
    }

    void Update()
    {
        //If the getPkmn bool is true, fill array with random numbers from 0 to 11.
        if (getPkmn)
        {
            shown = false;

            //The loop loops 4 times, as we need 4 pokemon at a time.
            for (int i = 0; i < 4; i++)
            {
                //Randomly finds a new number, as long as the new number dosen't exist in the array
                while (pkmn == chosenPkmn[0] || pkmn == chosenPkmn[1] || pkmn == chosenPkmn[2] || pkmn == chosenPkmn[3])
                {
                    pkmn = (int)Random.Range(0, 12);
                }
                //Sets the slot in the array
                chosenPkmn[i] = pkmn;
            }
            //Randomly choses a pokemon from the 4 found before
            int tmp = (int)Random.Range(0, 3);
            //Activates the chosen pokemon
            pokemon[chosenPkmn[tmp]].SetActive(true);
            theCorrectPokemon = pokemon[chosenPkmn[tmp]].name;

            //Fills the button texts with the chosen pokemon names
            btn1.GetComponentInChildren<Text>().text = pokemon[chosenPkmn[0]].name;
            btn2.GetComponentInChildren<Text>().text = pokemon[chosenPkmn[1]].name;
            btn3.GetComponentInChildren<Text>().text = pokemon[chosenPkmn[2]].name;
            btn4.GetComponentInChildren<Text>().text = pokemon[chosenPkmn[3]].name;

            //Makes to bool to false so this update only runs once every time it's needed
            getPkmn = false;
        }
    }
}
