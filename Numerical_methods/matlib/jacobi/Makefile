MCS = mcs -optimize+ -platform:arm
MONO = mono -O=all #-O=all,-shared #--optimize=unsafe,loop,inline #--gc=sgen --llvm --optimize=all

comma:=,
empty:=
space:=$(empty) $(empty)
commalist = $(subst $(space),$(comma),$(1))

all: out.txt plot.times.svg

out.txt: main.exe Makefile
	$(MONO) $< 7 | tee $@

plot.times.svg: out.times.txt Makefile
	echo '\
	set term svg size 640,480 background "white" font "times,14";\
	set out "$@";\
	set key left;\
	set title "matrix diagonalization times (`$(MCS) --version` `uname -m`)";\
	set xlabel "matrix size n";\
	set ylabel "diagonalization time t, sec";\
	f(x)=b+(x/a)**c;\
	b=1; a=90; c=3;\
	fit f(x) "$<" via a,b;\
	plot \
	 "$<" title "measurement" \
	,f(x) title sprintf("cyclic: fit: (n/%.f)^{%.2f}+%.3f",a,c,b) \
	'| gnuplot

out.times.txt: main.exe Makefile
	cat /dev/null > $@
	for N in `seq 73 5 133`; do \
	echo "N=$$N";\time -ao $@ -f "$$N %U" $(MONO) main.exe $$N ; \
	done

main.exe: main.cs matrix.dll
	$(MCS) $< -o:$@ -r:$(call commalist,$(filter-out $<,$^))

matrix.dll: jacobi.cs ../matrix/matrix.cs ../matrix/vector.cs
	$(MCS) $^ /t:library /out:$$(pwd)/$@

clean: ; $(RM) *.dll *.exe out.* *.log *.svg

#%.dll: %.cs ; $(MCS) -t:library $*.cs -o:$*.dll *log
