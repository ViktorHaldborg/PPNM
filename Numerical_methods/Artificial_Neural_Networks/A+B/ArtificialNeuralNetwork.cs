using static System.Console;
using static System.Math;
using static QuasiNewtonianMethods;
using System;

// In the artificial neural network
// We train the neurons such that given circuits fire due to the assignment of different weights through the multiplicative
// The artifical neural network is constructed in the way that given an input, the network will transfer that input through its network, as weighted sums, to hidden neurons within the network and then passed on to different activation functions at the respective sites which will determine the input into the summation neuron which in turn yields the resultant output. or conclusion reached
 //This will serve as a model for the brain.
// In the brain certain established circuits may fire or may not fire dependent on given stimuli. This is the job of the activation function which gives an established transformation from the input neurons 
// activation function may be seen as well established circuits which may or may not fire dependant on given stimuli
// In this case the stimuli is

public static class ArtificialNeuralNetwork{

// Returns input parameters for the whole network
public static vector Input(int n, double a, double b)
{
	vector p=new vector(3*n);

	for(int i=0; i<n; i=i+1)
	{
		p[3*i]=a+((i*(b-a))/(n-1));
		p[3*i+1]=1; 
		p[3*i+2]=1;
	}	

	return p;
}

// Returns the signal from the hidden neuron in the i'th node of the network
public static Tuple<double,double,double> HiddenNeuron(int n, int i, vector p)
{	
	double a=p[3*i];
	double b=p[3*i+1];
	double w=p[3*i+2];

	return Tuple.Create(a,b,w);
}




// Takes the collective outputs of the hidden neurons and transforms them into the output
public static double Output(int n, double x, Func<double, double> f, vector p)
{	
	double sum = 0;
	for(int i=0; i<n; i=i+1)
	{
		sum=sum+f((x-HiddenNeuron(n,i,p).Item1)/HiddenNeuron(n,i,p).Item2)*HiddenNeuron(n,i,p).Item3;
	}
	
	return sum;	
}


// Calibration or training of the network by minimizing δ(p)=∑(F_p(x_k)-y_k)² with k=1..N
public static vector Calibrate(int n, vector x, vector y, Func<double, double> f, vector p)
{
	double Ɛ=1e-4; // Precision w.r.t the norm of the gradient of δ
	Func<vector, double> δ=delegate(vector p1)
	{
		double sum = 0;
		for(int i=0; i<x.size; i=i+1)
		{
			sum=sum+Pow(Output(n,x[i],f,p1)-y[i],2);
		}
		return sum/x.size;
	};

	return QuasiNewtonMinimization(δ,p,Ɛ).Item2 // Returns calibrated parameters
;}

// Outputs the derivative of f 
public static double DerivOutput(int n, double x, Func<double, double> Derivf, vector p)
{
	double sum=0;
	double a,b,w;
	for(int i=0; i<n; i=i+1)
	{
		a=HiddenNeuron(n,i,p).Item1;
		b=HiddenNeuron(n,i,p).Item2;
		w=HiddenNeuron(n,i,p).Item3;
		sum=sum+(w/b)*Derivf((x-a)/b);
	}
	
	return sum;
}

// Outputs the anti-derivative of f 
public static double IntegralOutput(int n, double x, Func<double, double> F,  vector p)
{
	double sum = 0;
	double a,b,w;
	for(int i=0; i<n; i=i+1)
	{
		a=HiddenNeuron(n,i,p).Item1;
		b=HiddenNeuron(n,i,p).Item2;
		w=HiddenNeuron(n,i,p).Item3;
		sum=sum+w*b*F((x-a)/b);
	}

	return sum;		
}



}

