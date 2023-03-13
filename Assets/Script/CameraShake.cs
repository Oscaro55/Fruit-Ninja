using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject Bomb;
    public float duration;
    public float magnitude;
    public bool shaking = false;
    private bool once;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 originalPos = transform.position;
        if (shaking && !once)
        {
            once = true;
            StartCoroutine(Shake(duration, magnitude));
        }

        if (!shaking) transform.position = new Vector3(0, 0, -10);
    }

    IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;
        float elapsed = 0;
        while (elapsed < duration)
        {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;

            transform.position = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.position = originalPos;
        shaking = false;
        once = false;
        yield return null;

    }
}
