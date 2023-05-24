// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class ShowItems : MonoBehaviour
// {
//     public GameObject P1, P2;
//     public Sprite[] Items;
//     public GameObject[] ItemSlotsP1;
//     public GameObject[] ItemSlotsP2;
    
//     // Update is called once per frame
//     void Update()
//     {
//         //P1
//         if(P1.transform.GetComponent<PlayerController>().hasKey1 == true)
//         {
//             ItemSlotsP1[0].transform.GetComponent<Image>().sprite = Items[0];
//             ItemSlotsP1[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Items[0].name;

//         }
//         if(P1.transform.GetComponent<PlayerController>().hasKey2 == true)
//         {
//             ItemSlotsP1[1].transform.GetComponent<Image>().sprite = Items[1];
//             ItemSlotsP1[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Items[1].name;

//         }
//         if(P1.transform.GetComponent<PlayerController>().hasPeca == true)
//         {
//             ItemSlotsP1[2].transform.GetComponent<Image>().sprite = Items[2];
//             ItemSlotsP1[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Items[2].name;

//         }
//         if(P1.transform.GetComponent<PlayerController>().hasEye == true)
//         {
//             ItemSlotsP1[3].transform.GetComponent<Image>().sprite = Items[3];
//             ItemSlotsP1[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Items[3].name;
//         }

//         // P2
//         if(P2.transform.GetComponent<PlayerController>().hasKey1 == true)
//         {
//             ItemSlotsP2[0].transform.GetComponent<Image>().sprite = Items[0];
//             ItemSlotsP2[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Items[0].name;

//         }
//         if(P2.transform.GetComponent<PlayerController>().hasKey2 == true)
//         {
//             ItemSlotsP2[1].transform.GetComponent<Image>().sprite = Items[1];
//             ItemSlotsP2[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Items[1].name;

//         }
//         if(P2.transform.GetComponent<PlayerController>().hasPeca == true)
//         {
//             ItemSlotsP2[2].transform.GetComponent<Image>().sprite = Items[2];
//             ItemSlotsP2[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Items[2].name;

//         }
//         if(P2.transform.GetComponent<PlayerController>().hasEye == true)
//         {
//             ItemSlotsP2[3].transform.GetComponent<Image>().sprite = Items[3];
//             ItemSlotsP2[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Items[3].name;
//         }
//     }
// }
