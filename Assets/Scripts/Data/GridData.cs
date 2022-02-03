using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quiz
{
    public class GridData
    {
        private Dictionary<CellIdentifier, CellData> _cells = new Dictionary<CellIdentifier, CellData>();
        public IEnumerable<CellIdentifier> CellsIdentifiers => _cells.Keys;
        public IEnumerable<CellData> CellDatas => _cells.Values;

        public int CellsCount => _cells.Count;

        public void ClearCells()
        {
            _cells.Clear();
        }

        public void AddCell(CellData cellData)
        {
            if (_cells.ContainsKey(cellData.AttachedBundleCell.Identifier))
                throw new ArgumentException();

            _cells.Add(cellData.AttachedBundleCell.Identifier, cellData);
        }

        public CellData GetCell(CellIdentifier cellIdentifier)
        {
            if (_cells.ContainsKey(cellIdentifier))
                return _cells[cellIdentifier];

            throw new KeyNotFoundException();
        }

        public CellData GetCell(int index)
        {
            if (index >= _cells.Count)
                throw new ArgumentOutOfRangeException();

            return _cells.ElementAt(index).Value;
        }
    }
}