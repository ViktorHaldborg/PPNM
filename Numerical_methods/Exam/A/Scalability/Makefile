LIBDIR= ../../../matlib
DIR2 = ../../../Matrix_Diagonalization
DIR3 = ../../../Interpolation

all: Time.txt Time.svg

Time.svg : Time.gpi Time.txt
	gnuplot $<


Time.txt : Main.exe
	mono  $< >$@

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll : $(LIBDIR)/matrix/matrix.cs $(LIBDIR)/matrix/vector.cs NonLinearEquations.cs $(LIBDIR)/DataGeneration/RNG/RandomNumberGenerator.cs $(DIR2)/A/Jacobi_diagonalization.cs Generation.cs IntervalSearch.cs

	mcs -target:library -out:$@ $^

clean:
	rm Time.txt *.dll *.exe Time.svg
