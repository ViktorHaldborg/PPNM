using System; using static System.Math; 
using static System.Console;
using static RootFinding;
class main{public static void Main(){
double ε=1e-9; 
double u=1; while(1+u!=1){u/=2;} u*=2; double δx=Sqrt(u); // Square root of machine ε

// Constructing multidimensional function which for our 1D purposes handles the elements of the given inputvector in 1 dimension.
Func<vector, vector> simple=(x) => new vector(Pow(x[0],2)-3.4); // Simple: x²-3.4 
vector x0 = new vector(1);
for(double k=-3; k<4; k=k+2*3){ // Picking initial parameters in Newton's step, breaking the loop if diverging.
x0[0]=k; Write("Operation was ");vector TryFindRoot=NewtonsStep(simple,x0,ε,δx);
for(int i=0; i<x0.size; i=i+1){
WriteLine($"\n\nObtained roots = {TryFindRoot[i]} with x0={k}\n\nInserting into f(x)=x²-3.4 we find:\n");
Write($"f({TryFindRoot[i]})={Pow(TryFindRoot[i],2)-3.4} which rounded is {Round(Pow(TryFindRoot[i],2)-3.4)}");
if(Round(Pow(TryFindRoot[i],2)-3.4)==0){Write(" as wished.\n\n");} else{Write(" which is not a root(Error: try another x0)");}}
}
		

Func<vector, vector> Rosen=(v) => new vector(-2*(1-v[0]) + 100*2*(v[1]-v[0]*v[0])*2*v[0], 100*2*(v[1]-v[0]*v[0]));; // Rosenbrock function: f(x,y) = (1-x)²+100(y-x²)²
vector x0_2=new vector(1.5,25); // Initial parameters for first Newton's step
Write("Rosenbrock function: Operation was "); vector TryFindRoot1=NewtonsStep(Rosen,x0_2,ε,δx);
WriteLine($"\n\nObtained root = ({TryFindRoot1[0]},{TryFindRoot1[1]}) with x0_2=({x0_2[0]},{x0_2[1]})"); 
WriteLine($"Inserting into the gradient of the Rosenbrock function: f(x,y)=(-2*(1-x)+100*2*(y-x*x*2*x, 100*2*(y-x*x)) we find:\n\nf({TryFindRoot1[0]},{TryFindRoot1[1]})=({-2*(1-TryFindRoot1[0]) + 100*2*(TryFindRoot1[1]-TryFindRoot1[0]*TryFindRoot1[0])*TryFindRoot1[0]*2},{100*2*(TryFindRoot1[1]-TryFindRoot1[0]*TryFindRoot1[0])}) ~ ({Round(-2*(1-TryFindRoot1[0]) + 100*2*(TryFindRoot1[1]-TryFindRoot1[0]*TryFindRoot1[0])*TryFindRoot1[0]*2)},{Round(100*2*(TryFindRoot1[1]-TryFindRoot1[0]*TryFindRoot1[0]))}) after rounding, as wished.\n");
}}
