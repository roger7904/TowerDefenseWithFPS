using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpheight = 3f;

    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public GameObject weaponholder;
    public GameObject changeweapon;
    public GameObject changegrenade;
    Vector3 velocity;
    bool isGrounded;

    private float guntime;
    private bool isspecialgun=false;

    public static float playerPositionx;
	public static float playerPositionz;
	
	// Update is called once per frame
	void Update () {
        playerPositionx=transform.position.x;
        playerPositionz=transform.position.z;
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(isspecialgun)
        {
            guntime+=Time.deltaTime;
        }
        if(guntime>=5f){
            weaponholder.SetActive(true);
            changeweapon.SetActive(false);
            changegrenade.SetActive(false);
            guntime=0;
            isspecialgun=false;
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag=="pickweapon"){
            Debug.Log("weapon collider wake");
            Destroy (other.gameObject);
            weaponholder.SetActive(false);
            changeweapon.SetActive(true);
            changegrenade.SetActive(false);
            isspecialgun=true; 
        }
        if(other.tag=="grenade"){
            Debug.Log("grenade collider wake");
            Destroy (other.gameObject);
            weaponholder.SetActive(false);
            changeweapon.SetActive(false);
            changegrenade.SetActive(true);
        }

    }

    
}
