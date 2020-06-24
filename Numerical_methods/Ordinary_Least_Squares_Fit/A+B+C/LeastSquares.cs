using System;
using System.Collections.Generic;
using static System.Math;
using static QRGramSchmidtDecomposition;
public class OrdinaryLeastSquares{

public static Tuple<vector,vector> LeastSquaresFit(vector t,vector y,vector dy,Func<double, double>[] f){ // Yielding the vector of c_k's through backsubstitution
int n=t.size; int m=f.Length;
matrix A=new matrix(n,m); matrix R=new matrix(m,m);
vector b=new vector(n);
for(int i=0; i<n; i=i+1){b[i]=y[i]/dy[i]; for(int j=0; j<m; j=j+1){A[i,j]=f[j](t[i])/dy[i];}} 

// Decomposition and backsubstitution routines
Decomp(A,R); //Returns Q and stores R (Can be obtained through implemented Givens rotation but is not explicitely given this way.)
vector c=Solve(Decomp(A,R),R,b); 

// Covariance matrix and deviation
vector c_unc=new vector(m);
matrix R_2=new matrix(m,m);
Decomp(((A.T)*A),R_2); // Holds R_2
matrix sigma=Inverse(Decomp(((A.T)*A),R_2),R_2); 
for(int i=0; i<m; i++){c_unc[i]=Sqrt(sigma[i,i]);}
return Tuple.Create(c,c_unc);}

}
