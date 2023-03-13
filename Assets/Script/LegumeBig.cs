using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegumeBig : MonoBehaviour
{
    public SpliceSpriteController Slice;
    public Sprite[] _Spr;
    public SpriteRenderer _Rend;
    public GameObject[] Splatter;
    public ParticleSystem[] juice; 
    private int x;
    private float rota;
    private int _1or2;
    public bool Cut;
    public int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(0, _Spr.Length);
        _Rend.sprite = _Spr[x];
        _1or2 = Random.Range(1, 3);
        if (_1or2 == 1) rota = Random.Range(-3f, -1f);
        if (_1or2 == 2) rota = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rota);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Cut)
        {
            FindObjectOfType<AudioManager>().PlayRandom("Splash");
            Instantiate(Splatter[x], transform.position, Quaternion.identity);
            Instantiate(juice[x], transform.position, Quaternion.identity);
            if (counter < 10) counter++;
            if (counter >=10) Cut = true;
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
    }

}
