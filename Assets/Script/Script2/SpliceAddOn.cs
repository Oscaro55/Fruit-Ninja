using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
[RequireComponent(typeof(SpliceSpriteController))]
public abstract class SpliceAddOn : MonoBehaviour
{
    protected SpliceSpriteController spliceSpriteController;
    // Use this for initialization
    void Start()
    {
        spliceSpriteController = GetComponent<SpliceSpriteController>();
    }

    public abstract void OnFragmentsGenerated(List<GameObject> fragments);
}
