using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities.Editor;
using Microsoft.MixedReality.Toolkit.Utilities.Editor.Search;

public class BoundingBoxState : MonoBehaviour
{
    public Microsoft.MixedReality.Toolkit.UI.BoundingBox box;
    bool boxState;

    // Start is called before the first frame update
    void Start()
    {
      boxState= box.Active;
    }

    // Update is called once per frame
    void Update()
    {
        if (boxState)
        {
            box.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            box.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
