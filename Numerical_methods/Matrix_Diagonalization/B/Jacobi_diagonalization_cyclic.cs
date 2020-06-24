using System;
using static System.Math;
using static System.Console;
public class JacobiDiagonalizationCyclic{

public static int JacobiDiag(matrix A, vector e, matrix V){
int rotations=0; int n=A.size1; int q; int p; int check;
for(int i=0; i<n; i=i+1){e[i]=A[i,i];} // Diagonal of A
for(int i=0; i<n; i=i+1){for(int j=0; j<n; j=j+1){if(i==j){V[i,j]=1.0;} else{V[i,j]=0.0;}}}

do{rotations=rotations+1; check=0; // Break out of loop after executation if convergence criterion holds
for(q=n-1;q>0;q=q-1)for(p=0;p<q;p=p+1){
double a_pp=e[p]; double a_qq=e[q];double a_pq=A[p,q];
double φ=0.5*Atan2(2*a_pq,a_qq-a_pp); // φ chosen st. A'_pq=A'_qp=0
double c=Cos(φ); double s = Sin(φ);
double a_pp1=Pow(c,2)*a_pp-2*s*c*a_pq+Pow(s,2)*a_qq; double a_qq1=Pow(s,2)*a_pp+2*s*c*a_pq+Pow(c,2)*a_qq; // Diagonal entries after the rotation
if(a_pp1!=a_pp||a_qq1!=a_qq) // Check if convergence convergence criterion is satisfied (Diagonalized if false)
{check=1; // -> do another loop
// After the transformation A --> A'=(V^T)AV:
e[q]=a_qq1; e[p]=a_pp1; // Store eigenvalues in vector for possibility of saving lower triangular part of A' to bring back A.

for(int i=0; i<n; i=i+1){double A_pi=A[p,i]; double A_qi=A[q,i];
A[p,i]=c*A_pi-s*A_qi; A[q,i]=s*A_pi+c*A_qi; A[i,p]=A[p,i]; A[i,q]=A[q,i];}// ∀ i ≠ p,q
A[p,q]=0;A[p,p]=a_pp1; A[q,q]=a_qq1; A[q,p]=A[p,q]; // Overwrite wrongly defined elements from above loop

for(int i=0; i<n; i=i+1){
double v_ip=V[i,p]; double v_iq=V[i,q]; V[i,p]=c*v_ip-s*v_iq; V[i,q]=c*v_iq+s*v_ip;}}}}
while(check==1);
return rotations;}}
