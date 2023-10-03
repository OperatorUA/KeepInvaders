using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public GameObject Model;
    public Outline outline;
    public OrderBehaviour orderBehaviour;

    public float MaxHealth;
    public float CurrentHealth;
    public float MoveSpeed;
    public float Armor;

    public virtual void Start()
    {
        orderBehaviour = gameObject.AddComponent<OrderBehaviour>();

        outline = gameObject.AddComponent<Outline>();
        outline.OutlineWidth = 3.5f;
        outline.enabled = false;
    }

    public virtual void Update()
    {
        //orderBehaviour.Execute();
    }
}
