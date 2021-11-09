using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;
using UnityEngine.AI;

namespace Examples
{
    public class ChickenPickUp : MonoBehaviour
    {
        NavMeshAgent agent;

        public GameObject player;
        public Transform pickUpDest;
        public Rigidbody pickupitem;

        private SphereCollider sc = new SphereCollider();
        private Animator anim = new Animator();
        public bool isPickUp;

        public AudioSource pickUp;

        public TCKButton pickBtn;
        public TCKButton unpickBtn;

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();

            // Get components inside the script so we won't have to manually place them in inside the inspector [START]
            player = GameObject.Find("Player");

            GameObject theDestination = GameObject.Find("PickUpDestination");
            pickUpDest = theDestination.GetComponent<Transform>();

            pickupitem = GetComponent<Rigidbody>();

            pickUp = GameObject.Find("HarvestSound").GetComponent<AudioSource>();
            // [END]

            sc = gameObject.GetComponent<SphereCollider>();
            anim = player.GetComponent<Animator>();
            //sc.radius = 2.5f;
            isPickUp = false;
        }

        // Update is called once per frame
        void Update()
        {
            pickBtn = GameObject.Find("pickBtn").GetComponent<TCKButton>();

            unpickBtn = GameObject.Find("unpickBtn").GetComponent<TCKButton>();

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
                pickupitem.constraints = RigidbodyConstraints.None;
                anim.SetBool("isPickup", false);
                pickupitem.useGravity = true;
                pickupitem.transform.parent = null;
                ActivatePickBtn();
            }

            /*if (AltarScript.sacrificeForChicPick == true)
            {
                anim.SetBool("isPickup", false);
                AltarScript.sacrificeForChicPick = false;
            }*/
        }

        void ActivateUnpickBtn()
        {
            pickBtn.isEnable = false;
            unpickBtn.isEnable = true;
        }

        void ActivatePickBtn()
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

