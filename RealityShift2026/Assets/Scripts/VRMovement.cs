using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class SimpleVRMove : MonoBehaviour
{
    public float speed = 2f;
    public Transform head;

    private InputDevice rightHand;

    void Update()
    {
        // reacquire device if needed
        if (!rightHand.isValid)
        {
            List<InputDevice> devices = new List<InputDevice>();
            InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);

            if (devices.Count > 0)
                rightHand = devices[0];
        }

        Vector2 input;
        if (rightHand.TryGetFeatureValue(CommonUsages.primary2DAxis, out input))
        {
            Debug.Log("Input: " + input);

            Vector3 forward = head.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = head.right;
            right.y = 0;
            right.Normalize();

            Vector3 move = forward * input.y + right * input.x;

            transform.position += move * speed * Time.deltaTime;
        }
    }
}