using System;
using static System.Math;
using static Backsubstitution;
public class GivensDecomposition{

public static matrix Givens(matrix A){
int n=A.size1;int m=A.size2;	
matrix A_t=A.copy();
// The Jacobi matrix G is given as an identity matrix except that it contains elements of a rotation matrix
// The elements G_pp, G_qq are replaced with cos(θ) and G_qp and G_pq with -sin(θ) and sin(θ) respectively
// G is therefore a rotation of a vector in the p,q plane
// We aim to use this transformation to zero elements of A by using the Givens rotation: A->GA=A_t
// We must choose θ=Atan2(A[p,q],A[q,q]) to zero the p,qth element in A under a Givens rotation:
		
for(int q=0; q<m; q=q+1){for(int p=q+1; p<n; p=p+1){double θ=Atan2(A_t[p,q], A_t[q,q]);
for(int k=q; k<m; k=k+1){double xq=A_t[q,k];double xp=A_t[p,k];
A_t[q,k]=xq*Cos(θ)+xp*Sin(θ);A_t[p,k]=-xq*Sin(θ)+xp*Cos(θ);} // New elements in A, after the rotation
A_t[p,q]=θ;} // Adding the θ which zero'ed the p,qth entry in A
} // Yields upper triangular matrix R, but with the added θ's which zeroed the corresponding lower triangular entries in A
return A_t;}

public static vector GivensSolve(matrix A,vector b){ // Solving the system Ax=b by transformation to the triangular system Rx = Gb
int n=A.size1; int m=A.size2;
vector v=b.copy();
for(int q=0; q<m; q=q+1){for(int p=q+1; p<n; p=p+1){ 
double θ=Givens(A)[p,q]; // Defining the θ which zero's the p,qth entry in A
double vq=v[q]; double vp=v[p]; // Defining the corresponding elements in b
v[q]=vq*Cos(θ)+vp*Sin(θ); v[p]=-vq*Sin(θ)+vp*Cos(θ); // Evaluating Gb elementwise
}}// Yields v=Gb=Rx
return Backsubstitute(v,Givens(A));} // Solving v=Rx by backsubstitution to retrive solutionvector


public static double Det(matrix A){
int n=A.size1;
matrix G=Givens(A); // Since we are only utilizing the diagonal elements(G[i,i]=R[i,i])
double prod=1;
for(int i=0; i<n; i=i+1){prod=prod*G[i,i];}
return prod;}

}
