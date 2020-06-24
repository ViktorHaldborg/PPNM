using System; using static System.Math; using static System.Console; using System.IO;
using static RootFinding;
using static RNG; // Secure RNG
using static JacobiDiagonalization1;
using static IntervalSearch;
using System.Diagnostics;
class main{public static int Main(){

////////////////////////////////////////////////////////////////////////////////////////////////////
// Eigenvalues of updated matrix(symmetric row/column update(Operationtime and scalability showcase)
////////////////////////////////////////////////////////////////////////////////////////////////////

int ja=0;
int nej=0;
// Input Parameteres for root finding:
int ε=3; // Required decimals of precision in the gradient
int δ=1; // Tolerance in the estimation of f(x), precision can be scaled a bit at given resolution however dont scale too high or results will be lost at given resolution.
int μ=6; // Desired decimals of precision in comparison of results
int Points=100; // Resolution (lower for computation time, but it compromises stability)
//int n=RandomInt(2,9); // Deciding random dimensionality of the problem(of modest size)
using(StreamWriter Write1=new StreamWriter("Time.txt")){
for(int n=2; n<500; n=n+80)
{
	// Timing
	var time1=new Stopwatch();
	time1.Start();
	var Matrices=Search(n,Points,ε,δ,μ);
	time1.Stop();
	
	matrix A_d=Matrices.Item1;
	matrix A=Matrices.Item2;

	// To test the results we use the Jacobi eigenvalue algorithm doing full sweeps to obtain the eigenvalues on the diagonal and elimnate the off diagonal elements.
	matrix V = new matrix(n,n); vector v=new vector(n);
	matrix H=A.copy(); 

	// Timing
	var time2=new Stopwatch();
	time2.Start();
	JacobiDiag(H,v,V); // Now stores A diagonalized in matrix H from Jacobi
	time2.Stop();

	for(int i=0; i<n; i=i+1)
	{
		for(int j=0; j<n; j=j+1)
		{
			if(i!=j)
			{
				H[i,j]=0;}
				if(Round(H[i,i],μ)==0){H[i,i]=0; // Rounding off elements to 0
			}
		}
	} 



	// Checking element after element since the diagonal will be sorted from lowest to highest root.
	int TrueCounter=0; 
	for(int i=0; i<n; i=i+1)
	{
		if(Round(H[i,i],μ)==Round(A_d[i,i],μ))
		{
			TrueCounter=TrueCounter+1;
		}
	}


	if(TrueCounter==n)
	{
		ja=ja+1;
	}

	else
	{
		nej=nej+1; // return 0; 
	} 

	Error.WriteLine($"\nSuccesfull diagonalizations ({ja}) Unsuccesfull diagonalizations ({nej})");
	Write1.WriteLine($"{n} {Sqrt(time1.ElapsedMilliseconds)} {Sqrt(time2.ElapsedMilliseconds)} {Sqrt(0.02*Pow(n,2))}");

} // for
} // write
return 0;}
}
