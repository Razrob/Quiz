using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz
{
    public abstract class SystemBase : MonoBehaviour
    {
        protected CommonData commonData;

        protected readonly Bootstrap attachedBootstrap;

        protected virtual void Initialize() { }
    }
}