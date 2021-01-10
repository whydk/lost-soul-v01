using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColor : MonoBehaviour
{
    public Color color;
    public Light lightSpot;
    public bool changeColor;
    Color defColor;

    private void Awake()
    {
        defColor = lightSpot.color;
        lightSpot.enabled = false;
    }
    private void Update()
    {
        if (changeColor)
        {
            ChangeColor();
        }
        else
        {
            lightSpot.color = defColor;
        }
    }
    public void ChangeColor()
    {
        lightSpot.color = color;
    }
    public void TurnOnLight()
    {
        lightSpot.enabled = true;
    }
}
