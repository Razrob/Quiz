using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz
{
    public class UserInteractData
    {
        public event Action<CellData> OnIncorrectChoiceReceive;
        public event Action<CellData> OnCorrectChoiceReceive;

        public void SendAnswer(CellData cellData, bool correctness)
        {
            if (correctness)
                OnCorrectChoiceReceive?.Invoke(cellData);
            else OnIncorrectChoiceReceive?.Invoke(cellData);
        }
    }
}