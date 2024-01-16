using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera _camera;
    public List<Unit> selectedUnits = new List<Unit>();

    public int LayerIndex = 0;
    // Start is called before the first frame update
    void Awake()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue, 1 << LayerIndex))
        {
            if (Input.GetMouseButtonDown(0))
            {
                SelectObject(hit.collider.gameObject);
            }

            if (Input.GetMouseButtonDown(1) && selectedUnits.Count > 0)
            {
                //selectedUnits.ordersController.SetOrder(new OrderMoveTo(hit.point));
                foreach (Unit unit in selectedUnits)
                {
                    IOrder order = new OrderMoveTo(unit, hit.point);
                    if (!Input.GetKey(KeyCode.LeftShift)) unit.orderBehaviour.ClearOrdersList();
                    unit.orderBehaviour.AddOrder(order);
                }
            }
        }
    }

    private void SelectObject(GameObject obj)
    {
        Unit unitComponent = obj.GetComponentInParent<Unit>();
        if (unitComponent != null)
        {
            if (!Input.GetKey(KeyCode.LeftShift)) UnselectAll();
            SelectUnit(unitComponent);
        }
        else
        {
            UnselectAll();
        }
    }

    private void SelectUnit(Unit unit)
    {
        unit.outline.enabled = true;
        selectedUnits.Add(unit);
    }

    private void UnselectAll()
    {
        foreach (Unit unit in selectedUnits)
        {
            unit.outline.enabled = false;
        }

        selectedUnits.Clear();
    }
}
