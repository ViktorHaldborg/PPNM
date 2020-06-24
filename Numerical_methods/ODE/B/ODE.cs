using System; 
using static System.Console;
using static System.Math;
using System.Collections;
using System.Collections.Generic;
public class ODE{
public static vector[] RKstepper12(Func<double,vector,vector> f, double x0, vector y0, double h){  // Embedded Heun-Euler stepper
	vector k0=f(x0,y0);
	vector k1=f(x0+h,y0+h*k0);
	vector k=0.5*(k0+k1);
	vector yh=y0+h*k;
	vector deltay=h*(k1-k0); // Estimate of the error in stepwise integration
	vector[] result = {yh, deltay};
	return result;}


// Driver calling RKstepper12
public static vector RK12Driver(Func<double, vector, vector> f,double x0,vector y0,double x1,double h,double acc,double eps,List<double> xlist,List<vector> ylist){
xlist.Clear(); ylist.Clear();
xlist.Add(x0); ylist.Add(y0);

while(x0<x1){
	if(x0+h>x1){h=x1-x0;}
	vector[] step=RKstepper12(f,x0,y0,h);
	vector yh=step[0];
	vector deltay=step[1];
	double safety=0.95;
	double power=0.25;		
	vector tau = new vector(deltay.size);
	for(int i=0; i<deltay.size; i=i+1){
	tau[i] = (eps*Abs(yh[i])+acc)*Sqrt(h/(x1-x0));} // local tolerance(not refined)
	for(int i=1; i<deltay.size; i=i+1){
	if(tau[i]>deltay[i]){ // Local error within local tolerance(h accepted)
		x0=h+x0; y0=yh; 
		xlist.Add(x0); ylist.Add(yh);}
	if(deltay[i]>tau[i]){Error.WriteLine($"Step at {x0} not accepted");}
	h=h*Pow(Abs(tau[i]/deltay[i]),power)*safety;} // h_{n+1} in either case
	}
return y0;
}}
