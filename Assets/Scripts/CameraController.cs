using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    private Transform playerTransform;
    [SerializeField] int zoomSpeed=10;//视野缩放速度

    void Start()//初始化计算相机位置和玩家位置的偏移量
    {
        playerTransform=GameObject.FindGameObjectWithTag("Player").transform;//通过Tag获取玩家对象的Transform组件
        offset=transform.position-playerTransform.position;
    }

    void Update()
    {
        transform.position=playerTransform.position+offset;//通过偏移量以及玩家的位置，实现相机的跟随效果

        float scroll=Input.GetAxis("Mouse ScrollWheel");//获取鼠标滚轮的滚动值
        Camera.main.fieldOfView += scroll*zoomSpeed;//每一帧加或减视野大小

        Camera.main.fieldOfView=Mathf.Clamp(Camera.main.fieldOfView,37,70);//限制视野取值范围
    }
}
