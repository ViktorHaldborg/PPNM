LIBDIR = ../../matlib
DIR = ../..

all: B.txt out.txt plotB.svg

plotB.svg : B.txt plotB.gpi
	gnuplot plotB.gpi

B.txt : Main.exe
	mono  $< >$@

out.txt : Main.exe
	mono  $< >$@

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll : $(LIBDIR)/matrix/vector.cs $(LIBDIR)/matrix/matrix.cs NonLinearEquations.cs JacobiMatrix.cs $(DIR)/Linear_Equations/B/LinearEquations.cs $(DIR)/ODE/A/ODE.cs Hydrogen.cs
	mcs -target:library -out:$@ $^

clean:
	rm *.txt *.dll *.exe *.svg
