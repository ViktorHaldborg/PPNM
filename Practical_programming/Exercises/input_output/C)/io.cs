using System;
using System.IO;
class io
{public static int Main(string[] args)
	{if(args.Length==2)
		{try
			{	string x = args[0];
				using (StreamReader sr = new StreamReader($"{x}"))
	            		{	string y = args[1];
					string lines;
					using (StreamWriter outputFile = new StreamWriter($"{y}"))
					{
	                			while((lines = sr.ReadLine()) != null) 
						{double linez=Convert.ToDouble(lines);
						outputFile.WriteLine($"sin({linez}) = {Math.Sin(linez)} & cos({linez}) = {Math.Cos(linez)}\n");}
					}
					
					
	            		}
	      		}
		catch{Console.WriteLine("Error: Inputfile not found or other error");}
		}
	else{Console.WriteLine("Error: Give two and only two arguments");}
return 0;}
}

