using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    public delegate void EventAction();
    [SerializeField] private GameObject player;
    private EventAction jumpEvent, moveLeftEvent, moveRightEvent, shootEvent;
    private Dictionary<KeyCode, EventAction> inputs = new Dictionary<KeyCode, EventAction>();

    private void Start()
    {
        Player playerComponent = player.GetComponent<Player>();

        moveLeftEvent += playerComponent.MoveLeft;
        moveRightEvent += playerComponent.MoveRight;
        jumpEvent += playerComponent.Jump;
        shootEvent += playerComponent.Shoot;
        
        inputs.Add(KeyCode.Space, jumpEvent);
        inputs.Add(KeyCode.A, moveLeftEvent);
        inputs.Add(KeyCode.D, moveRightEvent);
        inputs.Add(KeyCode.Mouse0, shootEvent);
    }

    private void Update()
    {
        foreach (KeyValuePair<KeyCode, EventAction> keyvalue in inputs.ToList())
        {
            if (Input.GetKey(keyvalue.Key))
                keyvalue.Value();
        }
    }
}