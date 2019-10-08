using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    [HideInInspector]
    public float padding,cellSize;

    [HideInInspector]
    public int cellsEven, cellsOdd, cols, moves;

    [SerializeField]
    GameObject prefabCol,canvas, gameover;

    [HideInInspector]
    public List<cellHandler> currentSequence;

    [HideInInspector]
    public int currentType;

    private int score;

    [SerializeField]
    Text movesText, scoreText, combo;

    void Awake()
    {
        //Init Value
        padding = 112f;
        cellSize = 128f;
        cellsOdd = 7;
        cellsEven = 6;
        cols = 7;
        moves = 10;
        score = 0;
        currentType = -1;

        movesText.text = "Moves: " + moves + " left!";
        scoreText.text = "" + score;

        //Instantiate the field
        for (int i = 0; i < cols; i++)
        {
            GameObject temp = Instantiate(prefabCol);
            temp.transform.SetParent(canvas.transform);
            temp.transform.localScale = Vector3.one;
            float x;
            if (cols % 2 == 0)
                x = ((temp.transform.GetSiblingIndex() - cols / 2) - 0.5f) * padding;
            else
                x = (temp.transform.GetSiblingIndex() - (cols-1) / 2) * padding;
            temp.transform.localPosition = new Vector3(x, 0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            evaluate();
        }

        //Restart level
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        //Combo system
        if (currentSequence.Count > 0)
        {
            combo.text = currentSequence.Count + "x";
            combo.transform.localScale = Vector3.one * (0.5f + (0.2f * currentSequence.Count));
        }
        else
            combo.text = "";
    }

    //Evaluate current sequence
    void evaluate()
    {
        if (currentSequence.Count >= 3)
        {
            if (moves > 1)
                moves--;
            else
                gameover.SetActive(true);

            movesText.text = "Moves: "+moves + " left!";

            score += (int)Mathf.Pow(currentSequence.Count,2);
            scoreText.text = "" + score;

            for (int i = 0; i < currentSequence.Count; i++)
            {
                currentSequence[i].remove();
            }
        }

        for (int i = 0; i < currentSequence.Count; i++)
        {
            currentSequence[i].isAdded = false;
            currentSequence[i].connectTo = null;
            currentSequence[i].reset();
        }
        currentSequence.Clear();
        currentType = -1;
    }
}
