using System; using static System.Console;
using static System.Math;
public class QRGramSchmidtDecomposition{


static public matrix Decomp(matrix A, matrix R){
int n=A.size1;
int m=A.size2;
if(m>n){Error.WriteLine("Error(m>n): Pick different input matrix"); return A;}
else{
var Q=A.copy();
for(int i=0; i<m; i=i+1) {R[i,i]=Q[i].norm(); Q[i]=Q[i]/R[i,i];
for(int j=i+1; j<m; j=j+1){R[i,j]=Q[i].dot(Q[j]); Q[j]=Q[j]-Q[i]*R[i,j];}}// Complex conjugation is disregarded since implementation of complex entries is disregarded.
return Q; // Yields Q at exit
}}

// Determinant will be implemented in part c) using the Givens rotation algorithm

static public vector Solve(matrix Q, matrix R, vector b){
var c=(Q.T)*b;
int n=c.size;
// Back-substitution
for(int i=n-1; i>=0; i=i-1){double sum=0; for(int k=i+1; k<n; k=k+1){sum=sum+R[i,k]*c[k];}c[i]=(c[i]-sum)/R[i,i];}
return c;} //yields solutionvector

}


