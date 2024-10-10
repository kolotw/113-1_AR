using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

public class ������_�ݩʳ]�w : MonoBehaviour
{
    GameObject[] �ĤH;
    public float �g�{�d�� = 4f;
    float �ثe�Z��;
    float �̵u�Z�� = 2f;
    Transform �ؼ�;
    Vector3 dir;
    Vector3 �o�g�IRAY;

    Quaternion ����;

    bool �}�� = false;
    public float ���O���j = 2f;
    float fireTime;

    public int hp = 10;
    int OrigHP;
    GameObject ���;
    Text ��q��r;

    //�}�b��
    Animator anim;
    public Rig rig;

    // Start is called before the first frame update
    void Start()
    {
        OrigHP = hp;
        fireTime = Time.time;
        ��� = transform.Find("Canvas/���").gameObject;
        ��q��r = transform.Find("Canvas/��q").gameObject.GetComponent<Text>();
        ��q��r.text = hp.ToString();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ��ĤH();
        if (�ĤH.Length == 0) return;
        if (�}��) {
            if (Time.time > fireTime + ���O���j)
            {
                rig.weight = 1;
                anim.SetTrigger("FIRE");
                fireTime = Time.time;
            }
        }
    }
    void �ǥؼе�����()
    {
        if (�ؼ� == null) return;
        //�N�ؼжǨ�g�b�欰�A������i�H�ݵۥؼСC
        if (transform.name == "������-�k���y(Clone)")
        {
            GetComponent<������_����_�ųN���y>().�ؼ� = �ؼ�;
        }
        else if (transform.name == "������-�k�}�b(Clone)")
        {
            GetComponent<������_����_�g�b>().�ؼ� = �ؼ�;
        }
    }
    void ��ĤH() 
    {
        �ĤH = GameObject.FindGameObjectsWithTag("�~�H");
        if (�ĤH.Length==0)
        {
            rig.weight = 0;
            anim.SetTrigger("WIN");
            return;
        }
        �̵u�Z�� = �g�{�d��;
        foreach (GameObject e in �ĤH)
        {
            
            �ثe�Z�� = Vector3.Distance(this.transform.position, e.transform.position);
            if (�ثe�Z�� < �g�{�d��)
            {
                if (�ثe�Z�� < �̵u�Z��)
                {
                    �̵u�Z�� = �ثe�Z��;
                    �ؼ� = e.transform;
                    �ǥؼе�����();
                }
            }
        }
        if (�ؼ� != null)
        {
            dir = this.transform.position - �ؼ�.position;
            �o�g�IRAY = new Vector3(
                this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z);
            Debug.DrawRay(�o�g�IRAY, dir * -1, Color.red);

            if (Vector3.Distance(this.transform.position, �ؼ�.position) < �g�{�d��)
            {
                �}�� = true;
                if (dir != Vector3.zero)
                {
                    ���� = Quaternion.LookRotation(dir * -1, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, ����, 20 * Time.deltaTime);
                    this.transform.eulerAngles = new Vector3(0f, this.transform.eulerAngles.y, 0f);
                }
            }
            else {
                �}�� = false;
            }
        }
        else {
            �}�� = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "�~�H�Z��")
        {
            Destroy(other.gameObject);
            hp--;
            float ��q = (float)hp / (float)OrigHP;
            ���.transform.localScale = new Vector3(��q, 1f, 1f);
            ��q��r.text = hp.ToString();
            if (hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
