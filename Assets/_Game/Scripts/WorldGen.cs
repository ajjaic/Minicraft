using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private int cubeWidth = 10;
    [SerializeField] private int cubeDepth = 10;
    [SerializeField] private int cubeHeight = 2;
    
    void Start()
    {
        for (int width = 0; width < cubeWidth; width++)
        {
            for (int height = 0; height < cubeDepth; height++)
            {
                for (int depth = 0; depth < cubeHeight; depth++)
                {
                    Vector3 newPos = new Vector3(width, height, depth);
                    Instantiate(cube, newPos, Quaternion.identity);
                }
            }
            
        }
    }

}
