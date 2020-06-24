using System;
using static System.Math;
using static System.Console;
using System.Linq;
public class JacobiDiagonalizationClassic{

public static int JacobiDiag(matrix A, vector e, matrix V){
int rotations=0; int n=A.size1; int check; int o; int h; int p; double hh; int tt; int ww; int q;
vector t=new vector(A.size1);
for(int i=0; i<n; i=i+1){e[i]=A[i,i];} // Diagonal of A
for(int i=0; i<n; i=i+1){for(int j=0; j<n; j=j+1){if(i==j){V[i,j]=1.0;} else{V[i,j]=0.0;}}}

do{rotations=rotations+1; check=0; // Break out of loop after executation if convergence criterion holds

// After each rotation we search for the largest elements in the rows of A, only the ones changed will be updated.
hh=A[0,1];
for(int i=0; i<A.size1-1; i=i+1){hh=A[i,i+1]; t[i]=i+1; for(int j=i+1; j<A.size2-1; j=j+1){if(hh<A[i,j+1]|hh==A[i,j+1]){t[i]=j+1; hh=A[i,j+1];}}}
t[A.size1-2]=A.size2-1; // No need for if statement, as there are no elements to compare. this is the only upper triangular off diagonal element left. 
// These could now sorted in another vector(as shown in the bottom)

for(p=0; p<A.size1-1; p=p+1){q=Convert.ToInt16(t[p]); // Eliminate the largest element (p,q) in the p'th row
double a_pp=e[p]; double a_qq=e[q];double a_pq=A[p,q];
double φ=0.5*Atan2(2*a_pq,a_qq-a_pp); // φ chosen st. A'_pq=A'_qp=0
double c=Cos(φ+PI/2); double s=Sin(φ+PI/2);
double a_pp1=Pow(c,2)*a_pp-2*s*c*a_pq+Pow(s,2)*a_qq; double a_qq1=Pow(s,2)*a_pp+2*s*c*a_pq+Pow(c,2)*a_qq; // Diagonal entries after the rotation
if(a_pp1!=a_pp|a_qq1!=a_qq|A[0,A.size1-2]!=0|A[0,A.size1-2]!=0) // Convergence criterion: (Diagonalized if false) (Added another criterion to ensure elimination of off diagonal elements.)
{check=1; // -> do another loop
// After the transformation A --> A'=(V^T)AV:
e[q]=a_qq1; e[p]=a_pp1; // Store eigenvalues in vector for possibility of saving lower triangular part of A' to bring back A.

for(int i=0; i<n; i=i+1){double A_pi=A[p,i]; double A_qi=A[q,i];
A[p,i]=c*A_pi-s*A_qi; A[q,i]=s*A_pi+c*A_qi; A[i,p]=A[p,i]; A[i,q]=A[q,i];}// ∀ i ≠ p,q
A[p,q]=0; A[q,p]=A[p,q];A[p,p]=a_pp1; A[q,q]=a_qq1; // Overwrite wrongly defined elements from above loop(careful with ordering here)

for(int i=0; i<n; i=i+1){
double v_ip=V[i,p]; double v_iq=V[i,q]; V[i,p]=c*v_ip-s*v_iq; V[i,q]=c*v_iq+s*v_ip;}//for
}// Convergence criterium
 } //for(p)
}while(check==1); //do

return rotations;}}



///EXTRA O(n^2) operation
// After having determined the vector t[i]=j with A[i,j] being the largest element in the i'th row one can describe a new ordered vector pertaining to the elements in A which holds the same information but in an ordered way such that (ttt[0]=i where A[i,t[i]] yields the higest off diagonal element in A) i.e here one would eliminate the largest element all A:

//o=0; vector d=t.copy();
//double[] array=new double[t.size];
//for(int i=0; i<t.size-1; i=i+1){o=Convert.ToInt16(t[i]); array[i]=A[i,o];} // Converts to array to sort using built in library
//Array.Sort(array); Array.Reverse(array); // Built in array library with sort routine
//int[] array1=new int[t.size]; 
//for(int i=0; i<t.size-1; i=i+1){for(int j=0; j<t.size-1; j=j+1){o=Convert.ToInt16(t[j]); if(A[j,o]==array[i]){array1[i]=j; array[i]=-500;}}} // To remove duplicates from search in ordered vector of elements from A.
//vector ttt=new vector(t.size);
//for(int i=0; i<t.size-1; i=i+1){ttt[i]=Convert.ToDouble(array1[i]);} // ttt[0]=i where A[i,t[i]] yields the higest off diagonal element in A

