using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    private int cnt = 0;
    private int update_cnt = 0;
    private IEnumerator[] cos;
    // Start is called before the first frame update
    void Start()
    {
        cos = new IEnumerator[2];
        cos[0] = DoSomethingDelay(1f, 0);
        cos[1] = RunLoop();
        foreach(var co in cos)
        {
            StartCoroutine(co);
        }
    }

    // Update is called once per frame
    void Update()
    {
        update_cnt += 1;

        if (update_cnt == 20)
        {
            StopCoroutine(cos[1]);  // 递归的也会停止
        }

        if (update_cnt == 30)
        {
            StopAllCoroutines();
        }

        if (update_cnt == 100)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DoSomethingDelay(float second, int id)
    {
        cnt += 1;
        yield return new WaitForSeconds(second); // 等待
        print($"Running coroutine {id}, cnt = {cnt}");
        if (cnt > 5)
        {
            yield break;
        }
        yield return new WaitForSeconds(second); // 等待
        StartCoroutine(DoSomethingDelay(second, id + 1));  // 可以像递归一样调用
    }

    IEnumerator RunLoop()
    {
        for (int i = 0; i < 5; i += 1)
        {
            print($"Running coroutine RunLoop, iteration = {i}");
            yield return 0;  // 结束当前协程的运行，但是不会跳出循环
        }
    }
}
