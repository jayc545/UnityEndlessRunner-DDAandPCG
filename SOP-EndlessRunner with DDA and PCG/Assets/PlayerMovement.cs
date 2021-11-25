using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController PlayerController;

    public float speed; //


    void Update()    // Update is called once per frame´.
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;//Used so movent.


    }
}
