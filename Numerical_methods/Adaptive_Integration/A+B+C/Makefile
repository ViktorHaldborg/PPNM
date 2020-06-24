LIBDIR = ../../matlib

out.txt : Main.exe
	mono  $< >$@

Main.exe : Main.cs matlib.dll
	mcs $< -reference:matlib.dll

matlib.dll : $(LIBDIR)/matrix/vector.cs $(LIBDIR)/integration/quado8.cs Integration.cs
	mcs -target:library -out:$@ $^

clean:
	rm *.txt *.dll *.exe
