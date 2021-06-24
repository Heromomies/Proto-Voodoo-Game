using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class Board : MonoBehaviour
{
    [SerializeField] private Block block;

    private int _w = 10;
    private int _h = 20;

    private Block[,] _blocks;
    
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Init()
    {
        _blocks = new Block[_w,_h];

        for (int i = 0; i < _w; i++)
        {
            for (int j = 0; j < _h; j++)
            {
                var blockType = GetBlockType();
                _blocks[i, j] = Instantiate(block, new Vector2(i, j), Quaternion.identity);
                _blocks[i, j].blockType = blockType;
                _blocks[i, j].i = i;
                _blocks[i, j].j = j;
            }
        }

        UpdateNearbyBlock();
    }

    private void UpdateNearbyBlock()
    {
        for (int i = 0; i < _w; i++)
        {
            for (int j = 0; j < _h; j++)
            {
                int n = 0;
                if(_blocks[i,j].blockType == BlockType.Mine)
                    continue;

                var list = GetAllNearbyBlock(i, j);
                
                // increase count of mine
                foreach (var blockList in list)
                {
                    if (blockList.blockType == BlockType.Mine)
                        n++;
                }

                if (n > 0)
                    _blocks[i, j].blockType = (BlockType) (n + 7);
            }
        }
    }

    BlockType GetBlockType()
    {
        if (Random.Range(1, 50) % 5 == 0)
            return BlockType.Mine;
        
        return BlockType.Empty;
    }

    Block GetBlock(int i, int j)
    {
        if (i < 0 || j < 0 || i >= _w || j >= _h)
            return null;

        return _blocks[i, j];
    }

    List<Block> GetAllNearbyBlock(int i, int j, bool includeCorner = true)
    {
        List<Block> list = new List<Block>();
        list.Add(GetBlock(i + 1, j));
        list.Add(GetBlock(i, j + 1));
        list.Add(GetBlock(i - 1, j));
        list.Add(GetBlock(i, j - 1));

        if (includeCorner)
        {
            list.Add(GetBlock(i + 1, j + 1));
            list.Add(GetBlock(i - 1, j - 1));
            list.Add(GetBlock(i + 1 , j - 1));
            list.Add(GetBlock(i - 1, j + 1));
        }
        return list
            .Where(x => x != null)
            .ToList();
    }

    void RevealAll()
    {
        for (int i = 0; i < _w; i++)
        {
            for (int j = 0; j < _h; j++)
            {
                _blocks[i,j].Reveal();
            }
        }
    }

    public void RevealEmpty(int i, int j)
    {
        List<Block> list = GetAllNearbyBlock(i, j, false);
        list = list.Where(x => !x.show).ToList();

        foreach (var block in list)
        {
            if (block.blockType == BlockType.Empty && !block.show)
            {
                block.Reveal();
                RevealEmpty(block.i, block.j);
            }
        }
    }
    public void Lose()
    {
        RevealAll();
    }
}
