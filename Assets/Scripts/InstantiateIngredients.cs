using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XRInstantiateGrabbableObject : XRBaseInteractable
{
    [SerializeField] private GameObject grabbableObject; // Objeto a ser instanciado
    [SerializeField] private Transform transformToInstantiate; // Posi��o inicial da inst�ncia
    private int maxIngredient = 5;
    private int countIngredient;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Obt�m o interactor (m�o que interagiu com o objeto)
        IXRSelectInteractor interactor = args.interactorObject as IXRSelectInteractor;

        if (grabbableObject != null && interactor != null)
        {
            if (countIngredient > 5)
            { 
                // Instancia o objeto na posi��o da m�o que interagiu
                GameObject newObject = Instantiate(grabbableObject, interactor.transform.position, interactor.transform.rotation);

                // Certifica-se de que o objeto tem um XRGrabInteractable
                XRGrabInteractable objectInteractable = newObject.GetComponent<XRGrabInteractable>();
                if (objectInteractable == null)
                {
                    objectInteractable = newObject.AddComponent<XRGrabInteractable>();
                }

                // Faz com que o objeto siga a m�o sem ser filho
                objectInteractable.attachTransform = interactor.GetAttachTransform(null);

                // Faz com que o interactor (m�o) automaticamente segure o objeto instanciado
                interactionManager.SelectEnter(interactor, objectInteractable);
                countIngredient++;
            }
        }

        base.OnSelectEntered(args);
    }
}
