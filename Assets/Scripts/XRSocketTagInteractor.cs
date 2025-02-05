using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class XRSocketTagInteractor : UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor
{
    public string targetTag;

    public override bool CanHover(UnityEngine.XR.Interaction.Toolkit.Interactables.IXRHoverInteractable interactable)
    {
        return base.CanHover(interactable) && interactable.transform.tag == targetTag;
    }

    public override bool CanSelect(UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable interactable)
    {
        return base.CanSelect(interactable) && interactable.transform.tag == targetTag;
    }
}
