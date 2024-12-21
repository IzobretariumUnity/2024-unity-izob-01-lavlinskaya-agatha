
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{

    private int[] array = new int[5];

    private void Start1()
    {
        for(int i = 0; i < array.Length; i++)
        {
            array[i] = i * 2;
            Debug.Log(array[i]);
        }
    }



    private int[] students = new int[5] { 1, 2, 3, 4, 5 };

    private void Start()
    {

        float sum = 0;
        for (int i = 0; i < students.Length; i++)
        {
            sum += students[i]; 


        }

        Debug. Log(sum / students.Length); 
    }


}







