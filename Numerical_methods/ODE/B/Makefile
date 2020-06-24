LIBDIR = ../../matlib

B2.svg : B.gpi out.txt
	gnuplot B.gpi

out.txt : Main.exe
	mono  $< >$@

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll : $(LIBDIR)/matrix/vector.cs ODE.cs
	mcs -target:library -out:$@ $^

clean:
	rm *.txt *.dll *.exe
