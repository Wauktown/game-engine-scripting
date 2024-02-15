using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Batlleship
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private int[,] grid = new int[,]
        {
            // Top left is (0,0)
            {1,1,0,0,1},
            {0,0,0,0,0 },
            {0,0,1,0,1 },
            {1,0,1,0,0 },
            {1,0,1,0,1 }
            // Bottom right is 4,4
        };
        // Represents where the player has fired
        private bool[,] hits;

        // Total rows and columns we have
        private int nRows;
        private int nCols;
        // Current row/colum we are on
        private int row;
        private int col;
        // Correctly hit ships
        private int score;
        // Total time game has been running
        private int time;

        // Parent of all cells
        [SerializeField] Transform gridRoot;
        // Template used to populate the grid
        [SerializeField] GameObject cellPrefab;
        [SerializeField] GameObject winLabel;
        [SerializeField] TextMeshProUGUI timeLabel;
        [SerializeField] TextMeshProUGUI scoreLabel;

        private void Awake()
        {
            // Initialize rows/cols to help us with our operations
            nRows = grid.GetLength(0);
            nCols = grid.GetLength(1);
            // Create identical 2D array to grid that is of the type bool instead of int
            hits = new bool[nRows, nCols];

            // Populate the grid using a loop
            // Needs to execute as many times to fill up the grid
            // Can figure that out by calculating rows * cols
            for (int i = 0; i < nRows * nCols; i++)
            {
                // Create an instance of the prefab and child it to the gridRoot
                Instantiate(cellPrefab, gridRoot);
            }
            SelectCurrentCell();
            InvokeRepeating("IncrementTime", 1f, 1f);
        }
        Transform GetCurrentCell()
        {
            // you can figure out the child index
            // of the cell that is a part of the grid
            // by calculating (row*Cols) + col
            int idex = (row * nCols) + col;
            // Return the child by index
            return gridRoot.GetChild(idex);
        }
        void SelectCurrentCell()
        {
            // Get the current cell
            Transform cell = GetCurrentCell();
            // Set the "Cursor" image on
            Transform cursor = cell.Find("Cursor");
            cursor.gameObject.SetActive(true);
        }

        void UnselectCurrentCell()
        {
            // Get the current cell
            Transform cell = GetCurrentCell();
            // Set the "Cursor" image off
            Transform cursor = cell.Find("Cursor");
            cursor.gameObject.SetActive(false);
        }

        public void MoveHorizontal(int amt)
        {
            // Since we are movif to a new cell
            // we need to unselect the previous one
            UnselectCurrentCell();

            // Update the column
            col += amt;
            // Make sure the column stays within the bounds of the grid
            col = Mathf.Clamp(col, 0, nCols - 1);

            // Select the new cell
            SelectCurrentCell();
        }
        public void MoveVertical(int amt)
        {
            // Since we are moving to a new cell
            // we need to unselect the previous one
            UnselectCurrentCell();

            // Update the column
            row += amt;
            // Make sure the column stays within the bounds of the grid
            row = Mathf.Clamp(row, 0, nRows - 1);

            // Select the new cell
            SelectCurrentCell();
        }
        void ShowHit()
        {
            // Get the current cell
            Transform cell = GetCurrentCell();
            // Set the "Hit" image on
            Transform hit = cell.Find("Hit");
            hit.gameObject.SetActive(true);
        }
        void ShowMiss()
        {
            // Get the current cell
            Transform cell = GetCurrentCell();
            // Set the "Miss" image on
            Transform miss = cell.Find("Miss");
            miss.gameObject.SetActive(true);
        }
        private void IncrementScore()
        {
            // Add 1 to the core
            score++;
            // update the score label with current score
            if (scoreLabel == null) Debug.Log("Checking score");
            scoreLabel.text = string.Format("Score: {0}", score);
        }
        public void Fire()
        {
            if (hits[row, col]) return;
            hits[row, col] = true;

            if (grid[row, col] == 1)
            {
                ShowHit();
                IncrementScore();
            }



            else
            {
                ShowMiss();
            }



        }
        void TryEndGame()
        {
            for (int row = 0; row < nRows; row++)
            {
                for (int col = 0; col < nCols; col++)
                {
                    if (grid[row, col] == 0) continue;
                    if (hits[row, col] == false) return;
                }
            }
            winLabel.SetActive(true);
            CancelInvoke("IncrementTime");
        }
        void IncrementTime()
        {
            time++;

            if (timeLabel == null) Debug.Log("Checking Time");
            timeLabel.text = string.Format("{0}:{1}", time / 60, (time % 60).ToString("00"));
        }
        public void Restart()
        {
            // Reset variables
            score = 0;
            time = 0;
            row = 0;
            col = 0;

            // Randomly reposition ships
            RandomlyRepositionShips();

            // Reset hits array
            hits = new bool[nRows, nCols];

            // Reset UI elements
            scoreLabel.text = "Score: 0";
            timeLabel.text = "0:00";
            winLabel.SetActive(false);

            // Reset all cell states
            for (int i = 0; i < gridRoot.childCount; i++)
            {
                Transform cell = gridRoot.GetChild(i);
                Transform cursor = cell.Find("Cursor");
                cursor.gameObject.SetActive(false);

                Transform hit = cell.Find("Hit");
                hit.gameObject.SetActive(false);

                Transform miss = cell.Find("Miss");
                miss.gameObject.SetActive(false);
            }

            // Select the starting cell
            SelectCurrentCell();

            // Restart timer
            CancelInvoke("IncrementTime");
            InvokeRepeating("IncrementTime", 1f, 1f);
        }

        private void RandomlyRepositionShips()
        {
            for (int r = 0; r < nRows; r++)
            {
                for (int c = 0; c < nCols; c++)
                {
                    // Do a random roll between 0 and 10
                    int roll = Random.Range(0, 11);
                    // If the number is greater than 5, make it a 1, otherwise make it a 0
                    grid[r, c] = roll > 5 ? 1 : 0;
                }

                // Start is called before the first frame update
                void Start()
                {

                }

                // Update is called once per frame
                void Update()
                {

                }
            }
        }
    }
}
