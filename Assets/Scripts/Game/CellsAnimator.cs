using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Quiz
{
    public class CellsAnimator : SystemBase
    {
        [SerializeField] private Vector3 startScale;
        [SerializeField] private float scalingDuration;
        [SerializeField] private AnimationCurve scalingCurve;

        protected override void Initialize()
        {
            if (commonData.SessionProcessData.CycleNumber != 1)
                return;

            foreach(CellData cellData in commonData.GridData.CellDatas)
            {
                cellData.AttachedCellPresenter.transform.localScale = startScale;
                cellData.AttachedCellPresenter.transform.DOScale(Vector3.one, scalingDuration)
                    .SetEase(scalingCurve);
            }
        }
    }
}