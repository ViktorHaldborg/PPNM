using System; using static System.Console; using static System.Math;
public class NumericalGradient{


public static vector Gradient(Func<vector, double> f, vector x){ // Input function with vector as arguments
vector Gradient=new vector(x.size);
vector dx=new vector(x.size); double δx;

double Ɛ=1.0/4194304; // 

for(int i=0; i<x.size; i=i+1)
{
	if(Abs(x[i])<Sqrt(Ɛ)){δx=Ɛ;}
	else{δx=Abs(x[i])*Ɛ;}
	dx[i]=δx;
	Gradient[i]=(f(x+dx)-f(x))/δx;
	dx[i]=dx[i]-δx;
}

return Gradient;
}}



