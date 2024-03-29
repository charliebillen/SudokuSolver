﻿// See https://aka.ms/new-console-template for more information

var input = @"
0 _ _ _ _ _ B A 3 _ 6 8 _ 5 _ _
_ _ B _ 9 _ D _ F _ 0 _ 4 _ _ _
_ _ _ _ _ _ F _ _ _ _ A D _ 1 3
_ _ 3 _ 7 _ _ _ _ _ C _ _ _ E _
D _ _ 3 _ F 8 _ _ C _ 2 _ E _ _
C 2 1 _ _ _ _ B 8 _ D 5 _ _ _ _
9 _ _ 8 6 _ _ C _ _ A F _ _ 7 4
_ 0 _ _ 1 _ A _ _ 4 _ _ _ _ 8 D
_ _ _ 6 _ _ _ _ _ E _ _ _ 3 9 7
F E _ _ _ _ 9 7 _ _ _ C 5 _ 6 A
_ _ 9 A _ _ _ _ B _ _ _ 8 _ D C
8 _ _ _ D _ C _ _ A _ _ _ _ F B
_ _ _ _ _ _ 5 _ _ _ _ _ _ _ C _
_ _ _ 7 C A _ D _ 6 E _ _ _ 3 _
1 C _ 0 E _ _ _ D 7 _ _ A 9 _ F
E _ 4 _ _ 7 _ F _ _ 5 _ _ 0 _ _
".Where(c => !char.IsWhiteSpace(c)).ToArray();

var length = (int)Math.Sqrt(input.Length);
var current = 0;
Console.Write("{ ");

foreach (var ch in input)
{
    if (char.IsLetter(ch) || char.IsDigit(ch))
    {
        var hex = Convert.ToInt32(ch.ToString(), 16) + 1;
        Console.Write("{0:00}, ", hex);
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
