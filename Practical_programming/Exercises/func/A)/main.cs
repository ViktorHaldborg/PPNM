using System;
using static System.Console;
using static System.Math;
class main{
	static Func<double,double> f1 = (x) => Log(x)/Sqrt(x);
	static Func<double,double> f2 = (x) => Exp(-Pow(x,2));
	static double integral3(double p){
	Func<double,double> f3 = (x) => Pow(Log(1/x),p);
	return  quad.o8av(f3,0,1, acc:1e-6, eps:0);
	}

	static int Main(){
        double int1=quad.o8av(f1,0,1,acc:1e-6,eps:1e-6);
	double int2=quad.o8av(f2,System.Double.NegativeInfinity,System.Double.PositiveInfinity,acc:1e-6,eps:1e-6);
	WriteLine($"int1={int1}");
	WriteLine($"int2={int2}");
	for(double p=1; p<=5;p++) {
        double int3=integral3(p);
	WriteLine($"int3={int3} with p={p}");
	}

    return 0;
}
}
