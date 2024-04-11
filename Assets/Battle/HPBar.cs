using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;

    public void SetHP(float HPnormalized)
    {
        health.transform.localScale = new Vector3(HPnormalized, 1f);
    }
}
