using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    public GameManager gm;
    public CameraShake shake;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Legume leg = collision.gameObject.GetComponent<Legume>();
            if (!leg.Cut)
            {
                if (gm.life > 0) gm.life--;
                shake.shaking = true;
                FindObjectOfType<AudioManager>().Play("Hit");
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer != 3) Destroy(collision.gameObject);
    }
}
