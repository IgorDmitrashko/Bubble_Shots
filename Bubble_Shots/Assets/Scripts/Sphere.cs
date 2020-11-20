using System;
using UnityEngine;

public abstract class Sphere : MonoBehaviour
{
    [NonSerialized] public float mass;
    [NonSerialized] public float delta;

    [NonSerialized] public int speedTransfer;
    [NonSerialized] public float startingSize;

    protected Vector3 Scale;

    protected void TransferMass(ref float massPlayer, ref float massBubble) {
        massPlayer -= 0.5f;
        massBubble += 0.5f;
    }

    public abstract void SettingsForSphere();
   
    protected Vector3 SetScale(ref float mass, ref float delta, int sizepeedTransfere, float size) {

        delta = 8 * Mathf.Pow(20, Mathf.Log(2, 01.1f)) * Mathf.Pow(mass, Mathf.Log(2, 01.1f));
        Scale.Set((mass / sizepeedTransfere + size), (mass / sizepeedTransfere + size), (mass / sizepeedTransfere + size));

        return Scale;
    }
}
