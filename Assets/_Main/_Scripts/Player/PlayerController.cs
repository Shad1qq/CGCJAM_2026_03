using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Main._Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public IReadOnlyCollection<IModule> Modules => _modules;
        private List<IModule> _modules = new List<IModule>();

        private void Awake()
        {
            _modules.AddRange(GetComponentsInChildren<IModule>());
        }
    }
}
