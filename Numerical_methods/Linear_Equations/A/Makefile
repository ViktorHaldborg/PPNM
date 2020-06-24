LIBDIR = ../../matlib

out.txt : Main.exe
	mono  $< >$@

Main.exe : Main.cs matlib.dll LinearEquations.cs
	mcs $< -reference:matlib.dll

matlib.dll : $(LIBDIR)/matrix/vector.cs $(LIBDIR)/matrix/matrix.cs LinearEquations.cs $(LIBDIR)/DataGeneration/RNG/RandomNumberGenerator.cs
	mcs -target:library -out:$@ $^

clean:
	rm *.txt *.dll *.exe
