using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quiz
{
    public class VisualizationSelector : SystemBase
    {
        protected override void Initialize()
        {
            LevelIterationData levelIterationData = commonData.LevelPreset.LevelIterations[commonData.SessionProcessData.LastTargetCells.Count % 3];
            VisualizationBundle visualizationBundle =
                levelIterationData.AvailabilityVisualizationBundles[Random.Range(0, levelIterationData.AvailabilityVisualizationBundles.Count)];

            commonData.SessionProcessData.CurrentLevelIterationData = levelIterationData;
            commonData.SessionProcessData.CurrentVisualizationBundle = visualizationBundle;

            BundleCell targetBundleCell = GetRandomBundleCell(commonData.SessionProcessData.CurrentVisualizationBundle.BundleCells,
                commonData.SessionProcessData.LastTargetCells);
            commonData.SessionProcessData.LastTargetCells.Add(targetBundleCell.Identifier);
            commonData.SessionProcessData.CurrentTargetBundleCell = targetBundleCell;

            int targetBundleIndex = Random.Range(0, levelIterationData.CellsCount);

            for (int i = 0; i < levelIterationData.CellsCount; i++)
            {
                BundleCell cell = targetBundleCell;
                
                if (targetBundleIndex != i)
                    cell = GetRandomBundleCell(visualizationBundle.BundleCells, commonData.GridData.CellsIdentifiers
                        .Concat(new CellIdentifier[] { targetBundleCell.Identifier }));

                commonData.GridData.AddCell(new CellData { AttachedBundleCell = cell });
            }
        }

        private BundleCell GetRandomBundleCell(IReadOnlyList<BundleCell> bundleCells, IEnumerable<CellIdentifier> excludedIdentifiers)
        {
            int index = Random.Range(0, bundleCells.Count);

            if (bundleCells.Count(cell => excludedIdentifiers.Count(id => cell.Identifier == id) < 1) == 0)
            {
                Debug.Log("No more unique cells");
                return bundleCells[index];
            }

            while (excludedIdentifiers.Count(id => bundleCells[index].Identifier == id) > 0)
            {
                index++;
                if (index == bundleCells.Count)
                    index = 0;
            }

            return bundleCells[index];
        }
    }
}