using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class Growth : MonoBehaviour
    {
        public float timer = 0f;
        public float growTime = 6f;
        public float maxSize = 1f;

        public bool isMaxSize = false;

        public GameObject crop;
        public Rigidbody cropRb;

        public AudioSource eatSound;

        public static bool plantEaten = false;
        public static bool isHarvested = false;

        void Start()
        {
            crop.GetComponent<ObjectPickUp>().enabled = false;
        }

        void Update()
        {
            cropRb = GetComponent<Rigidbody>();

            if (isMaxSize == false && EndPos.handInPosition == true)
            {
                StartCoroutine(Grow());
            }

            if (isMaxSize == true)
            {
                crop.GetComponent<ObjectPickUp>().enabled = true;
                isHarvested = true;
            }

            eatSound = GameObject.Find("BoarEatSound").GetComponent<AudioSource>();
        }

        private IEnumerator Grow()
        {
            Vector3 startScale = transform.localScale;
            Vector3 maxScale = new Vector3(maxSize, maxSize, maxSize);

            do
            {
                transform.localScale = Vector3.Lerp(startScale, maxScale, timer / growTime);
                timer += Time.deltaTime;
                yield return null;
            }
            while (timer < growTime);

            isMaxSize = true;
        }

        public void OnCollisionEnter(Collision other)
        {
            if (other.collider.tag == "Enemy" || other.collider.tag == "Ghost")
            {
                eatSound.Play();
                Destroy(crop);
                plantEaten = true;
            }

            if (other.collider.tag == "Plant" || other.collider.tag == "Chillie Seedbag" || other.gameObject.name == "Sphere")
            {
                cropRb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }

    }
}

