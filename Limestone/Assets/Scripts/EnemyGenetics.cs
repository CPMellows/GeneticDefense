using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGenetics {

    public float[] enemyDistances = new float[5];
    public List<int[]> generation = new List<int[]>();
    public bool firstWave = true;

    public List<int[]> getEnemies()
    {
        if (firstWave)
            firstGen();
        else
            generation = nextGen(enemyDistances);
        generation  = generation.Take(5).ToList();
        firstWave = false;
        return generation;
    } 

    public void firstGen()
    {
        int bitIndex = Random.Range(0, 3);

        for (int i = 0; i < 5; i++)
        {
            bitIndex = Random.Range(0, 3);
            if (bitIndex == 3)
                generation.Add( new int[] { 0, 0, 0, 1 });
            else if (bitIndex == 2)
                generation.Add(new int[] { 0, 0, 1, 0 });
            else if (bitIndex == 1)
                generation.Add(new int[] { 0, 1, 0, 0 });
            else
                generation.Add(new int[] { 1, 0, 0, 0 });
        }
    }

    public List<int[]> nextGen(float[] enemyDistances)
    {
        int[][] kids = new int[2][];
        List<int[]> nextGen = new List<int[]>();
        float totalDistance = 0;
        float previous = 0;
        float[] multiplierArray = new float[5];
        foreach (float dist in enemyDistances) {
            totalDistance += dist;
        }
        for (int i = 0; i < 5; i++) {
            multiplierArray[i] = (enemyDistances[i] / totalDistance) + previous;
            previous = multiplierArray[i];
        }
        for (int i = 0; i < 5; i++)
        {
            float val = Random.Range(0.0f, 1.0f);
            int j = 0;
            while (val > multiplierArray[j])
                j++;
            float val2 = Random.Range(0.0f, 1.0f);
            int k = 0;
            while (val2 > multiplierArray[k])
                k++;
            Debug.Log(j);
            Debug.Log(k);
            kids = crossover(generation.ElementAt(j), generation.ElementAt(k));
            nextGen.Add(kids[0]);
            nextGen.Add(kids[1]);
        }
        return nextGen;
    }

    private int[][] crossover(int[] a, int[] b)
    {
        int[][] children = new int[2][];
        int num = Random.Range(0, 3);
        int[] aArray = new int[4];
        int[] newAArray = new int[4];
        a.CopyTo(aArray,0);
        int[] bArray = new int[4];
        int[] newBArray = new int[4];
        b.CopyTo(bArray, 0);
        for(int i = 0; i < 4; i++)
        {
            if(i >= num)
            {
                if (Random.Range(0.0f, 1.0f) < 0.025)
                    newAArray[i] = 1;
                else
                    newAArray[i] = bArray[i];
                if (Random.Range(0.0f, 1.0f) < 0.025)
                    newBArray[i] = 1;
                else
                    newBArray[i] = aArray[i];
            }
            else
            {
                if (Random.Range(0.0f, 1.0f) < 0.025)
                    newAArray[i] = 1;
                else
                    newAArray[i] = aArray[i];
                if (Random.Range(0.0f, 1.0f) < 0.025)
                    newBArray[i] = 1;
                else
                    newBArray[i] = bArray[i];
            }
        }
        children[0] = newAArray;
        children[1] = newBArray;
        return children;
    }

}
