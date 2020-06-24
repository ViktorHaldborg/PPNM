LIBDIR = ../../matlib
DIR2 = ../../Linear_Equations

out.txt : Main.exe
	mono  $< >$@

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll : $(LIBDIR)/matrix/vector.cs $(LIBDIR)/matrix/matrix.cs NonLinearEquations.cs JacobiMatrix.cs $(DIR2)/B/LinearEquations.cs 
	mcs -target:library -out:$@ $^

clean:
	rm *.txt *.dll *.exe
