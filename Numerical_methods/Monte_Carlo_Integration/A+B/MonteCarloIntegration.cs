using System; 
using static System.Math;
using static RNG;


public class MonteCarloIntegration{

// Plain Monte Carlo integrator
public static vector PlainMC(Func<vector,double> f, vector a, vector b, int N){
vector Result=new vector(2);
double V=1;
for(int i=0; i<a.size; i=i+1)
{
	V=V*(b[i]-a[i]); // Volume
}
double sum=0; double sum2=0;
for(int i=0; i<N; i=i+1)
{  
	double fx=f(RandVector(a,b));
	sum=sum+fx;
	sum2=sum2+Pow(fx,2);
}

double avg=sum/N; // <f_i>
double σ=Sqrt(sum2/(N-Pow(avg,2))); // σ²=<(f_i)²>-<f_i>²
double Error=V*σ/Sqrt(N);
double Integral=avg*V;
Result[0]=Integral; Result[1]=Error; 
return Result;}

} 
