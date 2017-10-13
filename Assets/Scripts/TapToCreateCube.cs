using HoloToolkit.Unity.InputModule;
using UnityEngine;
using System;
using HoloToolkit.Unity;

public class TapToCreateCube : MonoBehaviour, IInputClickHandler
{
    public Transform Prefab;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        var instance = Instantiate(Prefab);
        instance.gameObject.transform.position = GazeManager.Instance.GazeOrigin + GazeManager.Instance.GazeNormal * 1.5f;
        WorldAnchorManager.Instance.AttachAnchor(instance.gameObject, Guid.NewGuid().ToString());
    }

    // Use this for initialization
    void Start()
    {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }
}
