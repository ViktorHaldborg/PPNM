using System; using static System.Math;
using static System.Console; using System.Diagnostics;
using static NumericalGradient;
public class QuasiNewtonianMethods{
// We generate our next step by updating(SR1) the Hessian based on the computed gradient
public static Tuple<int, vector> QuasiNewtonMinimization(Func<vector,double> φ, vector x, double Ɛ){  
int n=x.size;
matrix B=new matrix(n,n); matrix δB=new matrix(n,n);
B.set_unity(); // Initial zero't approximation to H
double EPS=1.0/4194304;

vector δx; vector s;

// Rank 1 update to H
int Counter=0;
double α=10e-4;
vector test=new vector(2); 
int testCounter=0;
do
{	
	Counter++;
	double λ=1.0;
	δx=-B*Gradient(φ,x);
	s=λ*δx;
	do // Take a more conservative step s
	{
		λ=λ*0.5; s=λ*δx; // Gentler backtracking
		if(φ(x+s)<φ(x)+α*(s).dot(Gradient(φ,s))){break;} // Armijo condition
		if(λ<EPS)
		{
			B.set_unity();
			break;
		}

	}while(true);
	test[testCounter]=Gradient(φ,x+s).norm();
	Error.WriteLine($"norm(Gradient)={test[testCounter]}");
	if(testCounter!=test.size-1){testCounter++;}
	if(testCounter==test.size-1)
	{
		if(test[test.size-1]>test[0] && testCounter>1)
		{
			B.set_unity();  // On divergence
		}
	}
	vector y=Gradient(φ,x+s)-Gradient(φ,x);
	vector u=s-B*y;
	matrix U=new matrix(n,n); // Constructed from <u,u> with real entries
	for(int i=0; i<n; i++)
	{
		for(int j=0; j<n; j++)
		{
			U[i,j]=u[i]*u[j];
		}	
	}
	
	δB=(1/u.dot(y))*(U); // Update matrix

	if(Abs(u.dot(y))>10e-6)
	{
		B=B+δB;
	}

	x=x+s;
if(Counter >600){Error.WriteLine($"No or slow divergence: Program terminated after {Counter} steps"); break;}
}while(Gradient(φ,x+s).norm()>Ɛ);


return Tuple.Create(Counter,x);
}   


}
