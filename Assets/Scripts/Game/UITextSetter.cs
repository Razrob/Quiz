using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace Quiz 
{
    public class UITextSetter : SystemBase
    {
        [SerializeField] private TextMeshProUGUI _qiuzText;
        [SerializeField] private string _emptyText;
        [SerializeField] private float _coloringDuration;

        protected override void Initialize()
        {
            if (commonData.SessionProcessData.CycleNumber == 1)
            {
                Color color = _qiuzText.color;
                _qiuzText.color = new Color(color.r, color.g, color.b, 0f);
                _qiuzText.DOColor(new Color(color.r, color.g, color.b, 1f), _coloringDuration);
            }

            _qiuzText.text = string.Format(_emptyText, commonData.SessionProcessData.CurrentTargetBundleCell.Identifier);
        }
    }
}