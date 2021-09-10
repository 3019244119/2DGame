using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Transform player;//获得角色
    public Vector2 Margin;//相机与角色的相对范围
    public Vector2 smoothing;//相机移动的平滑度
    public float camera_x;
    public float camera_y;
    public float player_x;
    public float player_y;


    private Vector3 _min;//边界最大值
    private Vector3 _max;//边界最小值

    public bool IsFollowing { get; set; }//用来判断是否跟随

    void Start()
    {
        _max = new Vector3(69.61f, 7.76f, -24f);//初始化边界最小值(边界左下角)
        _min = new Vector3(-9.17f, -6f, -24f);//初始化边界最大值(边界右上角)
        IsFollowing = true;//默认为跟随
    }

    void Update()
    {
        camera_x = transform.position.x;
        camera_y = transform.position.y;
        player_x = player.position.x;
        player_y = player.position.y;
        if (IsFollowing)
        {
            if (Mathf.Abs(camera_x - player.position.x) > Margin.x)
            {//如果相机与角色的x轴距离超过了最大范围则将x平滑的移动到目标点的x
                camera_x = Mathf.Lerp(camera_x, player.position.x, smoothing.x * Time.deltaTime);
            }
            if (Mathf.Abs(camera_y - player.position.y) > Margin.y)
            {//如果相机与角色的y轴距离超过了最大范围则将x平滑的移动到目标点的y
                camera_y = Mathf.Lerp(camera_y, player.position.y, smoothing.y * Time.deltaTime);
            }
        }
        float orthographicSize = GetComponent<Camera>().orthographicSize;//orthographicSize代表相机(或者称为游戏视窗)竖直方向一半的范围大小,且不随屏幕分辨率变化(水平方向会变)
        var cameraHalfWidth = orthographicSize * ((float)Screen.width / Screen.height);//的到视窗水平方向一半的大小
        camera_x = Mathf.Clamp(camera_x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);//限定x值
        camera_y = Mathf.Clamp(camera_y, _min.y + orthographicSize, _max.y - orthographicSize);//限定y值
        transform.position = new Vector3(camera_x, camera_y, transform.position.z);//改变相机的位置
    }
}
