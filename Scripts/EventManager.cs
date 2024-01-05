using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    private static EventManager m_Instance;
    public static EventManager Instance => m_Instance ?? (m_Instance = new EventManager());
    private Dictionary<string, Delegate> m_EventCache;
    private EventManager() => m_EventCache = new Dictionary<string, Delegate>();

    public void Subscribe<T>(string eventName, Action<T> listener)
    {
        if (!m_EventCache.TryGetValue(eventName, out Delegate existingDelegate))
        {
            existingDelegate = listener;
            m_EventCache[eventName] = existingDelegate;
        }
        else
        {
            if (existingDelegate is Action<T> typedDelegate)
                typedDelegate += listener;
            else
                throw new ArgumentException($"Event {eventName} has mismatched delegate types.");
        }
    }
    public void Unsubscribe<T>(string eventName, Action<T> listener)
    {
        if (!m_EventCache.TryGetValue(eventName, out Delegate existingDelegate)
            && existingDelegate is Action<T> typedDelegate)
        {
            typedDelegate -= listener;

            if (typedDelegate == null)
                m_EventCache.Remove(eventName);
            else
                m_EventCache[eventName] = typedDelegate;
        }
    }
    public void TriggerEvent<T>(string eventName, T arg)
    {
        if (m_EventCache.TryGetValue(eventName, out Delegate existingDelegate) && existingDelegate is Action<T> typedDelegate)
            typedDelegate.Invoke(arg);
    }

    public void Subscribe(string eventName, Action listener)
    {
        if (!m_EventCache.TryGetValue(eventName, out Delegate existingDelegate))
        {
            existingDelegate = listener;
            m_EventCache[eventName] = existingDelegate;
        }
        else
        {
            if (existingDelegate is Action typedDelegate)
                typedDelegate += listener;
            else
                throw new ArgumentException($"Event {eventName} has mismatched delegate types.");
        }
    }
    public void Unsubscribe(string eventName, Action listener)
    {
        if (!m_EventCache.TryGetValue(eventName, out Delegate existingDelegate)
            && existingDelegate is Action typedDelegate)
        {
            typedDelegate -= listener;

            if (typedDelegate == null)
                m_EventCache.Remove(eventName);
            else
                m_EventCache[eventName] = typedDelegate;
        }
    }
    public void TriggerEvent(string eventName)
    {
        if (m_EventCache.TryGetValue(eventName, out Delegate existingDelegate) && existingDelegate is Action typedDelegate)
            typedDelegate.Invoke();
    }
}
