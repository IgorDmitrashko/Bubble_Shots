using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : Sphere
{
    private GameObject _target;

    public bool AllowSetScale = false;
    public bool AllowMove = false;



    private void Start() {
        SettingsForSphere();
        _target = GameObject.FindGameObjectWithTag("Target");
        transform.localScale = SetScale(ref mass, ref delta, speedTransfer, startingSize);
    }

    public void Move() {
        _target = GameObject.FindGameObjectWithTag("Target");
        transform.position = Vector3.Lerp(transform.position, _target.transform.position, 0.01f);
    }

    private void Update() {
        if(AllowSetScale)
        {
            transform.localScale = SetScale(ref mass, ref delta, speedTransfer, startingSize);
        }

        if(AllowMove && mass >= 10)
        {
            Move();
        }
    }

    public override void SettingsForSphere() {
        delta = 2;
        speedTransfer = 200;
        startingSize = 0.2f;
    }
}
