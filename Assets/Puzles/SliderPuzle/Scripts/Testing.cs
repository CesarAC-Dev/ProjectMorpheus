using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public void ComprobarInversion()
    {
        SliderScript slider = new SliderScript();
        Piezas[] piezas = new Piezas[15];
        for(int i = 0; i < 15; i++)
        {
            piezas[i] = new Piezas();
        }

        // Act
        //int actualSum = calculator.Add(a, b);

        // Assert
        //Assert.AreEqual(expectedSum, actualSum);
    }
}

/*
//[TestFixture]
public class Testing: MonoBehaviour
{
    //[Test]
    public void ComprobarInversion()
    {
        SliderScript slider = new SliderScript();
        private Piezas[] piezas;
        int a = 2;
        int b = 3;
        int expectedSum = 5;

        // Act
        //int actualSum = calculator.Add(a, b);

        // Assert
        //Assert.AreEqual(expectedSum, actualSum);
    }
}*/