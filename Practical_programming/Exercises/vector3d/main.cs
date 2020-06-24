using static System.Console;
using static System.Math;
class main{
	static int Main(){
		vector3d v = new vector3d(1, 2, 3); 
		vector3d u = new vector3d(4, 5, 6);
		double c=1.5;
		WriteLine($"v = {v}"); 
		WriteLine($"u = {u}");
		WriteLine($"c = {c}");
		WriteLine($"c*v = {c*v} & v*c = {v*c} ");
		WriteLine($"v+u = {v+u}"); 
		WriteLine($"v-u = {v-u}");
		WriteLine($"v*u = {v.dot_product(u)}");
		WriteLine($"vxu = {v.vector_product(u)}");
		WriteLine($"||v|| = {v.magnitude()}");		

	return 0;
}

}
