using UnityEngine;

public class CloudControllerActions : MonoBehaviour
{
    public void Move()
    {
        GridMovement gridMovement = GameObject.FindObjectOfType<GridMovement>();

        if (gridMovement == null) return;

        gridMovement.Move();
    }
}
