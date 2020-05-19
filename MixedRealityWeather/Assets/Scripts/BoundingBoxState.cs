using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities.Editor;
using Microsoft.MixedReality.Toolkit.Utilities.Editor.Search;

public class BoundingBoxState : MonoBehaviour
{
    Microsoft.MixedReality.Toolkit.UI.BoundingBox box;
    bool boxState;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<Microsoft.MixedReality.Toolkit.UI.BoundingBox>();
    }

    // Update is called once per frame
    void Update()
    {
        boxState = box.Active;
        if (boxState)
        {
            box.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            box.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
