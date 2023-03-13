using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreatFragments : SpliceAddOn
{
    public override void OnFragmentsGenerated(List<GameObject> fragments)
    {
        foreach (GameObject fragment in fragments)
        {
            SpliceSpriteController frag = fragment.AddComponent<SpliceSpriteController>();
            frag.fragmentLayer = spliceSpriteController.fragmentLayer;
            frag.sortingLayerName = spliceSpriteController.sortingLayerName;
            frag.orderInLayer = spliceSpriteController.orderInLayer;
            fragment.layer = spliceSpriteController.gameObject.layer;

            frag.fragmentInEditor();
        }
    }
}
