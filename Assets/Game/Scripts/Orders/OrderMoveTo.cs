using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderMoveTo : IOrder
{
    private Vector3 target;

    public OrderMoveTo(Unit unitComponent, Vector3 target)
    {
        this.target = target;
        unit = unitComponent;
        desctiption = $"Moving to {target}";
    }

    public bool isComplete { get; set; }
    public string desctiption { get; set; }
    public Unit unit { get; set; }

    public void CancelOrder()
    {
        Debug.Log("Order Move To Complete!");
        isComplete = true;
    }

    public void Execute()
    {
        if (Vector3.Distance(unit.transform.position, target) <= 1) CancelOrder();

        Vector3 direction = target - unit.transform.position;
        unit.transform.Translate(direction.normalized * unit.MoveSpeed * Time.deltaTime);
    }

    public void OnStartOrder()
    {
        
    }

    public void OnStopOrder()
    {
        
    }
}
