using System;
using System.IO;
using static System.Console;
using static System.Math;
using static MonteCarloIntegration;

public class main{public static int Main(){
int N=Convert.ToInt32(10e5);
// Plain Monte Carlo integrator
// Test by determining the integral of the Rosenbrock and Himmelblau functions, from 0 to π:
int Dim=2;
vector a=new vector(Dim); vector b=new vector(Dim);
for(int i=0; i<a.size; i=i+1){a[i]=0; b[i]=PI;} // Boundaries on the definite integral

// Rosenbrock
double ExpectedRosen=1238.7;

Func<vector,double> Rosen=delegate(vector x)
{
	return Pow(1-x[0],2)+10*Pow(x[1]-Pow(x[0],2),2); // With the chosen a=1 and b=10
};

// Himmelblau
double ExpectedHimmel=604.2;

Func<vector,double> Himmel=delegate(vector x)
{
	return Pow(Pow(x[0],2)+x[1]-11,2)+Pow(x[0]+Pow(x[1],2)-7,2);
};


vector ResultRosen=PlainMC(Rosen,a,b,N);
vector ResultHimmel=PlainMC(Himmel,a,b,N);
WriteLine("\nA)");
WriteLine("\n Monte Carlo integration of Rosenbrock and Himmelblau's functions from 0 to π");
WriteLine($"\n  Rosenbrock function:\n\n   f(x,y) = (1-x)^2+10*(y-x^2)^2\n   Expected result = {ExpectedRosen} \n   MC result = {ResultRosen[0]:f1} \n   Estimated error = {ResultRosen[1]:f1}\n   Actual error = {Abs(ResultRosen[0]-ExpectedRosen):f1}");
WriteLine($"\n  Himmelblau function:\n\n   f(x,y) = (x^2+y-11)^2+(x+y^2-7)^2\n   Expected result = {ExpectedHimmel} \n   MC result = {ResultHimmel[0]:f1} \n   Estimated error = {ResultHimmel[1]:f1}\n   Actual error = {Abs(ResultHimmel[0]-ExpectedHimmel):f1}");


// Singular function:
// ∫dx ∫dy ∫dz (1/π)³[1-cos(cos)y(x)cos(z)]^(-1) evaluated from 0 to π in all 3 dimensions
Dim=3;
a=new vector(Dim); b=new vector(Dim);
for(int i=0; i<a.size; i=i+1){a[i]=0; b[i]=PI;} // Boundaries on the definite integral
Func<vector,double> SingularIntegral=delegate(vector x)
{
	return Pow(PI,-3)*1/(1-Cos(x[0])*Cos(x[1])*Cos(x[2]));
};

vector Result=PlainMC(SingularIntegral,a,b,N);
WriteLine($"\n Evaluating the integral ∫dx ∫dy ∫dz (1/π)³[1-cos(cos)y(x)cos(z)]^(-1) from 0 to π in all 3 dimensions:\n\n  Expected result = 1.3932 \n  MC result = {Result[0]:f4} \n  Estimated error = {Result[1]:f4}\n  Actual error = {Abs(Result[0]-1.3932039296856768591842462603255):f4}");

// B)
// The function sin(x) will be integrated to test the N dependance of the error estimation within the Monte Carlo Routine
// The dependance of the estimated error is clearly O(sqrt(1/N)), the actual error seems to be atleast O(sqrt(1/N)) both are shown in B.svg
using (StreamWriter B=new StreamWriter("B.txt"))
{
	Dim=1;
	a=new vector(Dim); b=new vector(Dim);
	for(int i=0; i<a.size; i=i+1){a[i]=0; b[i]=PI/2;}

	Func<vector,double> Sine=delegate(vector x)
	{
		return Sin(x[0]);
	};
	
	for(int i=100; i<Convert.ToInt32(10e4); i=i+999)
	{
		N=i;
		Result=PlainMC(Sine,a,b,N);
		B.WriteLine($"{N} {1/Sqrt(N)} {Result[1]} {Abs(Result[0]-1)}");
	}

}



return 0;}
}
