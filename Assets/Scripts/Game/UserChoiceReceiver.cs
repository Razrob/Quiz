using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Quiz
{
    public class UserChoiceReceiver : SystemBase
    {
        protected override void Initialize()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            foreach(CellData cellData in commonData.GridData.CellDatas)
            {
                EventTrigger.Entry entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
                entry.callback.AddListener(eventData => OnClick(cellData));
                cellData.AttachedCellPresenter.EventTrigger.triggers.Add(entry);
            }
        }

        private void OnClick(CellData cellData)
        {
            commonData.UserInteractData.SendAnswer(cellData, 
                cellData.AttachedBundleCell.Identifier == commonData.SessionProcessData.CurrentTargetBundleCell.Identifier);
        }
    }
}