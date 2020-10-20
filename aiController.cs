using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiController : MonoBehaviour
{
    public string name;

    void Start(){

      name = aiCreator.weebNameGenerator();
      Debug.Log(name);

    }
}
