orb.svg : orb.gpi out.txt
	gnuplot $<

out.txt: main.exe
	mono $< > $@
	
main.exe: main.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../../matlib
matlib.dll: $(LIBDIR)/ode/driver.cs $(LIBDIR)/ode/rkstep23.cs $(LIBDIR)/matrix/vector.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe *.dll out*

	
