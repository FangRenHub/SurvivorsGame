using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelDefaultButton : MonoBehaviour
{
    public Button defaultButton;
    public Button defaultButton2;
    public Button skipButton;

    
    private void OnEnable()
    {
        if (defaultButton.gameObject.activeSelf)
        {
            defaultButton.Select();
        }
        else if (defaultButton2.gameObject.activeSelf)
        {
            defaultButton2.Select();
        }
        else
        {
            skipButton.Select();
        }
    }
}
