using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    public Sprite[] _Spr;
    public SpriteRenderer Rend;
    private float Alpha = 0.8f;
    private Color ColorLeg;
    // Start is called before the first frame update
    void Start()
    {
        Rend.sprite = _Spr[Random.Range(0, _Spr.Length)];
        ColorLeg = Rend.color;
        ColorLeg.a = 0.8f;
        Rend.color = ColorLeg;
    }

    // Update is called once per frame
    void Update()
    {
        if (Alpha > 0) Alpha -= Time.deltaTime * 0.5f;
        ColorLeg.a = Alpha;
        Rend.color = ColorLeg;
        if (Alpha <= 0) Destroy(gameObject);
    }
}
