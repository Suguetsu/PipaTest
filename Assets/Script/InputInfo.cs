
using UnityEngine.EventSystems;
using UnityEngine;
using Sugue;

// Responsável por cotrolar o input na tela.

[RequireComponent(typeof(SlotControll))]

public class InputInfo : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private SlotControll _Slot;

    // verifica se o slote foi ou não apertado
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_Slot.isSelect)
        {
            _Slot.FindNumber();
          
        }
       

    }

}
