using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colHandler : MonoBehaviour
{
    [SerializeField]
    GameObject prefabCell;

    [SerializeField]
    float speed=5f;

    int no;
    bool spawningComplete;
    gameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<gameManager>();
        spawn();
    }

    public void spawn()
    {
        if (this.transform.GetSiblingIndex() % 2 == 0)
            no = gM.cellsEven;
        else
            no = gM.cellsOdd;

        for (int i = 0; i < no; i++)
        {
            GameObject temp = Instantiate(prefabCell);
            temp.transform.SetParent(this.transform);
            temp.GetComponent<RectTransform>().sizeDelta = Vector2.one * gM.cellSize;
            temp.transform.localScale = Vector3.one;
            if (this.transform.GetSiblingIndex() % 2 == 0)
                temp.transform.localPosition = new Vector3(0f, ((temp.transform.GetSiblingIndex() - gM.cellsEven/2)+0.5f) * gM.cellSize, 0f);
            else
                temp.transform.localPosition = new Vector3(0f, ((temp.transform.GetSiblingIndex() - (gM.cellsOdd-1) / 2)) * gM.cellSize, 0f);
        }
        spawningComplete = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawningComplete)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                GameObject temp = this.transform.GetChild(i).gameObject;
                if (this.transform.GetSiblingIndex() % 2 == 0)
                    temp.transform.localPosition = Vector3.Lerp(temp.transform.localPosition, new Vector3(0f, ((temp.transform.GetSiblingIndex() - gM.cellsEven / 2) + 0.5f) * gM.cellSize, 0f),Time.deltaTime * speed);
                else
                    temp.transform.localPosition = Vector3.Lerp(temp.transform.localPosition, new Vector3(0f, ((temp.transform.GetSiblingIndex() - (gM.cellsOdd - 1) / 2)) * gM.cellSize, 0f),Time.deltaTime * speed);
            }
        }
    }

    public void remove(GameObject cell)
    {
        Destroy(cell.gameObject);
        GameObject temp = Instantiate(prefabCell);
        temp.transform.SetParent(this.transform);
        temp.GetComponent<RectTransform>().sizeDelta = Vector2.one * gM.cellSize;
        temp.transform.localScale = Vector3.one;
        temp.transform.SetAsLastSibling(); 
        if (this.transform.GetSiblingIndex() % 2 == 0)
            temp.transform.localPosition = new Vector3(0f, ((temp.transform.GetSiblingIndex() - gM.cellsEven / 2) + 0.5f) * gM.cellSize, 0f);
        else
            temp.transform.localPosition = new Vector3(0f, ((temp.transform.GetSiblingIndex() - (gM.cellsOdd - 1) / 2)) * gM.cellSize, 0f);

    }
}
