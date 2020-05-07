using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

public class FocusHighlight : MonoBehaviour, IMixedRealityFocusHandler
{
   //private Color color;
    private Color startColor;
    private static Renderer rend;
    private Material material;

    void OnPointerSelected(FocusEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public static void saveColor(Color startColor)
    {
        startColor = rend.material.color;
        //toString
        //Button.color = startcolor;
        //PlayerPrefs.SetString("Default Color", Color.blue.ToString());
        //startcolor = PlayerPrefs.GetString("Default Color");
    }

    public void OnFocusEnter(FocusEventData eventData)
    {
        //startcolor = rend.material.color;
        rend.material.color = Color.yellow; 
    }
   public void OnFocusExit(FocusEventData eventData)
    {
        rend.material.color = startColor;
    }
}