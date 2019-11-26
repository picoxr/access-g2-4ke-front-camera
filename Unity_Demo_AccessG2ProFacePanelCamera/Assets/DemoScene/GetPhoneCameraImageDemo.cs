using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPhoneCameraImageDemo : MonoBehaviour
{   
    public RawImage rawImage;
    /// <summary>
    /// 设备名字
    /// </summary>
    private string deviceName;
    private WebCamTexture webCam;
    
    void Start()
    {
        StartCoroutine(Call());
    }
	
	// Update is called once per frame
	void Update () {
		
	}    

    public IEnumerator Call()
    {
        // Apply for permission 征求许可
        //UserAuthorization.WebCam 用户授权 摄像机 请求用户授权
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            // Get camera device 设备安装摄像头
            WebCamDevice[] devices = WebCamTexture.devices;

            // get the first camera name 获得第一个相机名
            deviceName = devices[0].name;

            // create a WebCamTexture 创建一个WebCamTexture
            webCam = new WebCamTexture(deviceName, Screen.width, Screen.height, 60);

            // set the texture to rawImage in the scene 在场景中设置纹理为rawImage
            rawImage.texture = webCam;
           
            // enable camera
            webCam.Play();
        }
    }
}
