ifeq ($(OS),Windows_NT)
	CC = cl
	CFLAGS = /O2 /Ot /GL /MD /DNDEBUG
else
	CC = gcc
	CFLAGS = -O2 -s -DNDEBUG
endif

main: main.c fibo.o fibo_iter.o
	$(CC)  $(CFLAGS) -o c_fibo.exe main.c fibo.o fibo_iter.o

fibo.o: fibo.c
	$(CC) $(CFLAGS) fibo.c -c -o fibo.o
	move $*.obj $*.o

fibo_iter.o: fibo_iter.c
	$(CC) $(CFLAGS) fibo_iter.c -c -o fibo_iter.o
	move $*.obj $*.o

.PHONY: clean

clean:
	rm -rf *.o *.obj