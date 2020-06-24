using static System.Console; using static System.Math;
using static BinarySearch;
public class LinearInterpolation{
        
// Linear Interpolation
static public double LinSpline(vector x, vector y, double z){
int i=BinSearch(x,z);  // Half interval search
double dx_i=x[i+1]-x[i]; double dy_i=y[i+1]-y[i]; double p_i=dy_i/dx_i;
double S=y[i]+p_i*(z-x[i]); // Linear spline
return S;} 
	
// Integration of the splinefunction
// Analytical form of the integral: ∫y+p*x dx = yx+(1/2)*p*x² (C=0)
// Integration of the tabulated function S_[i]:
static public double LinSplineIntegral(vector x, vector y, double z){
int z_i=BinSearch(x,z);
double sum1=0.00;
for(int i=0;i<z_i; i=i+1){double dx_i=x[i+1]-x[i]; double dy_i=y[i+1]-y[i]; double px_i=dy_i/dx_i;
sum1=sum1+(x[i+1]-x[i])*y[i]+(0.50)*px_i*Pow(x[i+1]-x[i],2);}  // The integral of the splinefunction at x[i]
double dxz_i=x[z_i+1]-x[z_i]; double dyz_i=y[z_i+1]-y[z_i]; double pz_i=dyz_i/dxz_i;
double sum2=(z-x[z_i])*y[z_i]+(0.50)*pz_i*Pow(z-x[z_i],2); // The integral of the splinefunction for x[i]<z<x[i+1]
return sum1+sum2; // Returning analytical(tabulated data with arbitrary precision) integral of the splinefunction	
}}

