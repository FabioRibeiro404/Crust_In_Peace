using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XRInstantiateGrabbableObject : XRBaseInteractable
{
    [SerializeField] private GameObject grabbableObject; // Objeto a ser instanciado
    [SerializeField] private Transform transformToInstantiate; // Posição inicial da instância
    private const int maxIngredient = 5;
    private Queue<GameObject> instantiatedObjects = new Queue<GameObject>();

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        IXRSelectInteractor interactor = args.interactorObject as IXRSelectInteractor;

        if (grabbableObject != null && interactor != null)
        {
            // Se o número máximo foi atingido, remove o mais antigo
            if (instantiatedObjects.Count >= maxIngredient)
            {
                GameObject oldestObject = instantiatedObjects.Dequeue();
                if (oldestObject != null)
                {
                    Destroy(oldestObject);
                }
            }

            // Instancia novo objeto e adiciona à fila
            GameObject newObject = Instantiate(grabbableObject, interactor.transform.position, interactor.transform.rotation);
            instantiatedObjects.Enqueue(newObject);

            // Configura interatividade XR
            XRGrabInteractable objectInteractable = newObject.GetComponent<XRGrabInteractable>();
            if (objectInteractable == null)
            {
                objectInteractable = newObject.AddComponent<XRGrabInteractable>();
            }

            objectInteractable.attachTransform = interactor.GetAttachTransform(null);
            interactionManager.SelectEnter(interactor, objectInteractable);
        }

        base.OnSelectEntered(args);
    }
}
