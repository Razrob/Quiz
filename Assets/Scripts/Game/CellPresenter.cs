using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellPresenter : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _background;
    [SerializeField] private EventTrigger _eventTrigger;
    public Image Image => _image;
    public Image Background => _background;
    public EventTrigger EventTrigger => _eventTrigger;
}
