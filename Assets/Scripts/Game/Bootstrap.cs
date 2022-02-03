using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Quiz
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private LevelPreset _levelPreset;

        private Dictionary<SystemBase, MethodInfo> _initializationMethods = new Dictionary<SystemBase, MethodInfo>();

        private void Awake()
        {
            Initialize();
        }

        public void Reload()
        {
            foreach (SystemBase systemBase in _initializationMethods.Keys)
                _initializationMethods[systemBase].Invoke(systemBase, null);
        }

        private void Initialize()
        {
            if (_levelPreset is null)
                throw new NullReferenceException("LevelPreset not set");

            CommonData commonData = new CommonData
            {
                LevelPreset = _levelPreset
            };

            foreach (Transform child in transform)
            {
                if (child.TryGetComponent(out SystemBase systemBase))
                {
                    FieldInfo commonDataFieldInfo = systemBase.GetType().GetField("commonData", BindingFlags.Instance | BindingFlags.NonPublic);
                    FieldInfo bootstrapPropertyInfo = systemBase.GetType()
                        .GetField("attachedBootstrap", BindingFlags.Instance | BindingFlags.NonPublic);

                    MethodInfo initializeMethodInfo = systemBase.GetType().GetMethod("Initialize", BindingFlags.Instance | BindingFlags.NonPublic);

                    if (commonDataFieldInfo is null)
                        throw new NullReferenceException("Field commonData not found ");

                    if (bootstrapPropertyInfo is null)
                        throw new NullReferenceException("Property attachedBootstrap not found ");

                    if (initializeMethodInfo is null)
                        throw new NullReferenceException("Method Initialize not found ");

                    bootstrapPropertyInfo.SetValue(systemBase, this);
                    commonDataFieldInfo.SetValue(systemBase, commonData);
                    initializeMethodInfo.Invoke(systemBase, null);

                    _initializationMethods.Add(systemBase, initializeMethodInfo);
                }
            }
        }
    }
}