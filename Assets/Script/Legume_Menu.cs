using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legume_Menu : MonoBehaviour
{
    public SpliceSpriteController Slice;
    public Sprite[] _Spr;
    public SpriteRenderer _Rend;
    public GameObject[] Splatter;
    private int x;
    private bool Cut;
    public int QuitPlay;
    public Menu_Button menu;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(0, _Spr.Length);
        _Rend.sprite = _Spr[x];
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Cut)
        {
            FindObjectOfType<AudioManager>().PlayRandom("Splash");
            Cut = true;
            Instantiate(Splatter[x], transform.position, Quaternion.identity);
        }

        if (Cut)
        {
            Slice.generateFragments();
            _Rend.color = new Color(0, 0, 0, 0);
            if (collision.gameObject.CompareTag("Player"))
            {
                Transform[] aze = gameObject.GetComponentsInChildren<Transform>();
                foreach (Transform tr in aze)
                {
                    tr.parent = null;
                }
            }
        }

        if (QuitPlay == 0) menu.Play();

        if (QuitPlay == 1) menu.Quit();
    }

}
