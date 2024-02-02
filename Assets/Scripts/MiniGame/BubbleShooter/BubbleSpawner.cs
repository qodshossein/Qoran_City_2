using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame.BubbleShooter
{
    public class BubbleSpawner : MonoBehaviour
    {
        [SerializeField] private Vector2Int matrix;
        [SerializeField] private Vector2 spacing = new Vector2 (1, 1);
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Transform[] bubblesPrefab;

        private void Awake()
        {
            Spawn();
        }

        private void Spawn() 
        {
            for (int i = 0; i < matrix.y; i++)
            {
                for (int j = 0; j < matrix.x; j++)
                {
                    var posX = j * spacing.x;
                    var posY = i * -spacing.y;
                    var pos = new Vector2 (posX, posY);
                    pos += (Vector2)spawnPoint.position;

                    var bubble = Instantiate(GetBubble(), pos, Quaternion.identity);
                }
            }
        }

        private Transform GetBubble() 
        {
            var randomIndex = Random.Range(0, bubblesPrefab.Length);
            return bubblesPrefab[randomIndex];
        }
    }
}
