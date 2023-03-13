using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] Canons;
    public Player_Blade player;
    public Animator[] anim;
    private Canon _launcher;
    public float _MinWait;
    public float _MaxWait;
    public float _FireRate;
    private float _Wait;
    private bool hard = false;
    private float _HardMultiply;
    private int x;
    public int life;
    public Image[] Life_Spr;
    private bool playing = false;
    public GameObject GameOver;
    public TextMeshPro Score;
    public int counter;
    public int nb;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.9f;
        StartCoroutine(play());
    }

    // Update is called once per frame
    void Update()
    {
        if (life == 2)
        {
            Destroy(Life_Spr[2], 1.2f);
            anim[2].SetTrigger("Hit");

        }
        if (life == 1)
        {
            Destroy(Life_Spr[1], 1.2f);
            anim[1].SetTrigger("Hit");

        }
        if (life == 0)
        {
            Destroy(Life_Spr[0], 1.2f);
            anim[0].SetTrigger("Hit");
            StartCoroutine(GameOVer());
            GameOver.SetActive(true);
            Score.text = ("Score : " + player._Score);
            player.Score.text = ("");
            StartCoroutine(Transi());
        }


        if (!hard)
        {
            _HardMultiply = 1;
        }

        if (hard)
        {
            _HardMultiply = 1.5f;
        }

        if (playing)
        {
            Survival();

            if (counter % 10 == 0)
            {
                nb = Random.Range(1, 5);
                counter++;
            }

            burst();
        }

        //invoke
        //invokeRepeating

    }

    public void Play()
    {

    }

    public void Quit()
    {

    }

    void Survival()
    {
        if (_Wait > 0)
        {
            _Wait -= Time.deltaTime;
        }
        if (_Wait <= 0)
        {
            _FireRate = Random.Range(_MinWait / _HardMultiply, _MaxWait / _HardMultiply);
            x = Random.Range(0, Canons.Length);
            _launcher = Canons[x].GetComponent<Canon>();
            _launcher.Launch();
            _Wait = _FireRate;
            counter++;
        }
    }

    void burst()
    {
        if (nb > 0)
        {
            int y = Random.Range(0, Canons.Length);
            _launcher = Canons[y].GetComponent<Canon>();
            _launcher.Launch();
            nb--;
            print(nb);
        }

    }

    IEnumerator play()
    {
        yield return new WaitForSeconds(0.75f);
        playing = true;
    }

    IEnumerator GameOVer()
    {
        yield return new WaitForSeconds(0.75f);
        playing = false;
    }

    IEnumerator Transi()
    {
        yield return new WaitForSeconds(5.5f);
        SceneManager.LoadScene(0);
    }
}
