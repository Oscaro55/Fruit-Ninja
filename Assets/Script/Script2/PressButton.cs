using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressButton : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveDownButton(GameObject gob)
    {

        gob.transform.localScale = new Vector3(gob.transform.localScale.x + 0.1f, gob.transform.localScale.y + 0.1f, 1);
        gob.GetComponentInChildren<Image>().CrossFadeAlpha(0.5f, 0.1f, true);

    }
    public void MoveUpButton(GameObject gob)
    {



        gob.transform.localScale = new Vector3(gob.transform.localScale.x - 0.1f, gob.transform.localScale.y - 0.1f, 1);
        gob.GetComponentInChildren<Image>().CrossFadeAlpha(1f, 0.1f, true);
    }
}
