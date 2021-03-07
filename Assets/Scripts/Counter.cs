using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Counter : MonoBehaviour
{
    //public Text CounterText;
    [SerializeField] GameManager manager;
    private int Count = 0;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        //CounterText.text = "Count : " + Count;
        manager.ChangeScore(1);
        if (other.gameObject.CompareTag("Ammo"))
        {
            // stop cannon balls that enter from disapearing
            other.GetComponent<Ammo>().StopLifeDecay();
            GetComponent<sideToSide>().ChangeSpeed(0.1f);
        }
    }
}
