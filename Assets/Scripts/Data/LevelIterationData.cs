using System.Collections.Generic;
using UnityEngine;
using System;

namespace Quiz
{
    [Serializable]
    public class LevelIterationData
    {
        [SerializeField] private VisualizationBundle[] _availabilityVisualizationBundles;
        [SerializeField] private Vector2Int _cellsPlacementMode;

        public IReadOnlyList<VisualizationBundle> AvailabilityVisualizationBundles => _availabilityVisualizationBundles;
        public int CellsCount => _cellsPlacementMode.x * _cellsPlacementMode.y;
        public Vector2Int CellsPlacementMode => _cellsPlacementMode;
    }
}