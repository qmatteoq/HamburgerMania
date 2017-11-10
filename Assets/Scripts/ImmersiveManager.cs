using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmersiveManager : MonoBehaviour
{
    public List<GameObject> Objects;
    // Use this for initialization
    void Start()
    {
        foreach (var item in Objects)
        {
            item.SetActive(!OpaqueDetector.IsOpaque);
        }
    }
}

