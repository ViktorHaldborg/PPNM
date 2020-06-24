LIBDIR = ../../matlib

all: Eigenfunctions.svg ParticleInABox.txt Out.txt Eigenfunctions.txt


Eigenfunctions.svg: Eigenfunctions.gpi Eigenfunctions.txt
	gnuplot $<

ParticleInABox.txt Eigenfunctions.txt: MainQuantum.exe
	mono  $< >$@

Out.txt : Main.exe
	mono  $< >$@

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll

MainQuantum.exe : MainQuantum.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll : $(LIBDIR)/matrix/vector.cs $(LIBDIR)/matrix/matrix.cs Jacobi_diagonalization.cs $(LIBDIR)/DataGeneration/RNG/RandomNumberGenerator.cs
	mcs -target:library -out:$@ $^

clean:
	rm *.dll *.svg *.txt *.exe



