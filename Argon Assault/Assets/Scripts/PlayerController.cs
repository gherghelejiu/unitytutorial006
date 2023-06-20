using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;
    [SerializeField] GameObject[] guns;
    [SerializeField] float verticalSpeedFactor = 30f;
    [SerializeField] float horizontalSpeedFactor = 50f;
    [SerializeField] float pitchFactor = -3f;
    [SerializeField] float yawFactor = 2.5f;
    [SerializeField] float rollFactor = -20f;
    float horizontalThrow = 0f;
    float verticalThrow = 0f;


    private void OnEnable()
    {
        movement.Enable();
        fire.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessFiring()
    {
        Fire(fire.ReadValue<float>() > 0.4f);
    }

    private void Fire(bool on)
    {
        foreach (GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = on;
        }
    }

    private void ProcessRotation()
    {
        float pitch = pitchFactor * transform.localPosition.y;
        //Debug.Log($"pitch = {pitch}, local y = {transform.localPosition.y}");
        float yaw = yawFactor * transform.localPosition.x;
        //Debug.Log($"yaw = {yaw}, local x = {transform.localPosition.x}");
        float roll = rollFactor * horizontalThrow;
        //
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        //float horizontalThrow = Input.GetAxis("Horizontal");
        horizontalThrow = movement.ReadValue<Vector2>().x;
        // Debug.Log($"horizontal {horizontalThrow}");
        // 
        //float verticalThrow = Input.GetAxis("Vertical");
        verticalThrow = movement.ReadValue<Vector2>().y;
        // Debug.Log($"vertical {verticalThrow}");

        float offsetX = Time.deltaTime * horizontalThrow * horizontalSpeedFactor;
        float offsetY = Time.deltaTime * verticalThrow * verticalSpeedFactor;

        float newX = transform.localPosition.x + offsetX;
        float newY = transform.localPosition.y + offsetY;

        transform.localPosition = new Vector3(
            Mathf.Clamp(newX, -12f, 12f),
            Mathf.Clamp(newY, -8f, 12f),
            transform.localPosition.z);
    }

    private void OnDisable()
    {
        movement.Disable();
        fire.Disable();
    }
}
