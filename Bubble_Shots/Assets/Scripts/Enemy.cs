using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<GameObject, Collider> Impact;

    private void OnTriggerEnter(Collider collider) {
        if(collider.tag == "Bubble")
        {
            Impact?.Invoke(gameObject, collider);
        }
    }


}
