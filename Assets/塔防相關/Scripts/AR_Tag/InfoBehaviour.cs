using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBehaviour : MonoBehaviour
{
    [SerializeField] //功能跟public差不多
    Transform SectionInfo; //資訊板的座標
    Vector3 desiredScale = Vector3.zero; //需求的縮放值

    // Update is called once per frame
    void Update()
    {
        SectionInfo.localScale = Vector3.Lerp(SectionInfo.localScale, desiredScale, Time.deltaTime * 3f);    
    }

    public void OpenInfo() { 
        desiredScale = Vector3.one; //1,1,1
    }
    public void CloseInfo()
    {
        desiredScale = Vector3.zero; //0,0,0
    }

}
