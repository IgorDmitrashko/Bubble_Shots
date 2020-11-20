using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Sphere
{
    private Bubble _bubble;
    private Vector3 _startPossitionBubble;

    public UnityEvent LostGame;
    public GameObject bubbleObj;

    void Start() {

        SettingsForSphere();
        _startPossitionBubble = new Vector3(-0.46f, 0.1f, -0.35f);

        transform.localScale = SetScale(ref mass, ref delta, speedTransfer, startingSize);
    }

    public void Destroy() {
        Destroy(gameObject);
    }

    void Update() {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bubbleObj, _startPossitionBubble, Quaternion.identity);
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            _bubble = GameObject.FindGameObjectWithTag("Bubble").GetComponent<Bubble>();
            _bubble.AllowSetScale = true;

            transform.localScale = SetScale(ref mass, ref delta, speedTransfer, startingSize);
            TransferMass(ref mass, ref _bubble.mass);
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            _bubble.AllowSetScale = false;
            _bubble.AllowMove = true;           
        }

        if(transform.localScale.x < 0.4f)
        {
            LostGame?.Invoke();
            Destroy(gameObject);
        }
    }

    public override void SettingsForSphere() {
        mass = 200;
        delta = 5;
        speedTransfer = 300;
        startingSize = 0.95f;
    }
}
