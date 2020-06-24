using System.Collections.Generic;
using static System.Console;
using static System.Math;
using static RootFinding;
using System;
using static ODE;
using System.IO;



public class Hydrogen{
public static double Solve(double ε, double r){ 

double r0 = 1e-6; 

// Given the Schrodinger equation on the form:  εf +(1/r)f+(1/2)f''= 0 for l=0
Func<double,vector,vector> f = (l,y) => {return new vector(y[1],-2*((1/l)+ε)*y[0]);};

// We seek solutions to the IVP: f_ε(r->0)=r-r^2, f'_ε(r->0)=1-2r
vector y0=new vector(r0-Pow(r0,2),1-2*r0);

// Obtaining F_ε by numerical integration
List<double> tlist=new List<double>(); List<vector> ylist=new List<vector>();
vector ymax = RK12Driver(f, r0, y0,r, 1e-3, 1e-6, 1e-6, tlist, ylist);
return ymax[0];}

// Auxillery function to find bound states
public static double BoundStates(Func<vector, vector> fε_root, double rmax){ 


vector guess = new vector(-2.7);

return NewtonsStep(fε_root, guess, 1e-6,1e-6)[0];
}
}
