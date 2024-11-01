using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Gaze : MonoBehaviour
{
    [SerializeField]
    List<InfoBehaviour> infos = new List<InfoBehaviour> ();

    // Start is called before the first frame update
    void Start()
    {
        infos = FindObjectsOfType<InfoBehaviour>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit)) { 
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag("防守方"))
            {
                infos = FindObjectsOfType<InfoBehaviour>().ToList();
                OpenInfo(go.GetComponent<InfoBehaviour>());

                float distance = Vector3.Distance(this.transform.position, go.transform.position);
                GameObject.Find("/Canvas/Text").GetComponent<Text>().text = "距離：" + distance.ToString();

            }
            else {
                closeAll();
            }
        }
    }

    void OpenInfo(InfoBehaviour desiredInfo) {
        foreach (InfoBehaviour info in infos) {
            if (info == desiredInfo)
            {
                info.OpenInfo();
            }
            else { 
                info.CloseInfo();
            }
        }
    }

    void closeAll()
    {
        foreach (InfoBehaviour info in infos)
        {
            info.CloseInfo();
        }
    }
}
