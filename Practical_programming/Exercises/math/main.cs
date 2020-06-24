using System;
using static System.Console;
using static System.Math;
class main
{
	static int Main()
	{
		double x=1;
		//complex I = new complex(0,1);
		//complex ii= I*I;
		complex y = new complex (Cos(x),Sin(x));
		complex z = new complex (Cos(x*PI),Round(Sin(x*PI)));
		complex q = new complex (E.pow(-PI*0.5),0);
		complex s = new complex (0,Sinh(PI));
		WriteLine($"2^(1/2)={Sqrt(2)}");
		WriteLine($"exp(I)={y}");
		WriteLine($"exp(I*Pi)={z}");
		WriteLine($"i^(i)=exp(-Pi/2)={q}");
		WriteLine($"sin(i*Pi)=i*sinh(Pi)={s}");
	return 0;}
}
