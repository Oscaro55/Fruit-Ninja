using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSceneGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButtonHin()
    {
       
        ShapeController.instance.spriteShape.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
    }
}
