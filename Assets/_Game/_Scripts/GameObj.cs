using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObj : MonoBehaviour
{
    [Header("REF")]
    [Tooltip("KEO THA GAME UNIT")]
    [SerializeField] private GameUnit water;

    [Header("Stats")]
    [SerializeField] private int maxHP;
    [SerializeField] private int hp;

    private void Awake() // Init Ref
    {
        Debug.Log("Awake");
    }
    void Start() // Init Game Logic
    {
        Debug.Log("Start");

        gameObject.name = "Tung";
        //gameObject.tag = "NewTag";
        //gameObject.SetActive(true);

        //Instantiate(gameObject,transform);// copy hết lại, nếu set parent thì postion vẫn như cũ, bị phụ thuộc bởi parent
        //Instantiate(water);
        gameObject.transform.SetParent(transform);
    }

    private void OnEnable() // Register Event
    {
        Debug.Log("Enable");
    }

    private void OnDisable() // Unregister Event
    {
        Debug.Log("Disable");
    }
    private void Update() // frame
    {
        
    }
    private void Timer()
    {
        //Time.timeScale
        //Time.deltaTime
    }
    private void FixedUpdate() // 0.02f
    {
        
    }
    private void LateUpdate() // frame
    {
        
    }
    private void OnDestroy() 
    {
        //save player data
        //clear data;
    }
}
