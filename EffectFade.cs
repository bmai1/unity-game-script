using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectFade : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.7f);
    }
}
