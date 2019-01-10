

###  [ `Return | 首页` ](https://github.com/PicoSupport/PicoSupport)
* [AndroidDemo | 安卓](https://github.com/PicoSupport/PicoSupport/blob/master/android.md)
* [UnityDemo | Unity3d](https://github.com/PicoSupport/PicoSupport/blob/master/unity.md)

## Unity_Demo_GetPhoneCameraImageDemo

## Unity_Versions：
- 2017.1.0f3 Or UP

## Explain 说明：

- 功能：访问pico设备前置摄像头

Demo主要C#代码 GetPhoneCameraImageDemo.cs文件

```C#
public class GetPhoneCameraImageDemo : MonoBehaviour
{   
    public RawImage rawImage;
    private string deviceName;
    private WebCamTexture webCam;
    void Start()
    {
        StartCoroutine(Call());
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

```

## Use 使用：
- 场景位置： Assets -> DemoScene -> GetPhoneCameraImageDemo
- 打包Apk文件，在pico设备打开，能够看到摄像头画面

## Announcements 注意事项：
- 本demo适用于PicoGoblin2
- 其他设备使用需要拥有摄像头

## Pico技术支持
欢迎更多地了解我们，如果您有任何问题，请联系我们。
Learn about us, and contact us if you have any questions. 

- Email:  support@picovr.com
- Web:  [https://www.picovr.com/](https://www.picovr.com/)
