using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Button : MonoBehaviour
{
    public Animator anim;
    public GameObject PlayLeg;
    public GameObject QuitLeg;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Quit()
    {
        StopAllCoroutines();
        StartCoroutine(QuitGame());
        anim.SetTrigger("Leave");
        PlayLeg.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Flute");
    }

    public void Play()
    {
        StopAllCoroutines();
        StartCoroutine(LoadScene());
        anim.SetTrigger("Leave");
        QuitLeg.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Flute");
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3.4f);
        SceneManager.LoadScene(1);
    }

    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(3.4f);
        Application.Quit();
    }
}
