using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz
{
    public class SessionCleaner : SystemBase
    {
        protected override void Initialize()
        {
            if (commonData.GridData.CellsCount > 0)
                Clear();
        }

        private void Clear()
        {
            foreach(CellData cellData in commonData.GridData.CellDatas)
                Destroy(cellData.AttachedCellPresenter.gameObject);

            commonData.GridData.ClearCells();
        }
    }
}