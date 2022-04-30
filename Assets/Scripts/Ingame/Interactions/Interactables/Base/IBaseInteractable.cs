using UnityEngine.XR.Interaction.Toolkit;

public interface IBaseInteractable
{
    public bool IsOnGrip { get; set;}
    public bool IsOnTrigger { get; set;}
    public void OnHoverEnter(HoverEnterEventArgs args);
    public void OnHoverExit(HoverExitEventArgs args);
    public void OnGripStart();
    public void OnGripEnd();
    public void OnTriggerStart();
    public void OnTriggerEnd();
    public void ResetState();
}
