using System;
using static System.Console;
using static GivensDecomposition;
using static RNG; // Secure RNG
class main{public static int Main(){

int n_2=RandomInt(3,5);
vector b= new vector(n_2);
var A_2 = new matrix(n_2,n_2);
for(int i=0; i<n_2; i=i+1){RandomDouble(0,1); for(int j=0; j<n_2; j=j+1){A_2[j,i]=RandomDouble(-20,20);b[j]=RandomDouble(-20,20);}}
(A_2).print("\nA = ");
(b).print("\nb = ");
(GivensSolve(Givens(A_2),b)).print("\nx = ");
(Givens(A_2)*GivensSolve(Givens(A_2),b)).print("\nAx = ");
WriteLine($"\nDet(A) = {Det(A_2)}");
return 0;}
}
