using System;
using static System.Console;
using static System.Math;
class main{
	static double inf = System.Double.PositiveInfinity;
	static double minf = System.Double.NegativeInfinity;
	static double normkvadrat(double a){
	Func<double,double> normkvadrat = (x) => Exp(-(a*Pow(x,2)));
	return  quad.o8av(normkvadrat,minf,inf, acc:1e-6, eps:0);}
	static double H(double a){
	Func<double,double> H = (x) => (-Pow(a,2)*Pow(x,2)/2+a/2+Pow(x,2)/2)*Exp(-(a*Pow(x,2)));
	return  quad.o8av(H,minf,inf, acc:1e-6, eps:0);
	}

	static int Main(){
	
	for(double a=0.1; a<=3;a=a+0.05) {
	double f1=normkvadrat(a);
        double f2=H(a);
	WriteLine($"{a}	{f2/f1}");
	}

    return 0;
}
}
