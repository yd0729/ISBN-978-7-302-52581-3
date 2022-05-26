using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSomethingScript : DoSomethingBase
{
    public void DoSomething()
    {
        Debug.Log("Do Something");
    }

    public override void DoSomething2()
    {
        Debug.Log("Do Something 2");
    }
}
