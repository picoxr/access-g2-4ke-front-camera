using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InputManger : MonoBehaviour
{  
    public RectTransform rawImage;
    public RectTransform Image;
    public Vector2 RawImageVector;
    public Vector2 ImageVector;
    
    //zoom in/out scale
    private float ScaleHeight;
    private float ScaleWidth;
    private Vector2 AddScale;
    private int IsClick=0;

    
    private const int KEY_COUNTER = 10;



    private void Awake()
    {
        RawImageVector = rawImage.sizeDelta;
        ImageVector = Image.sizeDelta;
        ScaleHeight = Image.rect.height/10;
        ScaleWidth = Image.rect.width/10;
    }

    private void Update()
    {      
        PicoInput();
    }
    public void PicoInput()
    {
       
        // Press Back button on HMD 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsClick==KEY_COUNTER)
            {
                return;
            }
            if (IsClick < KEY_COUNTER)
            {
                IsClick += 1;
                AddScale.Set(RawImageVector.x + ScaleWidth, RawImageVector.y + ScaleHeight);
                rawImage.sizeDelta = AddScale;
                RawImageVector = rawImage.sizeDelta;
            }
         
        }
        // Press Confirm button on HMD 
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (IsClick == 0)
            {
                return;
            }           
            if (IsClick>0)
            {
                IsClick -= 1;
                AddScale.Set(RawImageVector.x - ScaleWidth, RawImageVector.y - ScaleHeight);
                rawImage.sizeDelta = AddScale;
                RawImageVector = rawImage.sizeDelta;
            }
        }
    }
}
