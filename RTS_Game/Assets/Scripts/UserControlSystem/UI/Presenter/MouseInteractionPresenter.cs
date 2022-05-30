using System.Linq;
using Abstractions;
using UnityEngine;
using UserControlSystem;

public sealed class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;

    private ISelectable _activeSelectabeObject;

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }

        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
        if (hits.Length == 0)
        {
            return;
        }

        if (_activeSelectabeObject != null)
        {
            _activeSelectabeObject.UnsetSelected();
        }

        var selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .FirstOrDefault(c => c != null);

        _selectedObject.SetValue(selectable);
        _activeSelectabeObject = selectable;

        if (selectable != null)
        {
            selectable.SetSelected();
        }

        if (selectable is IUnitProducer)
        {
            var mainBuilding = (IUnitProducer)selectable;
            mainBuilding.ProduceUnit();
        }
    }
}