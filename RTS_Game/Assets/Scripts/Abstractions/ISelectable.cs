using UnityEngine;

namespace Abstractions
{
    public interface ISelectable
    {
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }

        void SetSelected();
        void UnsetSelected();
    }
}