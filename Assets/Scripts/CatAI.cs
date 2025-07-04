using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public float timer; //计时器，用来统计动物的待机时间
    public bool isIdle = true;
    public float timeKey; //时间键，用来代表当前的时间进度
    
    private Animator animator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        animator = GetComponent<Animator>(); //获取动画控制器组件
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timeKey += Time.deltaTime; //现实时间进度

        if (timeKey >= timer) //每随机几秒切换一次待机状态
        {
            timeKey = 0; //重置timeKey
            timer = Random.Range(2, 5); //在2-5之间随机一个数字
            if (isIdle)
            {
                isIdle = false;
            }
            else
            {
                isIdle = true;
            }

            int ran = Random.Range(0, 2); //在0-1之间随机一个数字
            if (ran == 0)
            {
                transform.localScale = new Vector3(3, 3, 3); //设置缩放用来转向
            }
            else
            {
                transform.localScale = new Vector3(-3, 3, 3);
            }
        }



        //如果处于待机状态，则将isWalk设置为false
        if (isIdle)
        {
            animator.SetBool("is_walk", false);
            rb.velocity = Vector2.zero;
        }
        else
        {
            //正在移动时
            animator.SetBool("is_walk", true);
            if(transform.localScale.x > 0) //朝向左边
            {
                rb.velocity = new Vector2(1, 0) * Time.deltaTime * 100; //移动速度
            }
            else //朝向右边
            {
                rb.velocity = new Vector2(-1, 0) * Time.deltaTime * 100;
            }
        }

    }
}
