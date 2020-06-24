using System; using static System.Console; using static System.Math;
using static QuasiNewtonianMethods;
using static NumericalGradient;

public class main{ public static int Main(){
double Ɛ=1e-6; // Precision goal (Requiring the norm of the gradient of f to be < Ɛ)

vector E=new vector(new double[]{101,103,105,107,109,111,113,115,117,119,121,123,125,127,129,131,133,135,137,139,141,143,145,147,149,151,153,155,157,159});
vector σ=new vector(new double[]{-0.25,-0.30,-0.15,-1.71,0.81,0.65,-0.91,0.91,0.96,-2.52,-1.01,2.01,4.83,4.58,1.26,1.01,-1.26,0.45,0.15,-0.91,-0.81,-1.41,1.36,0.50,-0.45,1.61,-2.21,-1.86,1.76,-0.50});
vector Error=new vector(new double[]{2.0,2.0,1.9,1.9,1.9,1.9,1.9,1.9,1.6,1.6,1.6,1.6,1.6,1.6,1.3,1.3,1.3,1.3,1.3,1.3,1.1,1.1,1.1,1.1,1.1,1.1,1.1,0.9,0.9,0.9});



Func<vector,double, double> F = delegate(vector x, double energy) // Breit-function Wigner
{ 
	return x[0]/(Pow(energy-x[1],2)+Pow(x[2],2)/4);
};



Func<vector,double> Dev = delegate(vector x) // Breit-Wigner deviation
{
double sum=0;
for(int i=0; i<E.size; i=i+1)
{
	sum=sum+(Pow(F(x,E[i])-σ[i],2))/(Pow(Error[i],2));
}
return sum;
};

vector x0=new vector(5,130,1); // Initial guess (A,m,Γ)

WriteLine($"\nMinimization of the deviation of Breit-Wigner function:\n\n Desired precision(Ɛ) = {Ɛ}\n Initial guess(A,m,Γ): ({x0[0]},{x0[1]},{x0[2]})\n\nEstimated parameters:\n\n A = {QuasiNewtonMinimization(Dev,x0,Ɛ).Item2[0]}\n m = {QuasiNewtonMinimization(Dev,x0,Ɛ).Item2[1]}\n Γ = {QuasiNewtonMinimization(Dev,x0,Ɛ).Item2[2]}"); // Taking the function value at the found root in the gradient. 


return 0;}
}
