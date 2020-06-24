using System; using static System.Math; using static System.Console; using System.IO;
using static RootFinding;
using static RNG; // Secure RNG
using static JacobiDiagonalization1;
using static IntervalSearch;
using System.Diagnostics;
class main{public static int Main(){

////////////////////////////////////////////////////////////
// Eigenvalues of updated matrix(symmetric row/column update
////////////////////////////////////////////////////////////
WriteLine("\n**********************************************************\nEigenvalues of updated matrix: symmetric row/column update");

int ja=0;
int nej=0;
// Input Parameteres for root finding:
int ε=3; // Required decimals of precision in the gradient
int δ=2; // Tolerance in the estimation of f(x), precision can be scaled a bit at given resolution however dont scale too high or results will be lost at given resolution.
int μ=9; // Desired decimals of precision in comparison of results
int Points=10000; // Resolution (lower for computation time, but it compromises stability)
int n=RandomInt(2,9); // Deciding random dimensionality of the problem(of modest size)

{
	var Matrices=Search(n,Points,ε,δ);
	matrix A_d=Matrices.Item1;
	matrix A=Matrices.Item2;

	// To test the results we use the Jacobi eigenvalue algorithm doing full sweeps to obtain the eigenvalues on the diagonal and elimnate the off diagonal elements.
	matrix V = new matrix(n,n); vector v=new vector(n);
	matrix H=A.copy(); 

	JacobiDiag(H,v,V); // Now stores A diagonalized in matrix H from Jacobi

	for(int i=0; i<n; i=i+1)
	{
		for(int j=0; j<n; j=j+1)
		{
			if(i!=j)
			{
			H[i,j]=0;}if(Round(H[i,i],μ)==0){H[i,i]=0; // Rounding off elements to 0
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


	A_d.print("\nMatrix A diagonalized using update matrix =\n");
	H.print("\nMatrix A found from Jacobi diagonalization =\n");

	if(TrueCounter==n)
	{
		ja=ja+1;
		Write("\n\nDiagonalization of A completed\n\n\n\n"); Error.Write("\n\nDiagonalization of A completed\n\n");
	}

	else
	{
		nej=nej+1; // return 0; 
		Error.Write("\n\nError: A might not be diagonalized correctly\n\n"); Write("\nTest failed:A might not be diagonalized correctly\n\n");
	} 


}

return 0;}
}
