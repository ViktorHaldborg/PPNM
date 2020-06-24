LIBDIR = ../../matlib
DIR = ../../Matrix_Diagonalization/A

all: Time.txt Out.txt MainTime.txt Time.svg Rots.svg

Rots.svg : Rots.gpi Time.txt MainTime.txt
	gnuplot Rots.gpi

Time.svg : Time.gpi Time.txt MainTime.txt
	gnuplot Time.gpi

MainTime.txt : MainTime.exe
	mono  $< >$@

Time.txt : Main.exe
	mono  $< >$@

Out.txt : Main.exe
	mono  $< >$@

MainTime.exe : MainTime.cs matlib.dll Jacobi_diagonalization_sweep.cs
	mcs $< -reference:matlib.dll

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll : $(LIBDIR)/matrix/vector.cs $(LIBDIR)/matrix/matrix.cs Jacobi_diagonalization.cs $(LIBDIR)/DataGeneration/RNG/RandomNumberGenerator.cs Jacobi_diagonalization_sweep.cs
	mcs -target:library -out:$@ $^

clean:
	rm *.dll *.svg *.txt *.exe



