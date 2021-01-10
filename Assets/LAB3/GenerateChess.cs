using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChess : MonoBehaviour
{

    public int horizontal;
    public int vertical;
    public GameObject white;
    public GameObject black;

    private void Awake()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        for(int x = 0; x < horizontal; x++)
        {
            for(int y = 0; y < vertical; y++)
            {
                if ((x + y) % 2 == 0)
                {
                    Instantiate(white, new Vector3(x, y, 0), Quaternion.Euler(0f, 0f, 0f));
                }
                else
                {
                    Instantiate(black, new Vector3(x, y, 0), Quaternion.Euler(0f, 0f, 0f));
                }
            }
        }
    }
}
