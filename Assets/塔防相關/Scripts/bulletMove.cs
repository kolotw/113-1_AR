using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    public float �l�u�t�� = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * �l�u�t�� * Time.deltaTime);
    }
}
