using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTEMP
{
    public int id;
    public string name;
}

public class CSBasic : MonoBehaviour
{
    private void Start()
    {
        //PhanBietValueRef();
        //Array();
        //List();
        //Dict();
        Vector();
    }
    void PhanBietValueRef()
    {
        int scoreA = 10;
        int scoreB = scoreA;
        scoreB = 1;
        Debug.Log(scoreA + " " + scoreB);

        ItemTEMP item = new ItemTEMP();
        item.name = "PHUC";

        ItemTEMP item1 = item;
        item1.name = "SomeOne";

        Debug.Log(item.name + " " + item1.name);
    }
    void Array()
    {
        int[] ints = new int[10];
        int[] ints1 = {1,2,3};
        int[,] matrix = new int[10,10];
        Debug.Log(ints1.Length);
        Debug.Log(matrix.GetLength(0));
        Debug.Log(matrix.GetLength(1));
        foreach(var i in matrix)
        {
            Debug.Log(i);
        }
    }
    void List()
    {
        List<int> list = new List<int>();
        list.Add(1);
        list.Insert(0, 2);
        list.RemoveAt(0); // exception if not have this index 
        list.Remove(1); // return bool
        if (list.Contains(1))
        {
            Debug.Log("List have 1");
        }
        for(int i=0;i<list.Count;i++) Debug.Log(list[i]); //1
        foreach (int i in list) Debug.Log(i); //2
        list.Clear(); // tái sử dụng thay vì new();
    }
    void Dict()
    {
        Dictionary<string, int> keyValues = new Dictionary<string, int>();
        keyValues.Add("A", 1);
        keyValues.Add("B", 2);
        if(keyValues.TryGetValue("A",out var value))
        {
            Debug.Log(value);
        }
    }
    void Vector()
    {
        //Vector2 vector2 = new Vector2();
        for(int i = 0; i <0;i++)
        {

            float val = 3.14f;
            float val2 = 3.14f;
            if(val == val2)
            {
                Debug.Log("?");
            }else   Debug.Log("!");
        }
    }
}
