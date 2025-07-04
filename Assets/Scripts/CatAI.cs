using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public float timer; //��ʱ��������ͳ�ƶ���Ĵ���ʱ��
    public bool isIdle = true;
    public float timeKey; //ʱ�������������ǰ��ʱ�����
    
    private Animator animator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        animator = GetComponent<Animator>(); //��ȡ�������������
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timeKey += Time.deltaTime; //��ʵʱ�����

        if (timeKey >= timer) //ÿ��������л�һ�δ���״̬
        {
            timeKey = 0; //����timeKey
            timer = Random.Range(2, 5); //��2-5֮�����һ������
            if (isIdle)
            {
                isIdle = false;
            }
            else
            {
                isIdle = true;
            }

            int ran = Random.Range(0, 2); //��0-1֮�����һ������
            if (ran == 0)
            {
                transform.localScale = new Vector3(3, 3, 3); //������������ת��
            }
            else
            {
                transform.localScale = new Vector3(-3, 3, 3);
            }
        }



        //������ڴ���״̬����isWalk����Ϊfalse
        if (isIdle)
        {
            animator.SetBool("is_walk", false);
            rb.velocity = Vector2.zero;
        }
        else
        {
            //�����ƶ�ʱ
            animator.SetBool("is_walk", true);
            if(transform.localScale.x > 0) //�������
            {
                rb.velocity = new Vector2(1, 0) * Time.deltaTime * 100; //�ƶ��ٶ�
            }
            else //�����ұ�
            {
                rb.velocity = new Vector2(-1, 0) * Time.deltaTime * 100;
            }
        }

    }
}
