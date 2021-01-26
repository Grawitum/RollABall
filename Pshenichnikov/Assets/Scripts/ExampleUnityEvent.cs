using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExampleUnityEvent : MonoBehaviour
{
    public UnityEvent MyEvent;

    private void OnEnable()
    {
        if (MyEvent == null)
            MyEvent = new UnityEvent();

        MyEvent.AddListener(Ping);
    }

    private void OnDisable()
    {
        if (MyEvent == null)
            MyEvent = new UnityEvent();

        MyEvent.RemoveListener(Ping);
    }

    private void Update()
    {
        if (Input.anyKeyDown && MyEvent != null)
        {
            MyEvent.Invoke();
        }
    }

    private void Ping()
    {
        Debug.Log("Ping");
    }
}
