using System;
using System.IO;
using static System.Math;
class io
{public static int Main(string[] args)
	{if(args.Length==2)
		{try
			{	string h = args[0];
				using (StreamReader sr = new StreamReader($"{h}"))
	            		{	string y = args[1];
					string lines;
					using (StreamWriter outputFile = new StreamWriter($"{y}"))
					{
	                			while((lines = sr.ReadLine()) != null) 
						{double linez=Convert.ToDouble(lines);double x;						
						if(linez<0){x=1-linez;double gamma=Exp(x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2); outputFile.WriteLine($"{linez}	{Log(PI/Sin(PI*linez)/gamma)}");}
						else{x=1+linez;double gamma=Exp(x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2); outputFile.WriteLine($"{linez}	{Log(gamma/linez)}");}
						} 
					}
					
					
	            		}
	      		}
		catch{Console.WriteLine("Error: Inputfile not found or other error");}
		}
	else{Console.WriteLine("Error: Give two and only two arguments");}
return 0;}
}


