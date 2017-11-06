using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class TapToCreateCube : MonoBehaviour, IInputClickHandler
{
    public GameObject Prefab;
    public GameObject Cursor;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Clicked");
        var instance = Instantiate(Prefab);
        instance.gameObject.transform.position = Cursor.gameObject.transform.position;
    }
}
