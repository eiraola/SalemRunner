using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
