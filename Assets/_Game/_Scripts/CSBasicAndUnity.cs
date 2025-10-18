using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CSBasicAndUnity : MonoBehaviour
{
    //readonly string email = "phuc@gmail.com";

    private void Start()
    {
        Player hero = new Player("phuc");    
    }
    private void KeyWords()
    {
        //var HP = 1.0f;

        Dictionary<int,string> dict = new Dictionary<int,string>();
        foreach(var key in dict.Keys)
        {
            Debug.Log(key);
        }
        int currHP = 10;
        AddHeath(ref currHP, 2);
        Debug.Log(currHP); //12;
        if(TryGetItem("water",out ItemTEMP item))
        {
            Debug.Log(item.name);
        }
        else
        {
            Debug.Log("NoItem");
        }
        dict.TryGetValue(1, out string value);
        {
            Debug.Log(value);
        }
    }
    private bool TryGetItem(string name, out ItemTEMP item)
    {
        if(name=="?")
        {
            item = null;
            return true;
        }
        else { 
            item = null;
            return false;
        }
    }
    private void AddHeath(ref int cHP,int amount)
    {
        cHP += amount;
    }
}

public class Player
{
    public readonly string name;
    public Player(string name) {  this.name = name; }
}

public class GameConfig
{
    public const string GAMEVERSION = "v1.1";
}
