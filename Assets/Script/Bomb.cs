using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private GameManager gm;
    private Player_Blade player;
    public ParticleSystem FX;
    private int _1or2;
    private float rota;
    public CameraShake shake;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        shake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        player = GameObject.Find("Cursor").GetComponent<Player_Blade>();
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

        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Explosion");
            FindObjectOfType<AudioManager>().Play("Hit");
            shake.shaking = true;
            gm.life--;
            player._ComboTimer = 0;
            Instantiate(FX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
