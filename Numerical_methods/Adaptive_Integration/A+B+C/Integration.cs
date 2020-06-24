using System; 
using static System.Console;
using static System.Math;
public static class AdaptiveIntegration{

public static double LowOrder(Func<double,double> f ,double a, double b){ // Lower order (for error estimation)
double f2=f(a+2*(b-a)/6); double f1=f(a+(b-a)/6);
double f3=f(a+4*(b-a)/6); double f4=f(a+5*(b-a)/6);
double q=(f1+f4+f2+f3)/4*(b-a);
return q;}

public static double HighOrder(Func<double,double> f ,double a, double b){ // High order
double f1=f(a+(b-a)/6); double f2=f(a+2*(b-a)/6);
double f3=f(a+4*(b-a)/6); double f4=f(a+5*(b-a)/6);
double Q=(2*f1+f2+f3+2*f4)/6*(b-a);
return Q;}

public static double Integrate(Func<double,double> f ,double a, double b, double δ, double ε, int n){ // high order sub dividing quadrature
double q=LowOrder(f,a,b);
double Q=HighOrder(f,a,b);
double tolerance=δ+ε*Abs(Q); double error=Abs(Q-q);
const double inf=double.PositiveInfinity;

if(tolerance>error){return Q;}
else{return Integrate(f,a,(a+b)/2,δ/Sqrt(2),ε,n+1)+Integrate(f,(a+b)/2,b,δ/Sqrt(2),ε,n+1);}} // Recursion and sub division by calling itself (till tol>error)

public static double Integrator(Func<double,double> f ,double a, double b, double δ, double ε, int n){ // Variable transformation if bounds contain infinity
const double inf=double.PositiveInfinity;
if(a==-inf & b==inf){Func<double, double> f_ab = (x) => (f((1-x)/x)+f(-(1-x)/x))/(Pow(x,2)); return Integrate(f_ab,0,1,δ,ε,n);}
if(b==inf){Func<double, double> f_b = (x) => f(a+x/(1-x))/Pow(1-x,2); return Integrate(f_b,0,1,δ,ε,n);}
if(a==-inf){Func<double, double> f_a = (x) => f(b-((1-x)/x))/Pow(x,2); return Integrate(f_a,0,1,δ,ε,n);}
else{return Integrate(f,a,b,δ,ε,n);}}

public static double Error_Integrate(Func<double,double> f ,double a, double b, double δ, double ε, int n){ // Error estimation by comparison of adaptive- and low order integrator
double q=LowOrder(f,a,b);
double Q=Integrate(f,a,b,δ,ε,n);
double error=Abs(Q-q);
return error;}

public static double CC_Integrate(Func<double,double> f, double a, double b, double δ, double ε, int n){ // Since the transformation is defined from -1,1 -> 0,PI we need to rescale:
Func<double, double> f_t = x => f((a+b)/2+((b-a)/2)*Cos(x))*((b-a)/2)*Sin(x);
return Integrate(f_t,0,PI,δ,ε,n);}}

