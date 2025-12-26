using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    [SerializeField] GameObject hover = null;
    public void HoverEnter()
    {
        hover.SetActive(true);
    }

    public void HoverExit()
    {
        hover.SetActive(false);
    }
}
