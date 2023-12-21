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
    
    /*public struct KeyValue
    {
        public KeyCode key;
        public Value value; 

        public KeyValue(KeyCode _key, Value _value)
        {
            key = _key;
            value = _value;
        }
    }*/
    
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject player;

    private EventAction jumpEvent, moveEvent, shootEvent;
    
    //private List<KeyValue> inputs = new List<KeyValue>();
    private Dictionary<KeyCode, EventAction> inputs = new Dictionary<KeyCode, EventAction>();

    private void Start()
    {
        Player playerComponent = player.GetComponent<Player>();

        moveEvent += playerComponent.Move;
        jumpEvent += playerComponent.Jump;
        shootEvent += playerComponent.Shoot;

        //inputs.Add(new KeyValue(KeyCode.Space, jumpEvent));
        //inputs.Add(new KeyValue(KeyCode.A, moveEvent));
        //inputs.Add(new KeyValue(KeyCode.D, moveEvent));
        //inputs.Add(new KeyValue(KeyCode.Mouse0, shootEvent));
        
        inputs.Add(KeyCode.Space, jumpEvent);
        inputs.Add(KeyCode.A, moveEvent);
        inputs.Add(KeyCode.D, moveEvent);
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