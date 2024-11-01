using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] //可在編輯器內執行
public class FaceCamera : MonoBehaviour
{
    
    Transform cam; //攝影機位置
    Vector3 targetAngel = Vector3.zero;  //目標旋轉量

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam.position);
        targetAngel = transform.localEulerAngles;
        targetAngel.x = 0;
        targetAngel.z = 0;
        transform.localEulerAngles = targetAngel; //0, 角度 , 0
    }
}
