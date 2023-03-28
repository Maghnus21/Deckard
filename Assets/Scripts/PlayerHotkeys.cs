using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHotkeys : MonoBehaviour
{
    public Gun[] loadout = new Gun[10];
    public Gun equipted_gun;


    //  object references to be parsed to weapons
    [Header("Objects only parsed to weapons")]
    public Camera main_cam;
    public Transform player_chest;
    public ParticleSystem bullet_impact_effect;
    public Transform raycast_destination;
    public TextMeshProUGUI ammo_text;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
