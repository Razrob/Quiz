using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz
{
    [CreateAssetMenu(menuName = "Create level preset")]
    public class LevelPreset : ScriptableObject
    {
        [SerializeField] private LevelIterationData[] _levelIterations;
        public IReadOnlyList<LevelIterationData> LevelIterations => _levelIterations;
    }
}