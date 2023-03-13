using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(HideEffect());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator HideEffect()
    {
        yield return new WaitForSeconds(1f);
        GameObject[] _eff = GameObject.FindGameObjectsWithTag("effect");
        for(int i = 0; i < _eff.Length; i++)
        {
            Destroy(_eff[i], 1f);

        }
    }
}
