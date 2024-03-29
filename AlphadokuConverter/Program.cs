﻿// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var input = @"
N _ V _ U _ _ A C _ _ _ _ _ S _ _ G _ B O _ H I _
_ _ _ A _ B _ _ S _ N I L _ _ _ _ W _ Y _ D _ _ _
I B _ _ _ E _ _ N _ M J _ D U _ O _ _ _ X R F _ _
_ M W _ _ O _ _ _ V T G _ _ R F _ P _ U B _ A C _
_ S _ F E _ _ Y M K _ _ A O C H _ _ L _ P _ _ T _
S F _ _ _ _ V _ _ _ D A _ _ _ _ _ _ W _ I _ U _ O
_ _ R K _ _ _ _ T B _ _ J Q F _ U L I A W _ X E N
_ _ _ _ D _ _ U _ _ E H _ _ _ _ C _ _ O _ _ V _ Q
_ X N H _ _ _ O K Q U M C _ _ E _ _ R _ _ _ S A _
_ _ A U O F _ _ _ _ _ V T S _ _ _ J _ M C G _ K P
_ P _ _ _ M Q F R _ Y _ X I _ _ _ K O J S _ B _ C
_ T _ I X S J _ _ _ K _ _ _ _ _ _ _ _ _ E _ N _ _
R _ E C M _ K _ _ W _ D _ J _ N _ _ T _ A P Y _ H
_ _ Q _ K _ _ _ _ _ _ _ _ _ G _ _ _ Y D U I _ O _
Y _ D _ S X L G _ _ _ T R _ B _ I C E H _ _ _ F _
E R _ W A Y _ B _ _ _ C Q T _ _ _ _ _ X G M D _ _
_ V C _ _ _ R _ _ I _ _ F A M G S H _ _ _ U J X _
G _ X _ _ D _ _ A _ _ _ _ B V _ _ N _ _ T _ _ _ _
T H U _ B K O W X _ G P Y _ _ V D _ _ _ _ E L _ _
O _ M _ N _ F _ _ _ _ _ _ W D _ _ _ J _ _ _ _ Y R
_ K _ _ Q _ D _ _ O W X I _ _ R N E _ _ J Y _ S _
_ L F _ R U _ X _ Y S _ _ V Q J _ _ _ K _ _ I H _
_ _ G D J _ _ _ Q _ P B _ F Y _ H _ _ L _ _ _ U E
_ _ _ X _ J _ K _ _ _ _ G E A _ T _ _ Q _ W _ _ _
_ O I _ V H _ E _ _ J _ _ _ _ _ X Y _ _ R _ Q _ A
".Where(c => !char.IsWhiteSpace(c)).ToArray();

var length = (int)Math.Sqrt(input.Length);
var current = 0;
Console.Write("{ ");

foreach (var ch in input)
{
    if (char.IsLetter(ch))
    {
        var value = (int)(char.ToUpper(ch) - 64);
        Console.Write("{0:00}, ", value);
    }
    
    if (ch == '_')
        Console.Write("00, ");

    current++;
    if (current % length == 0)
    {
        Console.WriteLine("},");
        Console.Write("{ ");
    }
}