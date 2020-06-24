using static System.Console;
using static System.Math;
using static RootFinding;
using static Hydrogen;
using System.IO;
using System;

public class main{public static int Main(){


double rmax=8;
Func<vector, vector> fε_root = (vector m) => {double ε=m[0]; 
double F_ε=Solve(ε, rmax); //Finding solution to the IVP
return new vector(F_ε);};

using (StreamWriter Out = new StreamWriter("out.txt")){
using (StreamWriter B = new StreamWriter("B.txt")){

double ε_bound=BoundStates(fε_root,rmax);

for(double r = 0; r<rmax; r=r+0.25){
B.WriteLine($"{r} {Solve(ε_bound,r)} {r*Exp(-r)} {ε_bound} -0.5"); // Solve the Schrodinger equation for the spectrum of wavefunctions with different initial conditions
}

Out.WriteLine($"Lowest bound state energy of radial hydrogen wavefunction(l=0) \n\n Numerial result={ε_bound} \n\n Analytical result=-0.5");
}
}
return 0;
}
}	
