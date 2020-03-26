using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMan : MonoBehaviour
{
    private GameObject m_Player;//角色
    public Vector3 offset;//角色与摄像机位置偏差值
    private float _pointY;//玩家Y轴旋转角度
    public float damping = 1;//摄像机旋转阻尼
    void Start()
    {
        m_Player = GameObject.Find("Man");
        //摄像机与玩家之间的位置偏差值
        //玩家position-摄像机position也可，后面根据公式对应改为m_Player.transform.position-(rotatiom * offset)即可
        offset = transform.position - m_Player.transform.position;//角色与摄像机位置偏差值

    }




    void Update()
    {
        //第三人称跟随，随时保持角色后方跟随
        _pointY = m_Player.transform.eulerAngles.y;//实时获取玩家的Y轴旋转
        //Debug.Log(_pointY);//0~360
        Quaternion rotatiom = Quaternion.Euler(0, _pointY, 0);//将玩家Y轴旋转转换为四元数（代表一个三维旋转）
        //rotatiom * offset：四元数*一个向量代表=将该向量转四元数代表的角度，即将该旋转应用到该向量，得到一个新的向量。体现为摄像机随着角色的旋转而左右旋转（但还没以角色为中心注视）
        transform.position = Vector3.Lerp(transform.position, m_Player.transform.position + (rotatiom * offset), Time.deltaTime * damping);
        //让摄像机从自身位置注视玩家位置，功能实现完成。
        transform.LookAt(m_Player.transform.position);
        //LookAt();//LookAt手动实现,相机注视角色
    }




    void LookAt()
    {
        var dir = (m_Player.transform.position - transform.position).normalized;
        var quat = Quaternion.LookRotation(dir);
        transform.rotation = quat;
    }
}