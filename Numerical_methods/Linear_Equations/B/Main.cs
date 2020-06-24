using System;
using static System.Console;
using static QRGramSchmidtDecomposition;
using static System.Math;
using static RNG; // Secure RNG
class main{public static int Main(){

int n_2=RandomInt(3,5);
vector b= new vector(n_2);
var A_2 = new matrix(n_2,n_2);
for(int i=0; i<n_2; i=i+1){for(int j=0; j<n_2; j=j+1){A_2[j,i]=RandomDouble(-20,20);b[j]=RandomDouble(-20,20);}}
var R_2 = new matrix(n_2,n_2); Decomp(A_2,R_2); //yields R_2
var B=Inverse(Decomp(A_2,R_2),R_2);
(A_2).print("A=");
(B).print("\nB=");
(A_2*B).print("\nAB=");
WriteLine("\nOff diagonal elements not necesarily 0 due to tiny numerical instability caused by rounding errors");
WriteLine("\nAfter rounding we get:\n");
var AB = new matrix(n_2,n_2);
for(int i=0; i<n_2; i=i+1){for(int j=0; j<n_2; j=j+1){AB[j,i]=Round((A_2*(Inverse(Decomp(A_2,R_2),R_2)))[j,i]);}}
//Creating nxn identity to compare
double sum1=0;
var I= new matrix(n_2,n_2); for(int i=0; i<n_2; i=i+1){for(int j=0; j<n_2; j=j+1){if(j==i){I[j,i]=1;} else{I[j,i]=0;};}}
for(int i=0; i<n_2; i=i+1){for(int j=0; j<n_2; j=j+1){if(Round((AB-I)[i,j])==0){sum1=sum1+1;} else{sum1=sum1+0;}}} 
(AB).print("AB=");
if(sum1==n_2*n_2){Write("\nCheck passed: AB=I as wished");} else{Write("\nCheck failed: AB is not equal to I");}

return 0;}
}
