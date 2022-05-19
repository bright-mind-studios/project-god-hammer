using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TransparentGrabInteractable : OffsetGrabInteractable
{
    private Material interactorMaterial;
    private SkinnedMeshRenderer interactorRenderer;

    [System.Obsolete]
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        EnableMapGrid();
        SetObjectTransparency();
        //interactorRenderer = FindAndStoreInteractorMaterial(interactor);
        //SetInteractorTransparency();
    }

    private void EnableMapGrid()
    {
        GameObject.FindGameObjectWithTag("MinimapCamera").GetComponent<Camera>().cullingMask |= (1 << 21);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().cullingMask |= (1 << 22);
    }

    private void SetObjectTransparency()
    {
        MeshRenderer renderer = gameObject.GetComponentInChildren<MeshRenderer>();
        renderer.material.color = new Color(renderer.materials[0].color.r, renderer.materials[0].color.g, renderer.materials[0].color.b, 0.75f);
    }

    private SkinnedMeshRenderer FindAndStoreInteractorMaterial(XRBaseInteractor interactor)
    {
        SkinnedMeshRenderer skinnedMeshRenderer = null;

        foreach (Transform item in interactor.gameObject.transform.GetComponentsInChildren<Transform>())
        {
            if (item.GetComponent<SkinnedMeshRenderer>() != null)
            {
                skinnedMeshRenderer = item.GetComponent<SkinnedMeshRenderer>();
                break;
            }
        }

        interactorMaterial = skinnedMeshRenderer.material;
        return skinnedMeshRenderer;
    }

    private void SetInteractorTransparency()
    {
        interactorRenderer.material = gameObject.GetComponentInChildren<MeshRenderer>().material;
    }

    [System.Obsolete]
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        DisableMapGrid();
        ResetObjectTransparency();
        //ResetInteractorMaterial();
    }

    private void DisableMapGrid()
    {
        GameObject.FindGameObjectWithTag("MinimapCamera").GetComponent<Camera>().cullingMask &= ~(1 << 21);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().cullingMask &= ~(1 << 22);
    }

    private void ResetObjectTransparency()
    {
        MeshRenderer renderer = gameObject.GetComponentInChildren<MeshRenderer>();
        renderer.material.color = new Color(renderer.materials[0].color.r, renderer.materials[0].color.g, renderer.materials[0].color.b, 1f);
    }

    private void ResetInteractorMaterial()
    {
        interactorRenderer.material = interactorMaterial;
        interactorMaterial = null;
    }
}
