using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XRInstantiateGrabbableObject : XRBaseInteractable
{
    [SerializeField] private GameObject grabbableObject; // Objeto a ser instanciado
    [SerializeField] private Transform transformToInstantiate; // Posição inicial da instância
    private int maxIngredient = 5;
    private int countIngredient;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Obtém o interactor (mão que interagiu com o objeto)
        IXRSelectInteractor interactor = args.interactorObject as IXRSelectInteractor;

        if (grabbableObject != null && interactor != null)
        {
            if (countIngredient > 5)
            { 
                // Instancia o objeto na posição da mão que interagiu
                GameObject newObject = Instantiate(grabbableObject, interactor.transform.position, interactor.transform.rotation);

                // Certifica-se de que o objeto tem um XRGrabInteractable
                XRGrabInteractable objectInteractable = newObject.GetComponent<XRGrabInteractable>();
                if (objectInteractable == null)
                {
                    objectInteractable = newObject.AddComponent<XRGrabInteractable>();
                }

                // Faz com que o objeto siga a mão sem ser filho
                objectInteractable.attachTransform = interactor.GetAttachTransform(null);

                // Faz com que o interactor (mão) automaticamente segure o objeto instanciado
                interactionManager.SelectEnter(interactor, objectInteractable);
                countIngredient++;
            }
        }

        base.OnSelectEntered(args);
    }
}
