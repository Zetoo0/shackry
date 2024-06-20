using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mouse : MonoBehaviour
{
    public float sensit = 100.0f;

    public Transform body;
    public Transform weapon;

    private float _rotation_ = 0f;

    [SerializeField] GameObject ideCam;
    [SerializeField]Transform camTrans;
    Vector3 camVec;
    Vector3 ideVec;
    float _mouse_x_rotation;
    float _mouse_y_rotation;

    private float _z_rot;
    
    Vector2 MouseInput;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void ReceiveInput(Vector2 mouseInput)
    {
        _mouse_x_rotation = mouseInput.x;
        _mouse_y_rotation = mouseInput.y;
        //print(mouseInput);
    }

   
    private void Update()
    {

        float MouseX = _mouse_x_rotation * sensit * Time.deltaTime;
        float MouseY = _mouse_y_rotation * sensit * Time.deltaTime;


        _rotation_ -= MouseY;
        _rotation_ = Mathf.Clamp(_rotation_, -90f, 90f);

        _z_rot -= _mouse_x_rotation * sensit/2 * Time.deltaTime;
        _z_rot = Mathf.Clamp(_z_rot, -5f, 5f);
        
        
        transform.localRotation = Quaternion.Euler(_rotation_, 0f, 0f);

        body.Rotate(Vector3.up* MouseX);

        //weapon.Rotate(Vector3.up * MouseX); ezt amúgy miért raktam bele? hmm *thinking*
    }

    // Update is called once per frame Input.GetAxis("Mouse X") Input.GetAxis("Mouse Y")


}
