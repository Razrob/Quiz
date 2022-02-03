using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz
{
    [CreateAssetMenu(menuName = ("Create visualization kit"))]
    public class VisualizationBundle : ScriptableObject
    {
        [SerializeField] private BundleCell[] _bundleCells;
        [SerializeField] private Color[] _backgroundColors;
        [SerializeField] private CellsLayoutData _cellsLayoutData;

        public IReadOnlyList<BundleCell> BundleCells => _bundleCells;
        public IReadOnlyList<Color> BackgroundColors => _backgroundColors;
        public CellsLayoutData CellsLayoutData => _cellsLayoutData;
    }

    [Serializable]
    public struct CellsLayoutData
    {
        public Vector2 CellSize;
        public float CellBorder;
        public float ImageRelativeSize;
    }
}