using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BlockType
{
    Block =0,
    Empty = 1,
    Flag = 2,
    Q1 = 3,
    Q2 = 4,
    Mine = 5,
    MineExplode =6,
    MineDelete =7,
    N1 =8,
    N2 =9,
    N3 =10,
    N4 =11,
    N5 =12,
    N6 =13,
    N7 =14,
    N8 =15
}
public class Block : MonoBehaviour
{
    [SerializeField] private List<Sprite> blockSprites;

    public BlockType blockType = 0;
    public int i;
    public int j;

    public bool show;
    public bool flag;

    private SpriteRenderer _sb;

    private void Awake()
    {
        _sb = GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            Click();
        }
        if (Input.GetMouseButton(1))
        {
            ShowFlag();
        }
    }

    public void Click()
    {
        if (blockType == BlockType.Mine)
        {
            blockType = BlockType.MineExplode;
            FindObjectOfType<Board>().Lose();
        }
        else if (blockType == BlockType.Empty)
        {
            FindObjectOfType<Board>().RevealEmpty(i, j);
        }
        Reveal();
    }

    public void Reveal()
    {
        if (!show)
        {
            show = true;
            _sb.sprite = blockSprites[(int) blockType];
        }
    }
    public void ShowFlag()
    {
        if (!flag)
        {
            flag = true;
            _sb.sprite = blockSprites[(int) BlockType.Flag];
        }
    }
}
