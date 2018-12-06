using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour {

    private Dictionary<string, UnityEvent> events;
    private static EventManager eventManager;

	// Singleton
    public static EventManager Instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType<EventManager>();
                eventManager.InitializeEventManager();
            }

            return eventManager;
        }
    }

    private void InitializeEventManager()
    {
        if (events == null)
        {
            events = new Dictionary<string, UnityEvent>();
        }
    }

    public static void StartListener(string eventName, UnityAction action)
    {
        UnityEvent unityEvent;
        if (Instance.events.TryGetValue(eventName, out unityEvent))
        {
            unityEvent.AddListener(action);
        }
        else
        {
            unityEvent = new UnityEvent();
            unityEvent.AddListener(action);
            Instance.events.Add(eventName, unityEvent);
        }
    }

    public static void StopListener(string eventName, UnityAction action)
    {
        if (!eventManager)
            return;

        UnityEvent unityEvent;
        if (Instance.events.TryGetValue(eventName, out unityEvent))
        {
            unityEvent.RemoveListener(action);
        }
        else
        {
            Debug.LogError("Attempted to remove non existing listener from " + eventName);
        }
    }

    public static void Trigger(string eventName)
    {
        UnityEvent unityEvent;
        if (Instance.events.TryGetValue(eventName, out unityEvent))
        {
            unityEvent.Invoke();
        }
        else
        {
            Debug.LogError("Attempted to trigger non existing event: " + eventName);
        }
    }
}
