using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public interface IInteractable : IAction, IInitialization
    {
        bool IsInteractable { get; }
    }
}
