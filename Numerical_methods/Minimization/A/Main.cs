using System; using static System.Console; using static System.Math;
using static QuasiNewtonianMethods;
using static NumericalGradient;


public class main{ public static int Main(){

Func<vector,double> f = delegate(vector x){
double a=1; 
double b=100;
return Pow(a-x[0],2)+b*Pow(x[1]-Pow(x[0],2),2);};
vector x0=new vector(2,5);
double Ɛ=10e-9; // Requiring the norm of the gradient of f to be < Ɛ
int steps=QuasiNewtonMinimization(f,x0,Ɛ).Item1;
vector root=QuasiNewtonMinimization(f,x0,Ɛ).Item2;
WriteLine($"\n\nFinding a minimum of the Rosenbrock function:\n\n Required precision on the gradient: Ɛ={Ɛ} \n\n Initial guess: ({x0[0]},{x0[1]})  \n\n Converged to the point: ({root[0]},{root[1]}) in {steps} steps, with a=1 and b=100 the analytical minima is at (1,1) \n\n");

Func<vector,double> f2 = delegate(vector x){
return Pow(Pow(x[0],2)+x[1]-11,2)+Pow(Pow(x[1],2)+x[0]-7,2);};
// x0=vector(2,5); same initial guess as before
steps=QuasiNewtonMinimization(f2,x0,Ɛ).Item1;
root=QuasiNewtonMinimization(f2,x0,Ɛ).Item2;
WriteLine($"\n\nFinding a mininum of the Himmelblau's function:\n\n Required precision on the gradient: Ɛ={Ɛ} \n\n Initial guess: ({x0[0]},{x0[1]})  \n\n Converged to the point: ({root[0]},{root[1]}) in {steps} steps, an analytical minima is at (3,2) \n\n");



return 0;}
}
