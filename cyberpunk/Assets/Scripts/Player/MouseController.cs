using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField]
    private Transform playerRotation;

    [SerializeField]
    private Transform lookRotation;

    [SerializeField]
    private bool invert;

    [SerializeField]
    private Vector2 clamp_Limits = new Vector2(-70f, 80f);

    [SerializeField]
    private float sensitivity = 5f;

    private Vector2 player_Look_Angles;

    private Vector2 current_Player_Look;
  

    private float current_Rotation_Angle;




    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            playerLookAround();
        }
    }

    void playerLookAround()
    {
        current_Player_Look = new Vector2(Input.GetAxis("Mouse Y")
            , Input.GetAxis("Mouse X"));

        player_Look_Angles.x += current_Player_Look.x * sensitivity * (invert ? 1f : -1f);
        player_Look_Angles.y += current_Player_Look.y * sensitivity;

        player_Look_Angles.x = Mathf.Clamp(player_Look_Angles.x
            , clamp_Limits.x, clamp_Limits.y);

        lookRotation.localRotation = Quaternion.Euler(player_Look_Angles.x, 0f, current_Rotation_Angle);
        playerRotation.localRotation = Quaternion.Euler(0f, player_Look_Angles.y, 0f);

    }
}
