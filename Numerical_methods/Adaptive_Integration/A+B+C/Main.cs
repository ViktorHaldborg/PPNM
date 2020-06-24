using System;
using static System.Console;
using static System.Math;
using static AdaptiveIntegration;
class main{static void Main(){
double a=0; double b=1;
double ε=1e-3; double δ=1e-3; 
int n=1; int i=1; int j=1; int k=1;
Func<double,double> f1 = delegate(double x){ n++; return Sqrt(x);};
Func<double,double> f2 = delegate(double x){ i++; return 4*Sqrt(1-Pow(x,2));};

WriteLine($"\nA) Recursive adaptive integration routine results:\n\n\n Integration of x^(1/2) from 0 to 1:");
double Result1=Integrate(f1,a,b,δ,ε,n);
WriteLine($"\n = {Result1} ~ 2/3 in {n} operation(s) \n ");

WriteLine($"4*Sqrt(1-x^2) from 0 to 1: \n ");
double Result2=Integrate(f2,a,b,δ,ε,n);
WriteLine($" = {Result2} ~ π in {i} operation(s) \n ");


// B)
Func<double,double> f3 = delegate(double x){ j++; return 1/Sqrt(x);}; // equals 2
Func<double,double> f4 = delegate(double x){ k++; return Log(x)/Sqrt(x);}; // equals -4


WriteLine("\nB) Results on integrable divergencies:\n\n 1/Sqrt(x) from 0 to 1:");
double Result3=Integrate(f3,a,b,δ,ε,n);
WriteLine($"\n = {Result3} ~ 2 in {j} operation(s) \n ");

WriteLine($"Ln(x)/Sqrt(x) from 0 to 1: \n ");
double Result4=Integrate(f4,a,b,δ,ε,n);
WriteLine($" = {Result4} ~ -4 in {k} operation(s) \n\n");

// Clenshaw Curtis

WriteLine($"Results on integrable divergencies using Clenshaw Curtis transformation:\n\n\n 1/Sqrt(x) from 0 to 1:");
j=1; double Result5=CC_Integrate(f3,a,b,δ,ε,n);
WriteLine($"\n = {Result5} ~ 2 in {j} operation(s) \n ");

WriteLine($" Ln(x)/Sqrt(x) from 0 to 1:");
j=1; double Result6=CC_Integrate(f4,a,b,δ,ε,n);
WriteLine($"\n = {Result6} ~ -4 in {j} operation(s) \n\n ");

WriteLine($"Results integrating 4*Sqrt(1-x^2) from 0 to 1 with maximum significant digits:\n\n");
WriteLine($"Adaptive integration routine:");
int m=1;
Func<double,double> f5 = delegate(double x){ m++; return 4*Sqrt(1-Pow(x,2));};
double Result7=Integrate(f5,a,b,1e-15,1e-15,n);
WriteLine($"\n = {Result7} ~ π in {m} operation(s) \n ");
m=1; double Result8=CC_Integrate(f5,a,b,1e-15,1e-15,n);
WriteLine($"Clenshaw Curtis routine:\n  ");
WriteLine($" = {Result8} ~ π in {m} operation(s) \n ");
m=1; double Result9=quad.o8av(f5,a,b,1e-15,1e-15);
WriteLine($"quad.o8av routine:\n  ");
WriteLine($" = {Result9} ~ π in {m} operation(s) (Superior) ");

// C) All these definite integrals are convergent
const double inf=double.PositiveInfinity; a=0; b=inf; m=1;
Func<double,double> f6 = delegate(double x){ m++; return Exp(-x);};
double Result10=Integrator(f6,a,b,1e-9,1e-9,n);
WriteLine("\n\n C) Integrating e^(-x) from 0 to infinity:");
WriteLine($"\n = {Result10} ~ 1(as wished) in {m} operation(s)");

a=-inf; b=0; m=1;
Func<double,double> f7 = delegate(double x){ m++; return 1/Pow(x-1,2);};
double Result11=Integrator(f7,a,b,1e-9,1e-9,n);
WriteLine("\n\n Integrating 1/(x-1)^2 from -infinity to 0:");
WriteLine($"\n = {Result11} which should equal 1(as wished) in {m} operation(s)");

a=-inf; b=inf; m=1;
Func<double,double> f8 = delegate(double x){ m++; return Exp(-Pow(x,2));};
double Result12=Integrator(f8,a,b,1e-9,1e-9,n);
WriteLine("\n\n Integrating gaussian function e^(-x^2) from -infinity to infinity:");
WriteLine($"\n = {Result12} ~ Sqrt(PI) (as wished) in {m} operation(s)");

m=1;
Func<double,double> f9 = delegate(double x){ m++; return Exp(-Pow(x,2));};
double Result13=quad.o8av(f9,a,b,1e-9,1e-9);
WriteLine("\n\n Integral performed using superior quad.o8av routine:");
WriteLine($"\n = {Result13} ~ Sqrt(PI) (as wished) in {m} operation(s)!");

}} 
