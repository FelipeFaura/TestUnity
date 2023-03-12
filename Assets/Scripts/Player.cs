using UnityEngine;

public class Player : MonoBehaviour
{
    public float dashValue = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashMovement();
        }
    }

    public void dashMovement()
    {
        this.transform.Translate(Vector3.right * dashValue);
    }
}
