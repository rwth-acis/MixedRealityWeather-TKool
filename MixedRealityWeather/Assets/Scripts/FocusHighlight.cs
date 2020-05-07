using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

public class FocusHighlight : MonoBehaviour, IMixedRealityFocusHandler
{
    private Color startColor;
    public Color FocusColor;
    public static Renderer backgorundRenderer;
    private Material material;

    void Start()
    {
        startColor = backgorundRenderer.material.color;
    }

    public void OnFocusEnter(FocusEventData eventData)
    {
        backgorundRenderer.material.color = FocusColor; 
    }
   public void OnFocusExit(FocusEventData eventData)
    {
        backgorundRenderer.material.color = startColor;
    }
}