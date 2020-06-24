LIBDIR = ../../matlib


all: B.svg B.txt out.txt

B.svg : B.gpi B.txt
	gnuplot $<

B.txt : Main.exe
	mono  $< >$@

out.txt : Main.exe
	mono  $< >$@

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll


matlib.dll : $(LIBDIR)/matrix/vector.cs MonteCarloIntegration.cs $(LIBDIR)/matrix/matrix.cs $(LIBDIR)/DataGeneration/RNG/RandomNumberGenerator.cs
	mcs -target:library -out:$@ $^


clean:
	rm *.txt *.dll *.exe B.svg

