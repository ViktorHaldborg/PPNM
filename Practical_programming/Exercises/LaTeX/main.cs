using System;
using static System.Console;
using static System.Math;
class main{static Func<double,double> f2 = (t) => 1/Sqrt(2*PI)*Exp(-Pow(t,2)/2);
	static Func<double,double> f1 = (t) => 1/(0.5*Sqrt(2*PI))*Exp(-Pow(t/0.5,2)/2);
	static Func<double,double> f3 = (t) => 1/(2*Sqrt(2*PI))*Exp(-Pow(t/2,2)/2);
	
	static int Main(){
	double x;
	for(x=-4;x<4;x=x+0.01){
	double int2=quad.o8av(f2,System.Double.NegativeInfinity,x,acc:1e-6,eps:1e-6);
	double int1=quad.o8av(f1,System.Double.NegativeInfinity,x,acc:1e-6,eps:1e-6);
	double int3=quad.o8av(f3,System.Double.NegativeInfinity,x,acc:1e-6,eps:1e-6);
	WriteLine($"{x} {int2} {int1} {int3}");};

    return 0;
}
}
