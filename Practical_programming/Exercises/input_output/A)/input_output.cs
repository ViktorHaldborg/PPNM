using System;
using static System.Console;
class input_output{static int  Main(string[] args){
if(args.Length==0) {Error.WriteLine("No argument given");return 1;}
else for(int n=0; n<=args.Length-1;n++) {double x = double.Parse(args[n]);
		Console.WriteLine($"sin({x})={Math.Sin(x)} & cos({x})={Math.Cos(x)}");}
		return 0;
		}
}
