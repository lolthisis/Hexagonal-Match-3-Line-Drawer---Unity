using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cellHandler : MonoBehaviour
{
    [SerializeField]
    Color[] colors;

    int type;

    [SerializeField]
    RawImage img, selected;

    public LineRenderer line;

    [HideInInspector]
    public GameObject connectTo;

    gameManager gM;

    [HideInInspector]
    public bool isAdded;

    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<gameManager>();
        type = Random.Range(0, colors.Length);
        img.color = colors[type];
        line.SetPosition(0, Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        if (connectTo)
            line.SetPosition(1, new Vector3(connectTo.transform.parent.localPosition.x-this.transform.parent.localPosition.x, connectTo.transform.localPosition.y - this.transform.localPosition.y,0f));
        else
            line.SetPosition(1, Vector3.zero);

        if (gM.currentType != -1)
        {
            if (isAdded)
                selected.gameObject.SetActive(true);
            else
                selected.gameObject.SetActive(false);
        }
    }

    public void highlight(bool temp)
    {
        if (gM.currentType != -1)
        {
            if (gM.currentType == type)
            {
                if (!gM.currentSequence.Contains(this))
                {
                    float dist = Vector3.Distance(new Vector3(gM.currentSequence[gM.currentSequence.Count - 1].transform.parent.localPosition.x, gM.currentSequence[gM.currentSequence.Count - 1].transform.localPosition.y, 0f), new Vector3(this.transform.parent.localPosition.x, this.transform.localPosition.y, 0f));
                 
                    if (dist < (gM.cellSize * 1.2f))
                    {
                        gM.currentSequence[gM.currentSequence.Count - 1].connectTo = this.gameObject;
                        gM.currentSequence.Add(this);
                        isAdded = true;
                    }
                }
                else if (gM.currentSequence.Count > 1)
                {
                    if (gM.currentSequence[gM.currentSequence.Count - 2] == this)
                    {
                        gM.currentSequence[gM.currentSequence.Count - 1].isAdded = false;
                        gM.currentSequence[gM.currentSequence.Count - 2].connectTo = null;
                        gM.currentSequence.RemoveAt(gM.currentSequence.Count - 1);
                    }
                }
            }
        }
        else
        {
            if (temp)
                selected.gameObject.SetActive(true);
            else
                selected.gameObject.SetActive(false);
        }
    }

    public void onDown()
    {
        gM.currentSequence.Clear();
        gM.currentSequence.Add(this);
        this.isAdded = true;
        gM.currentType = type;
    }

    public void remove()
    {
        this.GetComponentInParent<colHandler>().remove(this.gameObject);
    }

    public void reset()
    {
        selected.gameObject.SetActive(false);
    }
}
