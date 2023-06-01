using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine_Manage : MonoBehaviour
{
    public float timeAfterMinePlant { get; set; } // 지뢰 설치 후 경과 시간

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterMinePlant += Time.deltaTime;
    }
}
