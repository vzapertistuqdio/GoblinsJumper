using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientation : MonoBehaviour
{
    public Vector2 DefaultResolution = new Vector2(x: 720, y: 1280);

    [Range(0, 1f)] public float widthOrHeight = 0;
    private float initialsize;
    private float targetaspect;

    private float initialFov;
    private float horizontalFov = 120;

    private Camera componentCamera;

   
    private void Start()
    {
        Screen.orientation = UnityEngine.ScreenOrientation.Portrait;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        componentCamera = GetComponent<Camera>();
        initialsize = componentCamera.orthographicSize;

        targetaspect = DefaultResolution.x / DefaultResolution.y;

        initialFov = componentCamera.fieldOfView;
        horizontalFov = CalcVertFov(initialFov, 1 / targetaspect);
    }

 
    void Update()
    {
        if(componentCamera.orthographic)
        {
            float constanWidthSize = initialsize * (targetaspect / componentCamera.aspect);
            componentCamera.orthographicSize = Mathf.Lerp(constanWidthSize, initialsize, widthOrHeight);
        }
        else
        {
            float constanWidthFov = CalcVertFov(horizontalFov,componentCamera.aspect);
            componentCamera.fieldOfView = Mathf.Lerp(constanWidthFov,initialFov,widthOrHeight);
        }
    }
    private float CalcVertFov(float hFovInDeg,float aspectRatio)
    {
        float hFovInRads = hFovInDeg * Mathf.Deg2Rad;
        float vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads/2)/aspectRatio);
        return vFovInRads * Mathf.Rad2Deg;
    }
   
}
