using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Blade : MonoBehaviour
{
    public CircleCollider2D col;
    public SpriteRenderer Spr;
    public int _ComboValue;
    public float _ComboTimer;
    public TextMeshProUGUI Combo;
    public TextMeshProUGUI Score;
    public int _Score;
    public Transform[] positions;
    private bool once;
    private Legume LastLeg;
    private float alpha = 1;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.touchCount > 0)
        {
            col.enabled = true;
            Spr.color = new Color(1, 0.2028f, 0.2028f, 1);
        }
        if (Input.touchCount == 0)
        {
            col.enabled = false;
            Spr.color = new Color(0, 0, 0, 0);
        }*/

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;

        if (_ComboTimer > 0)
        {
            _ComboTimer -= Time.deltaTime;
            Combo.color = new Color(0.2832413f, 0.4467165f, 0.6320754f, alpha);
            alpha = _ComboTimer;
            once = true;
        }
        if (_ComboTimer <= 0)
        {
            if (once)
            {
                _Score += _ComboValue * 20 * (_ComboValue / 2);
                Score.text = ("Score : " + _Score);
                Combo.transform.position = positions[Random.Range(0, positions.Length)].position;
                Combo.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-10f, 10f));
                once = false;
                _ComboValue = 0;
                Combo.text = ("");
                alpha = 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Legume leg = collision.GetComponent<Legume>();
            if (LastLeg == null || leg != LastLeg)
            {
                if (_ComboValue >= 1) FindObjectOfType<AudioManager>().PlayPitch("Combo", 0.8f + _ComboValue/5);
                _ComboTimer = 1.25f;
                _ComboValue++;
                _Score += 10;
                alpha = 1;
                Score.text = ("Score : " + _Score);
                if (_ComboValue >= 2)
                {
                    Combo.text = ("Combo " + _ComboValue + " !");
                }
                LastLeg = leg;
            }
        }
    }
}
