using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract void Attack();

    public abstract void Trigger();
    public abstract void Release();
}


