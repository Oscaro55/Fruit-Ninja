using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeController : MonoBehaviour
{
    public static ShapeController instance;
    public int numberShapePerfect = 0;
    public bool isEndTurn = false;
    public GameObject spriteShape;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        spriteShape = this.gameObject;
    }
    void Start()
    {
        //StartCoroutine(NewTurn());
    }

    // Update is called once per frame
   public void SetupPerfect()
    {
        if (isEndTurn == false)
        {
            for (int i = 0; i < SpliceSpriteController.instance.listChildSprite.Count; i++)
            {
                if (SpliceSpriteController.instance.listChildSprite[i].GetComponent<RotateObject>().angle <= 5)
                {
                    if (numberShapePerfect < 19)
                    {
                        numberShapePerfect++;
                        Debug.Log(numberShapePerfect);
                        //Debug.Log(SpliceSpriteController.instance.listChildSprite[i].GetComponent<RotateObject>().angle);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    numberShapePerfect = 0;
                    //StartCoroutine(NewTurn());
                    break;
                }

            }
            if (numberShapePerfect == SpliceSpriteController.instance.listChildSprite.Count)
            {
                isEndTurn = true;
                GameController.instance.effect.SetActive(true);
                GameController.instance.effect.GetComponent<ParticleSystem>().Play();
                for (int i = 0; i < SpliceSpriteController.instance.listChildSprite.Count; i++)
                {
                    //SpliceSpriteController.instance.listChildSprite[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    SpliceSpriteController.instance.listChildSprite[i].SetActive(false);
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                }

                Debug.Log("Da win: " + numberShapePerfect);
            }
            else
            {
                numberShapePerfect = 0;
                isEndTurn = false;
            }
        }
    }
    IEnumerator CreatEffect()
    {

        for(int i = 0; i< 1; i++)
        {
            GameController.instance.effect.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            GameController.instance.effect.GetComponent<ParticleSystem>().Play();

        }
    }
}
