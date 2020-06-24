using System;
using static System.Console;
class input_output{static void  Main(){
WriteLine("Please enter your arguments");
string x=ReadLine();

string [] split = x.Split(new Char [] {' ', ',', '.', ':', '\t' });

foreach (string arg in split) 
{if (arg.Trim() != "")
WriteLine($"sin({arg})={Math.Sin(Convert.ToDouble(arg))} & cos({arg})={Math.Cos(Convert.ToDouble(arg))}");
	}
}
}
