using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

public class FocusHighlight : MonoBehaviour, IMixedRealityFocusHandler
{
    private Color startColor;
    public Color focusColor;
    public Renderer backgorundRenderer;

    void Start()
    {
        startColor = backgorundRenderer.material.color;
        //GetComponentInChildren<Renderer>().material.color;
    }

    public void OnFocusEnter(FocusEventData eventData)
    {
        //GetComponentInChildren<Renderer>().material.color = focusColor;
        backgorundRenderer.material.color = focusColor; 
    }

   public void OnFocusExit(FocusEventData eventData)
    {
        //GetComponentInChildren<Renderer>().material.color = startColor;
        backgorundRenderer.material.color = startColor;
    }
}