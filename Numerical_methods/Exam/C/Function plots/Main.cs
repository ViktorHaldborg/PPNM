using System; using static System.Math; using static System.Console; using System.IO;
using static RootFinding;
using static RNG; // Secure RNG
using static JacobiDiagonalization1;
using static IntervalSearch;
using System.Diagnostics;
class main{public static int Main(){




// Generic input Parameters, just need to generate random problem
int ε=3;
int μ=3;

int Points=1000;
int n=3;

var Matrices=Search(n,Points,ε,μ);
matrix A_d=Matrices.Item1;
matrix A=Matrices.Item2;


return 0;}
}
