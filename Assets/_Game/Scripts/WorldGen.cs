using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private int worldSize = 2;
    
    void Start()
    {
        for (int width = 0; width < worldSize; width++)
        {
            for (int height = 0; height < worldSize; height++)
            {
                for (int depth = 0; depth < worldSize; depth++)
                {
                    Vector3 newPos = new Vector3(width, height, depth);
                    Instantiate(cube, newPos, Quaternion.identity);
                }
            }
            
        }
    }

}
