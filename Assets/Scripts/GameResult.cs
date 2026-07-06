using UnityEngine;

public class GameResult : MonoBehaviour 
{
        public GameObject[] titles; // [0] = 패배 / [1] = 승리

        public void GameOver()
        {
            titles[0].SetActive(true);
        }
        
        public void GameVictory()
        {
            titles[1].SetActive(true);
        }
}
