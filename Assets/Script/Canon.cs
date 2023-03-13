using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject _Legume;
    public GameObject Bomb;
    private float _OffSet;
    private float _Str;
    public float _StrMin;
    public float _StrMax;
    public float _angleMin;
    public float _angleMax;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }*/
    }

    public void Launch()
    {
        _OffSet = Random.Range(_angleMin, _angleMax);
        _Str = Random.Range(_StrMin, _StrMax);

        if (Random.Range(0, 10) != 9)
        {
            if (Random.Range(0, 3) == 0)
            {
                FindObjectOfType<AudioManager>().Play("Woosh1");
            }
            if (Random.Range(0, 3) == 1)
            {
                FindObjectOfType<AudioManager>().Play("Woosh2");
            }
            if (Random.Range(0, 3) == 2)
            {
                FindObjectOfType<AudioManager>().Play("Woosh3");
            }
            var GO = Instantiate(_Legume, transform.position, Quaternion.Euler(0, 0, transform.localEulerAngles.z + _OffSet));
            GO.layer = 3;
            var rb = GO.GetComponent<Rigidbody2D>();
            rb.AddForce(GO.transform.up * _Str, ForceMode2D.Impulse);
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Woosh1");
            var GO = Instantiate(Bomb, transform.position, Quaternion.Euler(0, 0, transform.localEulerAngles.z + _OffSet));
            GO.layer = 4;
            var rb = GO.GetComponent<Rigidbody2D>();
            rb.AddForce(GO.transform.up * _Str, ForceMode2D.Impulse);
        }

    }
}
