using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class AltarScript : MonoBehaviour
    {
        Player player;

        private void Start()
        {
            GameObject playerGameObject = GameObject.Find("Player");
            player = playerGameObject.GetComponent<Player>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "NPC")
            {
                Destroy(other.gameObject);
                Debug.Log("Chicken is sacrificed");
                if (other.gameObject == GameObject.Find("Chicken"))
                {
                    player.pickChic = null;
                }
                if (other.gameObject == GameObject.Find("Chicken 2"))
                {
                    player.pickChicSec = null;
                }
                if (other.gameObject == GameObject.Find("Chicken 3"))
                {
                    player.pickChicThird = null;
                }
                if (other.gameObject == GameObject.Find("Chicken 4"))
                {
                    player.pickChicFourth = null;
                }
            }
        }
    }
}

