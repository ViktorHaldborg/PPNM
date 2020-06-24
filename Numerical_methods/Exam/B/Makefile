LIBDIR= ../../matlib
DIR2 = ../../Matrix_Diagonalization
DIR3 = ../../Interpolation

all: out.txt

out.txt : Main.exe
	mono  $< >$@

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll : $(LIBDIR)/matrix/matrix.cs $(LIBDIR)/matrix/vector.cs NonLinearEquations.cs $(LIBDIR)/DataGeneration/RNG/RandomNumberGenerator.cs $(DIR2)/A/Jacobi_diagonalization.cs Generation.cs IntervalSearch.cs

	mcs -target:library -out:$@ $^

clean:
	rm out.* *.dll *.exe
