using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz
{
    [Serializable]
    public struct CellIdentifier
    {
        [SerializeField] private string _identifier;

        public CellIdentifier(string identifier) => _identifier = identifier;
        public CellIdentifier(CellIdentifier cellIdentifier) => _identifier = cellIdentifier._identifier;

        public static bool operator !=(CellIdentifier cellIdentifier1, CellIdentifier cellIdentifier2) => !(cellIdentifier1 == cellIdentifier2);
        public static bool operator ==(CellIdentifier cellIdentifier1, CellIdentifier cellIdentifier2) => 
            cellIdentifier1._identifier == cellIdentifier2._identifier;
        public override bool Equals(object obj)
        {
            string otherIdentifier = obj as string;
            if (otherIdentifier is null)
                return false;

            return _identifier.Equals(otherIdentifier);
        }

        public override int GetHashCode() => _identifier.GetHashCode();
        public override string ToString() => _identifier;
    }
}
