using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MoldInteractable : TouchInteractable
{
    [SerializeField] private LineRenderer templateShapeRenderer;    // Guía de la forma del molde
    [SerializeField] private LineRenderer currentShapeRenderer;
    public override void OnHoverEnter(HoverEnterEventArgs args){
        Debug.Log(args.interactorObject.transform.localPosition);
    }

    public void renderTemplateShape(Vector3[] positions){
        templateShapeRenderer.positionCount = positions.Length;
        templateShapeRenderer.SetPositions(positions);
    }
}
