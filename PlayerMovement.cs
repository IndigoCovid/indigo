using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Animator animator;
    public bool isSprinting = false;
    public float sprintingMultiplier;





    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.rotation = Quaternion.Euler(45,0,0);
        animator = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            //movement
            float hoirzontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 movementDirection = new Vector3(hoirzontal, 0, vertical);
            movementDirection.Normalize();


            if (Input.GetKey(KeyCode.LeftShift))
            {
                isSprinting = true;
            }
            else
            {
                isSprinting = false;
            }


            if (isSprinting == true)
            {
                movementDirection *= sprintingMultiplier;
            }


            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

            


            //Animator
            if (movementDirection != Vector3.zero)
            {
                animator.SetBool("IsWalk", true);
                          }
            else
            {
                animator.SetBool("IsWalk", false);
            }

            if(isSprinting == true && movementDirection != Vector3.zero)
            {
                animator.SetBool("IsRun", true);
            }
            else
            {
                animator.SetBool("IsRun", false);
            }

           
            //FLIP
            Vector3 characterScale = transform.localScale;
            if (Input.GetAxis("Horizontal") < 0)
            {
                characterScale.x = -1;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                characterScale.x = 1;
            }
                    transform.localScale = characterScale;
                }
            }
        }
    

