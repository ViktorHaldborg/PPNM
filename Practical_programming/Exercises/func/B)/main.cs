using System;
using static System.Console;
using static System.Math;
class main{
	static Func<double,double> f1 = (x) => Sqrt(x)*Exp(-x);
	static Func<double,double> f2 = (x) => x/(Exp(x)-1);
	static double inf = System.Double.PositiveInfinity;

	static int Main(){
        double int1=quad.o8av(f1,0,inf,acc:1e-6,eps:1e-6);
	double int2=quad.o8av(f2,0,inf,acc:1e-6,eps:1e-6);
	WriteLine($"int1={int1} expected 0.88(Gamma function)");
	WriteLine($"int2={int2} expected 1.64(Bernoulli number)");

	

	    return 0;
			}
	}
