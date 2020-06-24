
out.txt: main.exe
	mono $< >$@

main.exe: main.cs math.dll
	mcs $< -reference:math.dll
LIBDIR = ../../../matlib/integration
math.dll: $(LIBDIR)/quado4.cs $(LIBDIR)/quadc5.cs $(LIBDIR)/quadc7.cs $(LIBDIR)/quado8.cs
	mcs $^ -target:library -out:$@

clean:
	rm -f *.exe *.dll out*

