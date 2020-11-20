using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    private Bubble _bubble;

    public UnityEvent winGame;

    private void OnTriggerEnter(Collider bubble) {
        if(bubble.tag == "Bubble" )
        {
            this._bubble = bubble.gameObject.GetComponent<Bubble>();
            this._bubble.AllowMove = false;

            Destroy(bubble.gameObject);
            winGame?.Invoke();
        }
    }
}
