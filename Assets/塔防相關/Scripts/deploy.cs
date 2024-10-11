using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deploy : MonoBehaviour
{
    GameObject[] 砲台 = new GameObject[2];
    GameObject 吳沙;
    Vector3 newPos;
    GameObject 已部署;

    // Start is called before the first frame update
    void Start()
    {
        砲台[0] = GameObject.Find("GAMEMASTER").GetComponent<gameMaster>().守方[0];
        砲台[1] = GameObject.Find("GAMEMASTER").GetComponent<gameMaster>().守方[1];
        吳沙 = GameObject.Find("GAMEMASTER").GetComponent<gameMaster>().吳沙;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(
            Camera.main.ScreenToWorldPoint(Input.mousePosition),
            transform.TransformDirection(Vector3.forward),
            out hit,
            Mathf.Infinity
            ))
        {
            if (hit.transform.tag == "可部署")
            {
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    if (GameObject.Find("GAMEMASTER").GetComponent<gameMaster>().砲A上限 > 0)
                    {//部署 砲台A 滑鼠左 
                        newPos = hit.transform.position;
                        newPos.y += 0.15f;

                        if (hit.transform.name == "吳沙救護生成點(可部署)")
                        {
                            已部署 = Instantiate(吳沙, newPos, Quaternion.identity);
                            已部署.tag = "防守方";
                        }
                        else 
                        {
                            已部署 = Instantiate(砲台[0], newPos, Quaternion.identity);
                            已部署.tag = "防守方";
                        }

                        
                        GameObject.Find("GAMEMASTER").GetComponent<gameMaster>().砲A上限--;
                    }                    
                }
                if (Input.GetKeyUp(KeyCode.Mouse1))
                {
                    if (GameObject.Find("GAMEMASTER").GetComponent<gameMaster>().砲B上限 > 0)
                    {
                        //部署 砲台B 滑鼠右
                        newPos = hit.transform.position;
                        newPos.y += 0.15f;
                        已部署 = Instantiate(砲台[1], newPos, Quaternion.identity);
                        已部署.tag = "防守方";
                        GameObject.Find("GAMEMASTER").GetComponent<gameMaster>().砲B上限--;
                    }                    
                }
            }

        
        }
    }
}
