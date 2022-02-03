using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz
{
    public class SessionProcessData
    {
        public LevelIterationData CurrentLevelIterationData;
        public VisualizationBundle CurrentVisualizationBundle;
        public BundleCell CurrentTargetBundleCell;

        public List<CellIdentifier> LastTargetCells = new List<CellIdentifier>();
        public int LevelNumber => (LastTargetCells.Count - 1) % 3 + 1;
        public int CycleNumber => (LastTargetCells.Count - 1) / 3 + 1;
    }
}