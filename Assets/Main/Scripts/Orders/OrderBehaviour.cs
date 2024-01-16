using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OrderBehaviour : MonoBehaviour
{
    [SerializeField]
    private List<IOrder> _ordersQueue = new List<IOrder>();
    [SerializeField]
    private IOrder _currentOrder;

    public void Update()
    {
        for (int i = 0; i < _ordersQueue.Count; i++)
        {
            Debug.Log($"index:{i} | {_ordersQueue[i].desctiption}");
        }

        if (_currentOrder != null) Debug.Log($"Current order | {_currentOrder.desctiption}");
        else Debug.Log("Current order Null");

        if (_ordersQueue.Count == 0) return;
        if (_currentOrder == null) _currentOrder = _ordersQueue.First();
        else
        {
            if (_currentOrder.isComplete)
            {
                _currentOrder.OnStopOrder();
                _ordersQueue.Remove(_currentOrder);
                _currentOrder = null;
            }
            else _currentOrder.Execute();
        }
    }
    internal void AddOrder(IOrder orderFactory)
    {
        orderFactory.OnStartOrder();
        _ordersQueue.Add(orderFactory);
    }

    internal void ClearOrdersList()
    {
        if (_currentOrder != null)
        {
            _currentOrder.OnStopOrder();
            _currentOrder = null;
        }

        _ordersQueue.Clear();
    }
}
