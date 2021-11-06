using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;
using UnityEngine.AI;

namespace Examples
{
    public class ChickenPickUp : MonoBehaviour
    {
        public GameObject player;
        public Transform pickUpDest;
        public Rigidbody pickupitem;

        private SphereCollider sc = new SphereCollider();
        private Animator anim = new Animator();
        public bool isPickUp;

        public AudioSource pickUp;

        public TCKButton pickBtn;
        public TCKButton unpickBtn;

        public static bool chickenGone = false;

        NavMeshAgent agent;

        public GameObject[] chickenCheck;

        void Start()
        {
            // Get components inside the script so we won't have to manually place them in inside the inspector [START]
            player = GameObject.Find("Player");

            GameObject theDestination = GameObject.Find("PickUpDestination");
            pickUpDest = theDestination.GetComponent<Transform>();

            pickupitem = GetComponent<Rigidbody>();

            pickUp = GameObject.Find("HarvestSound").GetComponent<AudioSource>();

            agent = GetComponent<NavMeshAgent>();

            pickBtn = GameObject.Find("pickBtn").GetComponent<TCKButton>();

            unpickBtn = GameObject.Find("unpickBtn").GetComponent<TCKButton>();
            // [END]

            sc = gameObject.GetComponent<SphereCollider>();
            anim = player.GetComponent<Animator>();
            sc.radius = 2.5f;
            isPickUp = false;
        }

        private void Update()
        {
            if (TCKInput.GetAction("pickBtn", EActionEvent.Click))
            {
                if (isPickUp)
                {
                    gameObject.GetComponent<NavMeshAgent>().enabled = false;
                    Player.carryObject = true;
                    anim.SetBool("isPickup", true);
                    transform.position = pickUpDest.position;
                    pickupitem.useGravity = false;
                    pickupitem.transform.parent = pickUpDest.transform;
                    pickupitem.constraints = RigidbodyConstraints.FreezeAll;
                    isPickUp = false;
                    pickUp.Play();
                    ActivateUnpickBtn();
                }
            }

            if (TCKInput.GetAction("unpickBtn", EActionEvent.Click))
            {
                gameObject.GetComponent<NavMeshAgent>().enabled = true;
                Player.carryObject = false;
                pickupitem.constraints = RigidbodyConstraints.FreezeRotation;
                anim.SetBool("isPickup", false);
                pickupitem.useGravity = true;
                pickupitem.transform.parent = null;
                ActivatePickBtn();
            }

            if(chickenGone == true)
            {
                print("it works bro");
                anim.SetBool("isPickup", false);
                //ActivatePickBtn();
                chickenGone = false;
            }

            /*chickenCheck = GameObject.FindGameObjectsWithTag("NPC");
            if (chickenCheck.Length == 0)
            {
                print("chicken is one");
                anim.SetBool("isPickup", false);
            }*/
        }

        void ActivateUnpickBtn()
        {
            pickBtn.isEnable = false;
            unpickBtn.isEnable = true;
        }

        public void ActivatePickBtn()
        {
            unpickBtn.isEnable = false;
            pickBtn.isEnable = true;
        }

        private void OnTriggerStay(Collider other)
        {
            togglePickUp(other);
        }

        private void OnTriggerExit(Collider other)
        {
            /*togglePickUp(other);*/
            isPickUp = false;
        }

        private void togglePickUp(Collider other)
        {
            if (other.gameObject.tag == "Player" && Player.carryObject == false)
            {
                isPickUp = true;
            }
        }
    }
}

