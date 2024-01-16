using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOrder
{
    Unit unit { get; set; }
    public string desctiption {  get; set; }
    public bool isComplete { get; set; }
    public void Execute();
    public void CancelOrder();

    public void OnStartOrder();
    public void OnStopOrder();

}
