using System.Collections;
using System.Collections.Generic;
using Tweening;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MoldStation : Station
{
   
    [SerializeField] Mold mold; 
    [SerializeField] GameObject completeMold;
    [SerializeField] GameObject moldCube;
    [SerializeField] Transform moldFill;
    [SerializeField] float animation_time = 1f;
    [SerializeField] Transform weapon_SP;
    private bool filling = false;

    public IngotItem ingot;
    private WeaponShape currentShape;

    public void CompleteShape(WeaponShape shape)
    {
        currentShape = shape;
        completeMold = Instantiate(shape.moldPrefab, moldCube.transform.position, moldCube.transform.rotation);
        DisableMold();
    }

    private void DisableMold(){
        mold.gameObject.SetActive(false);
        moldCube.SetActive(false);
    }

    public void OnPressButton()
    {
        if(filling) return;

        if(ingot != null && completeMold != null)
        {
            Weapon weapon = new Weapon{
                shape = currentShape,
                element = (Element) ingot.resource
            };
            Destroy(ingot.gameObject);
            ingot = null;
            StartCoroutine(fillCorroutine(weapon));
        }
        else
            RestartMold();

    }

    public void RestartMold()
    {
        StopAllCoroutines();       

        if(completeMold != null) Destroy(completeMold);
        currentShape = null;
        mold.gameObject.SetActive(true);
        moldCube.SetActive(true);
    }

    public void FillMold()
    {
        if(currentShape == null) return;
    }

    public void OnPushMetalOre(SelectEnterEventArgs args)
    {
        IXRSelectInteractable ixrs = args.interactableObject;
        if (ixrs is IngotItem m) ingot = m;
    }

    public void OnPullMetalOre(SelectExitEventArgs args)
    {
        ingot = null;
    }

    private IEnumerator fillCorroutine(Weapon weapon)
    {
        filling = true;
        var current_time = 0f;
        var delta = 1f / animation_time;
        while(moldFill.localScale.y != 1f)
        {
            current_time += Time.deltaTime;
            var t = delta * current_time;
            moldFill.localScale = new Vector3(1, TweenUtils.SmoothLerp(0.1f, 1f, t), 1);
            yield return null;
        }
        var weaponobj = Instantiate(weapon.shape.weaponPrefab, weapon_SP.position, weapon_SP.rotation);
        weaponobj.GetComponent<WeaponItem>().SetElement(weapon.element);
        filling = false;
        RestartMold();
    }


}
