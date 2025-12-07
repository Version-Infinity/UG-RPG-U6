using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Damage : MonoBehaviour
{
    public int minDamage = 1;
    public int maxDamage = 20;

    public int GetDamage()
    {
        return new System.Random(System.Environment.TickCount).Next(minDamage, maxDamage);
    }
}
