using System.Collections.Generic;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public enum CannulaStatus
{
    Insert,
    Withdraw,
    Advance,
    Remove
}
public class CannulaManager : MonoBehaviour
{
    public List<HandGrabInteractable> InsertHandGrabInteractable;
    public List<HandGrabInteractable> WithdrawHandGrabInteractable;
    public List<HandGrabInteractable> AdvanceHandGrabInteractable;
    public List<HandGrabInteractable> RemoveHandGrabInteractable;
    public CannulaStatus cannulaStatus = CannulaStatus.Insert;

    public void SetCannulaStatus(CannulaStatus status)
    {
        cannulaStatus = status;
        switch (cannulaStatus)
        {
            case CannulaStatus.Insert:
                
                break;
            case CannulaStatus.Withdraw:
                foreach (var interactable in InsertHandGrabInteractable)
                {
                    interactable.gameObject.SetActive(false);
                }
                foreach (var interactable in WithdrawHandGrabInteractable)
                {
                    interactable.gameObject.SetActive(true);
                }
                
                break;
            case CannulaStatus.Advance:
                foreach (var interactable in WithdrawHandGrabInteractable)
                {
                    interactable.gameObject.SetActive(false);
                }
                foreach (var interactable in AdvanceHandGrabInteractable)
                {
                    interactable.gameObject.SetActive(true);
                }
                
                break;
            case CannulaStatus.Remove:
                foreach (var interactable in AdvanceHandGrabInteractable)
                {
                    interactable.gameObject.SetActive(false);
                }
                foreach (var interactable in RemoveHandGrabInteractable)
                {
                    interactable.gameObject.SetActive(true);
                }
                break;
        }
    }

    public CannulaStatus GetCannulaStatus()
    {
        return cannulaStatus;
    }
    public void MoveToNextStep()
    {
        switch (cannulaStatus)
        {
            case CannulaStatus.Insert:
                SetCannulaStatus(CannulaStatus.Withdraw);
                break;
            case CannulaStatus.Withdraw:
                SetCannulaStatus(CannulaStatus.Advance);
                break;
            case CannulaStatus.Advance:
                SetCannulaStatus(CannulaStatus.Remove);
                break;
            case CannulaStatus.Remove:
                // Handle removal logic
                break;
        }
    }
}
