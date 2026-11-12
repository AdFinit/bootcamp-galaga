using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : Ship
{
    [SerializeField] private float limitX = 8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float direction = 0f;

        if(Keyboard.current.aKey.isPressed  || Keyboard.current.leftArrowKey.isPressed)
        {
            direction = -1f;
        }

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            direction = 1f;
        }

        Move(new Vector2(direction, 0f));

        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -limitX, limitX);

        transform.position = pos;

        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Shoot();
        }

        
    }

    public override void Shoot()
    {
        weapon.Shoot(transform.position, Vector2.up);
    }
}
