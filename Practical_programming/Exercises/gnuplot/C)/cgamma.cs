using System;
using static System.Console;
using System.IO;
using static System.Math;
using static cmath;
class io
{public static int Main(string[] args)
	{if(args.Length==2)
		{try
			{	string h = args[0];
				using (StreamReader sr = new StreamReader($"{h}"))
	            		{	string y = args[1];
					string lines;
					//new complex lines;
					using (StreamWriter outputFile = new StreamWriter($"{y}"))
					{
	                			while((lines=sr.ReadLine()) != null) 
						{string[] split=lines.Split(' ');
						double r=Convert.ToDouble(split[0]);
						double i=Convert.ToDouble(split[1]);
						double rr=1;
						double ii=0;
						complex c=new complex (r,i);
						complex v=new complex (rr,ii);
			if(r<0){
				complex gamma=exp((v-c)*log((v-c)+1/(12*(v-c)-1/(v+c)/10))-(v-c)+log(2*PI/(v-c))/2);
				outputFile.WriteLine($"{r}	{i}	{abs(PI/sin(PI*c)/gamma)}");
				}
				
			else{
				complex gamma=exp((v+c)*log((v+c)+1/(12*(v+c)-1/(v+c)/10))-(v+c)+log(2*PI/(v+c))/2);
				outputFile.WriteLine($"{r}	{i}	{abs(gamma/c)}");
				}
						} 
					}
					
					
	            		}
	      		}
		catch{Console.WriteLine("Error: Inputfile not found or other error");}
		}
	else{Console.WriteLine("Error: Give two and only two arguments");}
return 0;}
}


