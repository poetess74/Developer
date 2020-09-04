using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Number num1;
    public Number num2;


    private int count1 = 0;
    private int count2 = 0;

    private void Update()
    {
        count1 += 1;
        count2 += Random.Range(0, 10);

        num1.Set(count1);
        num2.Set(count2);
    }
}
