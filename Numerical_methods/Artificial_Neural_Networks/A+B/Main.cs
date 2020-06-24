using System; using System.IO; 
using static System.Console;
using static System.Math;
using static ArtificialNeuralNetwork;

public class main{public static void Main(){

int n = 5; // # of hidden neurons in the network

// The activation function is chosen globally for all hidden neurons as a Gaussian with mean 0 and variance 1
Func<double, double> f=(x) =>
{
	return x*Exp(-Pow(x,2));
};

// And corresponding derivative and antiderivative:

Func<double, double> dfdx = (x) =>
{
	return (1-2*Pow(x,2))*Exp(-Pow(x,2));
};

Func<double, double> F = (x) =>
{
	return -Exp(-Pow(x,2))/2;
};


// Input parameters
double a=0, b = 2*PI;
vector p_input=new vector(3*n);
p_input=Input(n,a,b);


// Tabulation of cos(x) which will be interpolated using the network
int points=25;
vector xs=new vector(points); vector ys=new vector(points);
using(StreamWriter Tab=new StreamWriter("TabulatedFunction.txt"))
{
	for(int i=0; i<points; i=i+1)
	{
		xs[i]=i*(b-a)/(points-1);
		ys[i]=Cos(xs[i]);
		Tab.WriteLine($"{xs[i]} {ys[i]} {-Sin(xs[i])} {Sin(xs[i])}");
	}

	// Output: finds the optimal weighing through calibration of the network
	vector p_cal=new vector(p_input.size);
	p_cal=Calibrate(n, xs, ys,f, p_input);
	double C=Sin(0)-IntegralOutput(n,0,F,p_cal); // Integration constant

	using(StreamWriter Out=new StreamWriter("Out.txt"))
	{
		for(double x=a; x<b; x=x+0.05)
		{
			Out.WriteLine($"{x} {Output(n,x,f,p_cal)} {DerivOutput(n,x,dfdx,p_cal)} {IntegralOutput(n,x,F,p_cal)+C}");
		}
	}
}


}
}

