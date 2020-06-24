using System;
using System.IO;
using static System.Math;
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
							double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
							double t=1/(1+0.3275911*linez);
							double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));
								if(linez<0){double linezz=-linez; double tt=1/(1+0.3275911*linezz);
							double summ=tt*(a[0]+tt*(a[1]+tt*(a[2]+tt*(a[3]+tt*a[4])))); ;outputFile.WriteLine($"{linez}	{-(1-summ*Exp(-linezz*linezz))}");}
								else{outputFile.WriteLine($"{linez}	{(1-sum*Exp(-linez*linez))}");}
						} 
					}
					
					
	            		}
	      		}
		catch{Console.WriteLine("Error: Inputfile not found or other error");}
		}
	else{Console.WriteLine("Error: Give two and only two arguments");}
return 0;}
}

