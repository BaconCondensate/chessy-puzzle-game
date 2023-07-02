using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUI : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(UI, new Vector3(100, 100), Quaternion.identity);
    }
}
