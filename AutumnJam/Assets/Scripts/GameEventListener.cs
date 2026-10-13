using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;


public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent; // reference to the GameEvent script
    public UnityEvent onEventTriggered;

    void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }

    public void OnEventTriggered()
    {
        onEventTriggered.Invoke();
    }
}
