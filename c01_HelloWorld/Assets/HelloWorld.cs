using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public int id = 0;
    public string m_name = "default";
    public Data data;

    void Awake()
    {
        //Debug.Log("Awake");

        // 获取并添加组件
        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }

        // 使用 Unity 消息机制在组件中通信的两种方式
        gameObject.SendMessage("DoSomething");
        gameObject.GetComponent<DoSomethingBase>().DoSomething2();
    }

    private void OnEnable()
    {
        //Debug.Log("OnEnable");
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("Start");

        // 创建 10 个 GameObject
        GameObject[] gos = new GameObject[10];
        for (int i = 0; i < 10; i += 1)
        {
            gos[i] = new GameObject($"Game Object {i}");
            gos[i].AddComponent<Rigidbody>();
        }

        Debug.LogError("这是一条错误．");
        Debug.LogWarning("这是一条警告．");
    }

    // 计算 fps
    int fps = 0;
    float time = 0;

    void Update()
    {
        fps += 1;
        time += Time.deltaTime;
        if (time >= 1)
        {
            Debug.Log($"fps: {fps}");
            fps = 0;
            time = 0;
        }
    }

    private void LateUpdate()
    {
        //Debug.Log("LateUpdate");
    }

    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
    }

    // 在函数OnGUI中定义UI的布局和功能
    void OnGUI()
    {

        // 改变字符的大小
        GUI.skin.label.fontSize = 100;

        // 输出文字
        GUI.Label(new Rect(10, 10, Screen.width, Screen.height), "Hello World");
    }
}


[System.Serializable]
public class Data
{
    public float m_speed = 0;
    public List<string> items;
}