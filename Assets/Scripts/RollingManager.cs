using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class RollingManager : MonoBehaviour
{
    [SerializeField] private GameObject dought;
    [SerializeField] private GameObject pizzaBase;
    private XRGrabInteractable grabInteractable;
    private HashSet<XRBaseInteractor> interactors = new HashSet<XRBaseInteractor>();

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        interactors.Add((XRBaseInteractor)args.interactorObject);
    }

    void OnRelease(SelectExitEventArgs args)
    {
        interactors.Remove((XRBaseInteractor)args.interactorObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dough") && interactors.Count == 2)
        {
            Instantiate(pizzaBase, dought.transform.position, Quaternion.identity);
            Destroy(dought);

        }
    }
}
