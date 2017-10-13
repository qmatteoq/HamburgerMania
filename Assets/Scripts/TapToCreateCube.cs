using HoloToolkit.Unity.InputModule;
using UnityEngine;
using System;
using HoloToolkit.Unity;

public class TapToCreateCube : MonoBehaviour, IInputClickHandler
{
    public Transform Prefab;

    private bool loaded;

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

    void Update()
    {
        if (!this.loaded && (WorldAnchorManager.Instance.AnchorStore != null))
        {
            var ids = WorldAnchorManager.Instance.AnchorStore.GetAllIds();

            // NB: I'm assuming that the ordering here is either preserved or
            // maybe doesn't matter.
            foreach (var id in ids)
            {
                var instance = Instantiate(this.Prefab);
                WorldAnchorManager.Instance.AttachAnchor(instance.gameObject, id);
            }
            this.loaded = true;
        }
    }
}
