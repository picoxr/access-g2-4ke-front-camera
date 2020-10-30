using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputManger : MonoBehaviour
{

  
    public RectTransform rawImage;
    public RectTransform Images;
    public Vector2 rawImagevector;
    public Vector2 Imagesvector;


    //Every time I scale it
    public float ImagesvectorHeight;
    public float ImagesvectorWidth;



    //The number of times you can press it
    public int number = 10;



    private void Awake()
    {
        rawImagevector = rawImage.sizeDelta;
        Imagesvector = Images.sizeDelta;
        ImagesvectorHeight = Images.rect.height/10;
        ImagesvectorWidth = Images.rect.width/10;
      

    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        PicoInput();
    }
    public void PicoInput()
    {
         
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            //Determine whether the maximum multiple is reached
            if (rawImagevector.x >= (Imagesvector.x + (ImagesvectorWidth * number)) || rawImagevector.y >= (Imagesvector.y + (ImagesvectorHeight * number)))
            {
               
                return;
            }
            rawImage.sizeDelta = new Vector2(rawImagevector.x + ImagesvectorWidth, rawImagevector.y + ImagesvectorHeight);
            rawImagevector = rawImage.sizeDelta;
       
        }
        else if(Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            //Determine if minification is disabled
            if (rawImagevector.x == Imagesvector.x|| rawImagevector.y == Imagesvector.y)
            {
                return;
            }


            rawImage.sizeDelta = new Vector2(rawImagevector.x - ImagesvectorWidth, rawImagevector.y - ImagesvectorHeight);
            rawImagevector = rawImage.sizeDelta;
        }
    }
}
