using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputManger : MonoBehaviour
{

    //所有数值根据实际情况进行计算
    public RectTransform rawImage;
    public RectTransform Images;
    public Vector2 vector;
    public Vector2 vector2;
    private void Awake()
    {
        vector = rawImage.sizeDelta;
        vector2 = Images.sizeDelta;

    }
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        PicoInput();
    }
    public void PicoInput()
    {
         
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("1");
            //设定最大放大倍率
            if (vector.x >= (vector2.x + (18 * 10)) || vector.y >= (vector2.y + (26 * 10)))
            {
                Debug.Log("2");
                return;
            }
            rawImage.sizeDelta = new Vector2(vector.x +18, vector.y +26);
            vector = rawImage.sizeDelta;
       
        }
        else if(Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            //判断最小照片大小
            if(vector.x-18==vector2.x|| vector.y-26==vector2.y)
            {
                return;
            }


            rawImage.sizeDelta = new Vector2(vector.x -18, vector.y -26);
            vector = rawImage.sizeDelta;
        }
    }
}
