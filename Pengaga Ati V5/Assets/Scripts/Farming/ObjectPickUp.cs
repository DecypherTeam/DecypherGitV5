using System.Collections;
using System.Collections.Generic;
using TouchControlsKit;
using UnityEngine;

namespace Examples
{
    public class ObjectPickUp : MonoBehaviour
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

        public GameObject mesh;

        public static bool carryingBag = false;

        void Start()
        {
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

        private void Update()
        {
            pickBtn = GameObject.Find("pickBtn").GetComponent<TCKButton>();

            unpickBtn = GameObject.Find("unpickBtn").GetComponent<TCKButton>();

            if (TCKInput.GetAction("pickBtn", EActionEvent.Click))
            {
                if (isPickUp)
                {
                    carryingBag = true;
                    Player.carryObject = true;
                    //mesh.GetComponent<Renderer>().material.color = Color.white;
                    mesh.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
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
                carryingBag = false;
                Player.carryObject = false;
                pickupitem.constraints = RigidbodyConstraints.FreezeRotation;
                anim.SetBool("isPickup", false);
                pickupitem.useGravity = true;
                pickupitem.transform.parent = null;
                mesh.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
                ActivatePickBtn();
            }

            if(plantScript.seedPlanted == true || ScorePoint.delivered == true)
            {
                anim.SetBool("isPickup", false);
                ActivatePickBtn();
                plantScript.seedPlanted = false;
                ScorePoint.delivered = false;
            }
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
            if (other.gameObject.tag == "Player" && Player.carryObject == false)
            {
                //mesh.GetComponent<Renderer>().material.color = Color.red;
                mesh.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                mesh.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.cyan);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            /*togglePickUp(other);*/
            isPickUp = false;
            if (other.gameObject.tag == "Player")
            {
                //mesh.GetComponent<Renderer>().material.color = Color.white;
                mesh.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
            }
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

