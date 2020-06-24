using System;
using static System.Console;
using static System.Math;
using static QRGramSchmidtDecomposition;
using static RNG; // Secure RNG
class main{public static int Main(){

int n=RandomInt(5,8);
int m=RandomInt(3,5);
var A = new matrix(n,m);
for(int i=0; i<m; i=i+1){for(int j=0; j<n; j=j+1){A[j,i]=RandomDouble(-20,20);}}
if(m>n){Error.WriteLine("Error: m must not be larger than n");return 1;}
var R = new matrix(m,m);
A.print("A=");
	
// QR factorization
WriteLine("\nQR-decomposition by modified Gram-Schmidt orthogonalization:\n");
Decomp(A,R).print("Q="); //Outputs Q
R.print("R=");
(Decomp(A,R)*R).print("QR="); //Q*R
double sum1=0;
for(int h=0; h<n; h=h+1){for(int o=0; o<m; o=o+1){if(Round(A[h,o])==Round((Decomp(A,R)*R)[h,o])){sum1=sum1+1;} else{sum1=sum1+0;}}} 
if(sum1==n*m){Write("\nCheck passed: A=QR as wished");} else{Write("\nCheck failed: A is not equal to QR");}
	
((Decomp(A,R).T)*Decomp(A,R)).print("\n\ntranspose(Q)Q=\n (Tiny numeric instability is shown)");
WriteLine("\nLower Triangular entries:");

// Upper triangular
double sum=0;
for(int j=0; j<m; j=j+1){for(int i=j+1; i<m; i=i+1){sum=sum+R[i,j]; WriteLine($"\nR[{i},{j}]={R[i,j]}");}}
if(sum==0){Write("\nR is upper triangular");} else{Write("R is not upper triangular");}

// Solving(with new matrix A_2 with n_2^2 indices)
int n_2=RandomInt(3,5);
vector b= new vector(n_2);
var A_2 = new matrix(n_2,n_2);
for(int i=0; i<n_2; i=i+1){for(int j=0; j<n_2; j=j+1){A_2[j,i]=RandomDouble(-20,20);b[j]=RandomDouble(-20,20);}}
var R_2 = new matrix(n_2,n_2); Decomp(A_2,R_2); //yields R_2
WriteLine("\n\nPart 2:");
A_2.print("\nA=");
b.print("\nb=");
((Solve(Decomp(A_2,R_2),R_2,b))).print("\nx=");
(A_2*(Solve(Decomp(A_2,R_2),R_2,b))).print("\nAx=");
double sum2=0;
for(int u=0; u<b.size; u=u+1){if(Round(b[u])==Round((A_2*(Solve(Decomp(A_2,R_2),R_2,b)))[u])){sum2=sum2+1;} else{sum2=sum2+0;}}
if(sum2==b.size){Write("\nCheck passed: Ax=b as wished");} else{Write("\nCheck failed: Ax is different from b");}


return 0;}
}

