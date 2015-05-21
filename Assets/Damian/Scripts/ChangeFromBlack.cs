using UnityEngine;
using System.Collections;

public class ChangeFromBlack : MonoBehaviour
{

    public bool guess;
    public bool notSwitched;

    // Use this for initialization
    void Start()
    {
        guess = false;
        notSwitched = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (guess && notSwitched)
        {
            GameObject MyObjName = this.gameObject;
            foreach (Transform child in MyObjName.transform)
            {
                if (child.gameObject.activeSelf)
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
            notSwitched = false;
        }
    }
}
