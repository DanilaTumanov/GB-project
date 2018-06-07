using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    protected float moveSpeed = 1f;
	
    public void Move(Vector3 movement)
    {
        transform.position += movement * Time.deltaTime * moveSpeed;
    }
}
