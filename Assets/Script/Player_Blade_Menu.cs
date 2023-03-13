using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Blade_Menu : MonoBehaviour
{
    public CircleCollider2D col;
    public SpriteRenderer Spr;
    private bool canPlay;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay)
        {
            if (Input.touchCount > 0)
            {
                col.enabled = true;
                Spr.color = new Color(1, 0.2028f, 0.2028f, 1);
            }
            if (Input.touchCount == 0)
            {
                col.enabled = false;
                Spr.color = new Color(0, 0, 0, 0);
            }

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = pos;
        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(6);
        canPlay = true;
    }
}
